--Procedure responsável pelo relatório do window
DELIMITER $$
CREATE PROCEDURE sp_relatorio1
    @dataini DATE,
    @datafim DATE
AS
BEGIN

SELECT c.nome,
       a.dt_inicio as datainicial,
       a.dt_termino as datafinal,
       a.valor_apolice,
       i.id_imovel,
       CASE WHEN EXISTS (SELECT 1 FROM sinistro s WHERE s.id_apolice = a.id_apolice) THEN 'Sim' ELSE 'Não' END AS tem_sinistro,
       (
              SELECT STUFF(
              (
                     SELECT ', ' + co.descricao
                       FROM cobertura co
                      INNER JOIN apolice_cobertura ac ON ac.id_cobertura = co.id_cobertura
                      WHERE ac.id_apolice = a.id_apolice
                        FOR XML PATH('')
		), 1, 2, '')
	   ) AS coberturas,
       CASE WHEN getdate() between a.dt_inicio and a.dt_termino then 'Sim' ELSE 'Não' END as esta_vigente	
  FROM cliente c	
  join imovel i on i.id_proprietario = c.id_cliente
  join apolice a on a.id_imovel = i.id_imovel
 where a.dt_inicio between @dataini and @datafim
	
END$$

-- Trigger para evitar o pagamento caso a apólice já esteja expirada:
DELIMITER $$
CREATE TRIGGER bloquear_pagamento_cancelado
BEFORE INSERT ON pagamento
FOR EACH ROW
BEGIN
  DECLARE apolice_cancelada INT;
  SET apolice_cancelada = (SELECT COUNT(*) FROM apolice WHERE id_apolice = NEW.id_apolice AND dt_termino < CURDATE());
  IF apolice_cancelada > 0 THEN
    SIGNAL SQLSTATE '45000'
    SET MESSAGE_TEXT = 'Não é possível inserir pagamento para uma apólice expirada';
  END IF;
END$$

-- Função para verificar apólice ativa
DELIMITER $$
CREATE FUNCTION IF NOT EXISTS verificar_apolice_ativa(id_imovel INT)
RETURNS VARCHAR(3) READS SQL DATA
BEGIN
  DECLARE apolice_ativa VARCHAR(3);
  SET apolice_ativa = 'Não';
  IF EXISTS (SELECT 1 FROM apolice WHERE id_imovel = id_imovel AND CURDATE() BETWEEN dt_inicio AND dt_termino) THEN
    SET apolice_ativa = 'Sim';
  END IF;
  RETURN apolice_ativa;
END$$

-- Procedure para inserir itens
DELIMITER $$
CREATE PROCEDURE criar_registros(IN num_registros INT, IN id_inicial_imovel INT)
BEGIN
    DECLARE contador INT DEFAULT 0;
    DECLARE id_proprietario INT;
    DECLARE id_inquilino INT;
    
    WHILE contador < num_registros DO
        REPEAT
            SET id_proprietario = FLOOR(RAND() * 10) + 1; -- id_proprietario entre 1 e 10
            SET id_inquilino = FLOOR(RAND() * 10) + 1; -- id_inquilino entre 1 e 10
        UNTIL id_inquilino <> id_proprietario END REPEAT;
        
        INSERT INTO imovel (id_imovel, id_proprietario, id_inquilino, endereco, tipo_imovel, valor_imovel, area_imovel, ano_construcao)
        SELECT
            id_inicial_imovel + contador,
            id_proprietario,
            id_inquilino,
            CONCAT('Endereco', id_inicial_imovel + contador),
            CONCAT('Tipo', id_inicial_imovel + contador),
            RAND() * 1000000,
            RAND() * 1000,
            2000 + FLOOR(RAND() * 23);
        
        SET contador = contador + 1;
    END WHILE;
END$$

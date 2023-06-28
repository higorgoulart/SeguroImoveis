--Procedure responsável pelo relatório do window
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

END

-- Trigger para evitar o pagamento caso a apólice já esteja cancelada:
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
END;


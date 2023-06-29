
CREATE PROCEDURE sp_relatorio1 (
	IN dataini DATE,
    IN datafim DATE
)
BEGIN
	SELECT
		c.nome,
		a.dt_inicio AS datainicial,
        a.dt_termino AS datafinal,
        a.valor_apolice,
        i.id_imovel,
        (CASE WHEN EXISTS (SELECT COUNT(*) FROM sinistro s WHERE s.id_apolice = a.id_apolice) THEN 'Sim' ELSE 'Não' END) AS tem_sinistro,
        (
            SELECT GROUP_CONCAT(co.descricao SEPARATOR ', ')
            FROM cobertura co
            INNER JOIN apolice_cobertura ac ON ac.id_cobertura = co.id_cobertura
            WHERE ac.id_apolice = a.id_apolice
		) AS coberturas,
        (CASE WHEN CURDATE() BETWEEN a.dt_inicio AND a.dt_termino THEN 'Sim' ELSE 'Não' END) AS esta_vigente
	FROM cliente c
	JOIN imovel i ON i.id_proprietario = c.id_cliente
	JOIN apolice a ON a.id_imovel = i.id_imovel
	WHERE a.dt_inicio BETWEEN dataini AND datafim;
END;

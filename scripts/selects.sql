--1) Consulta de sinistros por tipo de imóvel e valor médio de sinistro:
SELECT i.tipo_imovel, COUNT(s.id_sinistro) AS total_sinistros, ROUND(AVG(s.valor_sinistro),2) AS valor_medio_sinistro
FROM imovel i
LEFT JOIN apolice a ON i.id_imovel = a.id_imovel
LEFT JOIN sinistro s ON a.id_apolice = s.id_apolice
GROUP BY i.tipo_imovel
ORDER BY total_sinistros DESC;

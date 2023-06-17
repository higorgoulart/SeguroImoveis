--1) Consulta de sinistros por tipo de imóvel e valor médio de sinistro:
SELECT i.tipo_imovel, COUNT(s.id_sinistro) AS total_sinistros, ROUND(AVG(s.valor_sinistro),2) AS valor_medio_sinistro
FROM imovel i
LEFT JOIN apolice a ON i.id_imovel = a.id_imovel
LEFT JOIN sinistro s ON a.id_apolice = s.id_apolice
GROUP BY i.tipo_imovel
ORDER BY total_sinistros DESC;

--2) Consulta de pagamentos atrasados por apólice: 
--Essa consulta lista os pagamentos que foram realizados após a data de término da apólice, indicando possíveis pagamentos atrasados. Os resultados são ordenados pelo ID da apólice e pela data de pagamento.
SELECT a.id_apolice, a.dt_inicio, a.dt_termino, p.dt_pagamento, p.valor_pagamento
FROM apolice a
JOIN pagamento p ON a.id_apolice = p.id_apolice
WHERE p.dt_pagamento > a.dt_termino
ORDER BY a.id_apolice, p.dt_pagamento;
CREATE TABLE `cliente` (
  `id_cliente` int PRIMARY KEY,
  `nome` varchar(255),
  `sobrenome` varchar(255),
  `dt_nasc` date,
  `endereco` varchar(255),
  `telefone` varchar(255),
  `email` varchar(255)
);

CREATE TABLE `imovel` (
  `id_imovel` int PRIMARY KEY,
  `id_proprietario` int,
  `id_inquilino` int,
  `endereco` varchar(255),
  `tipo_imovel` varchar(255),
  `valor_imovel` decimal,
  `area_imovel` decimal,
  `ano_construcao` int
);

CREATE TABLE `apolice` (
  `id_apolice` int PRIMARY KEY,
  `id_imovel` int,
  `dt_inicio` date,
  `dt_termino` date,
  `valor_apolice` decimal
);

CREATE TABLE `cobertura` (
  `id_cobertura` int PRIMARY KEY,
  `descricao` varchar(255),
  `valor` decimal
);

CREATE TABLE `apolice_cobertura` (
  `id_apolice` int,
  `id_cobertura` int
);

CREATE TABLE `sinistro` (
  `id_sinistro` int PRIMARY KEY,
  `id_apolice` int,
  `dt_sinistro` date,
  `descricao` varchar(255),
  `valor_sinistro` decimal
);

CREATE TABLE `pagamento` (
  `id_pagamento` int PRIMARY KEY,
  `id_apolice` int,
  `dt_pagamento` date,
  `valor_pagamento` decimal
);

CREATE TABLE `avaliacao` (
  `id_avaliacao` int PRIMARY KEY,
  `id_imovel` int,
  `dt_avaliacao` date,
  `valor_avaliado` decimal
);

ALTER TABLE `imovel` ADD FOREIGN KEY (`id_proprietario`) REFERENCES `cliente` (`id_cliente`);

ALTER TABLE `imovel` ADD FOREIGN KEY (`id_inquilino`) REFERENCES `cliente` (`id_cliente`);

ALTER TABLE `apolice` ADD FOREIGN KEY (`id_imovel`) REFERENCES `imovel` (`id_imovel`);

ALTER TABLE `apolice_cobertura` ADD FOREIGN KEY (`id_apolice`) REFERENCES `apolice` (`id_apolice`);

ALTER TABLE `apolice_cobertura` ADD FOREIGN KEY (`id_cobertura`) REFERENCES `cobertura` (`id_cobertura`);

ALTER TABLE `sinistro` ADD FOREIGN KEY (`id_apolice`) REFERENCES `apolice` (`id_apolice`);

ALTER TABLE `pagamento` ADD FOREIGN KEY (`id_apolice`) REFERENCES `apolice` (`id_apolice`);

ALTER TABLE `avaliacao` ADD FOREIGN KEY (`id_imovel`) REFERENCES `imovel` (`id_imovel`);

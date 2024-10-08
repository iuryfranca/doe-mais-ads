create database bd_doe_mais_ads;

use bd_doe_mais_ads;

create table entidade
(
    id            int primary key  auto_increment,
    nome          varchar(50),
    nome_fantasia varchar(50),
    cpf           varchar(14),
    cnpj          varchar(18),
    email         varchar(100) not null,
    telefone      varchar(16),
    is_pessoa_fisica boolean not null,
    created_at    TIMESTAMP
);

create table item
(
    id         int primary key  auto_increment,
    nome       varchar(50) not null,
    descricao  varchar(400),
    created_at TIMESTAMP
);

create table campanha_doacao
(
    id            int primary key  auto_increment,
    nome          varchar(50) not null,
    descricao     varchar(400),
    data_inicio   date not null,
    data_fim      date,

    id_criador_fk int         not null,
    foreign key (id_criador_fk) references entidade (id),
    created_at    TIMESTAMP
);

create table doacao
(
    id                       int primary key auto_increment,
    descricao                varchar(400),
    id_entidade_doador_fk    int,
    created_at               TIMESTAMP,

    foreign key (id_entidade_doador_fk) references entidade (id),
    id_entidade_recebedor_fk int,
    foreign key (id_entidade_recebedor_fk) references entidade (id),
    id_campanha_doacao_fk    int,
    foreign key (id_campanha_doacao_fk) references campanha_doacao (id)
);

create table item_doacao
(
    id           int primary key  auto_increment,
    quantidade   int,
    id_doacao_fk int,
    created_at   TIMESTAMP,

    foreign key (id_doacao_fk) references doacao (id),
    id_item_fk   int,
    foreign key (id_item_fk) references item (id)
);

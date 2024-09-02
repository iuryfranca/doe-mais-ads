create database bd_doe_mais_ads;

use bd_doe_mais_ads;

create table entidade
(
    id            int primary key,
    nome          varchar(50) not null,
    nome_fantasia varchar(50),
    cpf           varchar(11),
    cnpj          varchar(14),
    email         varchar(50) not null,
    telefone      varchar(11),
    is_pessoa_fisica boolean not null,
    created_at    timestamp default current_timestamp
);

create table item
(
    id         int primary key,
    nome       varchar(50) not null,
    descricao  varchar(400),
    created_at timestamp default current_timestamp
);

create table campanha
(
    id            int primary key,
    nome          varchar(50) not null,
    descricao     varchar(400),
    data_inicio   date        not null,
    data_fim      date,

    id_criador_fk int         not null,
    foreign key (id_criador_fk) references entidade (id),
    created_at    timestamp default current_timestamp
);

create table doacao
(
    id                       int primary key,
    descricao                varchar(400),
    id_entidade_doador_fk    int,
    foreign key (id_entidade_doador_fk) references entidade (id),
    id_entidade_recebedor_fk int,
    foreign key (id_entidade_recebedor_fk) references entidade (id),
    id_campanha_doacao_fk    int,
    foreign key (id_campanha_doacao_fk) references campanha (id)
);

create table item_doacao
(
    id           int primary key,
    quantidade   int,
    id_doacao_fk int,
    foreign key (id_doacao_fk) references doacao (id),
    id_item_fk   int,
    foreign key (id_item_fk) references item (id)
);
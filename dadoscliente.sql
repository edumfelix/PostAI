-- public.dadoscliente definição

-- Drop table

-- DROP TABLE public.dadoscliente;

CREATE TABLE public.dadoscliente (
	id serial4 NOT NULL,
	nome varchar(255) NOT NULL,
	telefone varchar(20) NULL,
	site varchar(255) NULL,
	cores jsonb NULL,
	logo bytea NULL,
	segmento varchar(100) NOT NULL,
	descricao text NULL,
	publicoalvo text NULL,
	faixapreco varchar(50) NULL,
	id_user text NULL,
	CONSTRAINT dadoscliente_pkey PRIMARY KEY (id),
	CONSTRAINT dadoscliente_id_user_fkey FOREIGN KEY (id_user) REFERENCES public."AspNetUsers"("Id")
);
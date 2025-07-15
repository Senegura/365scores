CREATE DATABASE audit

CREATE TABLE public.kafka (
	id int GENERATED ALWAYS AS IDENTITY NOT NULL,
	inserted timestamp NOT NULL,
	"Data" json NOT NULL,
	CONSTRAINT kafka_pk PRIMARY KEY (id)
);

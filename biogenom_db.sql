--
-- PostgreSQL database dump
--

-- Dumped from database version 16.9 (Ubuntu 16.9-0ubuntu0.24.04.1)
-- Dumped by pg_dump version 16.8 (Homebrew)

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

DROP DATABASE IF EXISTS postgres;
--
-- Name: postgres; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE postgres WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'C.UTF-8';


ALTER DATABASE postgres OWNER TO postgres;

\connect postgres

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: DATABASE postgres; Type: COMMENT; Schema: -; Owner: postgres
--

COMMENT ON DATABASE postgres IS 'default administrative connection database';


--
-- Name: biogenom; Type: SCHEMA; Schema: -; Owner: postgres
--

CREATE SCHEMA biogenom;


ALTER SCHEMA biogenom OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: nutrients; Type: TABLE; Schema: biogenom; Owner: postgres
--

CREATE TABLE biogenom.nutrients (
    id integer NOT NULL,
    name character varying(10) NOT NULL,
    scientific_name character varying(15),
    unit_id integer NOT NULL,
    nutrients_id integer NOT NULL
);


ALTER TABLE biogenom.nutrients OWNER TO postgres;

--
-- Name: nutrients_id_seq; Type: SEQUENCE; Schema: biogenom; Owner: postgres
--

CREATE SEQUENCE biogenom.nutrients_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE biogenom.nutrients_id_seq OWNER TO postgres;

--
-- Name: nutrients_id_seq; Type: SEQUENCE OWNED BY; Schema: biogenom; Owner: postgres
--

ALTER SEQUENCE biogenom.nutrients_id_seq OWNED BY biogenom.nutrients.id;


--
-- Name: nutrients_standards; Type: TABLE; Schema: biogenom; Owner: postgres
--

CREATE TABLE biogenom.nutrients_standards (
    id integer NOT NULL,
    min_norm numeric(10,2),
    max_norm numeric(10,2),
    recommended_value numeric(10,2),
    is_in_range boolean DEFAULT false NOT NULL
);


ALTER TABLE biogenom.nutrients_standards OWNER TO postgres;

--
-- Name: nutrients_standards_id_seq; Type: SEQUENCE; Schema: biogenom; Owner: postgres
--

CREATE SEQUENCE biogenom.nutrients_standards_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE biogenom.nutrients_standards_id_seq OWNER TO postgres;

--
-- Name: nutrients_standards_id_seq; Type: SEQUENCE OWNED BY; Schema: biogenom; Owner: postgres
--

ALTER SEQUENCE biogenom.nutrients_standards_id_seq OWNED BY biogenom.nutrients_standards.id;


--
-- Name: nutrition_source; Type: TABLE; Schema: biogenom; Owner: postgres
--

CREATE TABLE biogenom.nutrition_source (
    id integer NOT NULL,
    current_nutrition numeric(10,2),
    supplement_nutrition numeric(10,2),
    food_nutrition numeric(10,2),
    is_delete boolean DEFAULT false
);


ALTER TABLE biogenom.nutrition_source OWNER TO postgres;

--
-- Name: nutrition_source_id_seq; Type: SEQUENCE; Schema: biogenom; Owner: postgres
--

CREATE SEQUENCE biogenom.nutrition_source_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE biogenom.nutrition_source_id_seq OWNER TO postgres;

--
-- Name: nutrition_source_id_seq; Type: SEQUENCE OWNED BY; Schema: biogenom; Owner: postgres
--

ALTER SEQUENCE biogenom.nutrition_source_id_seq OWNED BY biogenom.nutrition_source.id;


--
-- Name: units; Type: TABLE; Schema: biogenom; Owner: postgres
--

CREATE TABLE biogenom.units (
    id integer NOT NULL,
    name character varying(10) NOT NULL
);


ALTER TABLE biogenom.units OWNER TO postgres;

--
-- Name: units_id_seq; Type: SEQUENCE; Schema: biogenom; Owner: postgres
--

CREATE SEQUENCE biogenom.units_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE biogenom.units_id_seq OWNER TO postgres;

--
-- Name: units_id_seq; Type: SEQUENCE OWNED BY; Schema: biogenom; Owner: postgres
--

ALTER SEQUENCE biogenom.units_id_seq OWNED BY biogenom.units.id;


--
-- Name: user_nutrient_log; Type: TABLE; Schema: biogenom; Owner: postgres
--

CREATE TABLE biogenom.user_nutrient_log (
    id integer NOT NULL,
    nutrition_source_id integer NOT NULL,
    nutrient_id integer NOT NULL,
    user_id character varying(200) NOT NULL,
    create_date timestamp with time zone
);


ALTER TABLE biogenom.user_nutrient_log OWNER TO postgres;

--
-- Name: user_nutrient_log_id_seq; Type: SEQUENCE; Schema: biogenom; Owner: postgres
--

CREATE SEQUENCE biogenom.user_nutrient_log_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE biogenom.user_nutrient_log_id_seq OWNER TO postgres;

--
-- Name: user_nutrient_log_id_seq; Type: SEQUENCE OWNED BY; Schema: biogenom; Owner: postgres
--

ALTER SEQUENCE biogenom.user_nutrient_log_id_seq OWNED BY biogenom.user_nutrient_log.id;


--
-- Name: nutrients id; Type: DEFAULT; Schema: biogenom; Owner: postgres
--

ALTER TABLE ONLY biogenom.nutrients ALTER COLUMN id SET DEFAULT nextval('biogenom.nutrients_id_seq'::regclass);


--
-- Name: nutrients_standards id; Type: DEFAULT; Schema: biogenom; Owner: postgres
--

ALTER TABLE ONLY biogenom.nutrients_standards ALTER COLUMN id SET DEFAULT nextval('biogenom.nutrients_standards_id_seq'::regclass);


--
-- Name: nutrition_source id; Type: DEFAULT; Schema: biogenom; Owner: postgres
--

ALTER TABLE ONLY biogenom.nutrition_source ALTER COLUMN id SET DEFAULT nextval('biogenom.nutrition_source_id_seq'::regclass);


--
-- Name: units id; Type: DEFAULT; Schema: biogenom; Owner: postgres
--

ALTER TABLE ONLY biogenom.units ALTER COLUMN id SET DEFAULT nextval('biogenom.units_id_seq'::regclass);


--
-- Name: user_nutrient_log id; Type: DEFAULT; Schema: biogenom; Owner: postgres
--

ALTER TABLE ONLY biogenom.user_nutrient_log ALTER COLUMN id SET DEFAULT nextval('biogenom.user_nutrient_log_id_seq'::regclass);


--
-- Data for Name: nutrients; Type: TABLE DATA; Schema: biogenom; Owner: postgres
--

INSERT INTO biogenom.nutrients (id, name, scientific_name, unit_id, nutrients_id) VALUES (1, 'Vitamin C', 'Ascorbic Acid', 1, 1);
INSERT INTO biogenom.nutrients (id, name, scientific_name, unit_id, nutrients_id) VALUES (2, 'Iron', 'Ferrum', 2, 2);
INSERT INTO biogenom.nutrients (id, name, scientific_name, unit_id, nutrients_id) VALUES (3, 'Vitamin D', 'Cholecalciferol', 3, 3);


--
-- Data for Name: nutrients_standards; Type: TABLE DATA; Schema: biogenom; Owner: postgres
--

INSERT INTO biogenom.nutrients_standards (id, min_norm, max_norm, recommended_value, is_in_range) VALUES (1, 10.00, 50.00, 30.00, false);
INSERT INTO biogenom.nutrients_standards (id, min_norm, max_norm, recommended_value, is_in_range) VALUES (2, 5.00, 20.00, 15.00, true);
INSERT INTO biogenom.nutrients_standards (id, min_norm, max_norm, recommended_value, is_in_range) VALUES (3, 100.00, 500.00, 300.00, false);
INSERT INTO biogenom.nutrients_standards (id, min_norm, max_norm, recommended_value, is_in_range) VALUES (4, 10.00, 50.00, 30.00, false);
INSERT INTO biogenom.nutrients_standards (id, min_norm, max_norm, recommended_value, is_in_range) VALUES (5, 5.00, 20.00, 15.00, true);
INSERT INTO biogenom.nutrients_standards (id, min_norm, max_norm, recommended_value, is_in_range) VALUES (6, 100.00, 500.00, 300.00, false);


--
-- Data for Name: nutrition_source; Type: TABLE DATA; Schema: biogenom; Owner: postgres
--

INSERT INTO biogenom.nutrition_source (id, current_nutrition, supplement_nutrition, food_nutrition, is_delete) VALUES (1, 20.50, 5.00, 15.50, false);
INSERT INTO biogenom.nutrition_source (id, current_nutrition, supplement_nutrition, food_nutrition, is_delete) VALUES (2, 10.00, 2.00, 8.00, false);


--
-- Data for Name: units; Type: TABLE DATA; Schema: biogenom; Owner: postgres
--

INSERT INTO biogenom.units (id, name) VALUES (1, 'mg');
INSERT INTO biogenom.units (id, name) VALUES (2, 'g');
INSERT INTO biogenom.units (id, name) VALUES (3, 'IU');
INSERT INTO biogenom.units (id, name) VALUES (4, 'mg');
INSERT INTO biogenom.units (id, name) VALUES (5, 'g');
INSERT INTO biogenom.units (id, name) VALUES (6, 'IU');


--
-- Data for Name: user_nutrient_log; Type: TABLE DATA; Schema: biogenom; Owner: postgres
--

INSERT INTO biogenom.user_nutrient_log (id, nutrition_source_id, nutrient_id, user_id, create_date) VALUES (1, 1, 1, 'user123', '2025-07-13 18:35:25.625066+00');
INSERT INTO biogenom.user_nutrient_log (id, nutrition_source_id, nutrient_id, user_id, create_date) VALUES (2, 2, 2, 'user123', '2025-07-13 18:35:25.625066+00');


--
-- Name: nutrients_id_seq; Type: SEQUENCE SET; Schema: biogenom; Owner: postgres
--

SELECT pg_catalog.setval('biogenom.nutrients_id_seq', 3, true);


--
-- Name: nutrients_standards_id_seq; Type: SEQUENCE SET; Schema: biogenom; Owner: postgres
--

SELECT pg_catalog.setval('biogenom.nutrients_standards_id_seq', 6, true);


--
-- Name: nutrition_source_id_seq; Type: SEQUENCE SET; Schema: biogenom; Owner: postgres
--

SELECT pg_catalog.setval('biogenom.nutrition_source_id_seq', 2, true);


--
-- Name: units_id_seq; Type: SEQUENCE SET; Schema: biogenom; Owner: postgres
--

SELECT pg_catalog.setval('biogenom.units_id_seq', 6, true);


--
-- Name: user_nutrient_log_id_seq; Type: SEQUENCE SET; Schema: biogenom; Owner: postgres
--

SELECT pg_catalog.setval('biogenom.user_nutrient_log_id_seq', 2, true);


--
-- Name: nutrients nutrients_pkey; Type: CONSTRAINT; Schema: biogenom; Owner: postgres
--

ALTER TABLE ONLY biogenom.nutrients
    ADD CONSTRAINT nutrients_pkey PRIMARY KEY (id);


--
-- Name: nutrients_standards nutrients_standards_pkey; Type: CONSTRAINT; Schema: biogenom; Owner: postgres
--

ALTER TABLE ONLY biogenom.nutrients_standards
    ADD CONSTRAINT nutrients_standards_pkey PRIMARY KEY (id);


--
-- Name: nutrition_source nutrition_source_pkey; Type: CONSTRAINT; Schema: biogenom; Owner: postgres
--

ALTER TABLE ONLY biogenom.nutrition_source
    ADD CONSTRAINT nutrition_source_pkey PRIMARY KEY (id);


--
-- Name: units units_pkey; Type: CONSTRAINT; Schema: biogenom; Owner: postgres
--

ALTER TABLE ONLY biogenom.units
    ADD CONSTRAINT units_pkey PRIMARY KEY (id);


--
-- Name: user_nutrient_log user_nutrient_log_nutrition_source_id_nutrient_id_key; Type: CONSTRAINT; Schema: biogenom; Owner: postgres
--

ALTER TABLE ONLY biogenom.user_nutrient_log
    ADD CONSTRAINT user_nutrient_log_nutrition_source_id_nutrient_id_key UNIQUE (nutrition_source_id, nutrient_id);


--
-- Name: user_nutrient_log user_nutrient_log_pkey; Type: CONSTRAINT; Schema: biogenom; Owner: postgres
--

ALTER TABLE ONLY biogenom.user_nutrient_log
    ADD CONSTRAINT user_nutrient_log_pkey PRIMARY KEY (id);


--
-- Name: user_nutrient_log fk_nsn_nutrient; Type: FK CONSTRAINT; Schema: biogenom; Owner: postgres
--

ALTER TABLE ONLY biogenom.user_nutrient_log
    ADD CONSTRAINT fk_nsn_nutrient FOREIGN KEY (nutrient_id) REFERENCES biogenom.nutrients(id);


--
-- Name: user_nutrient_log fk_nsn_nutrition; Type: FK CONSTRAINT; Schema: biogenom; Owner: postgres
--

ALTER TABLE ONLY biogenom.user_nutrient_log
    ADD CONSTRAINT fk_nsn_nutrition FOREIGN KEY (nutrition_source_id) REFERENCES biogenom.nutrition_source(id);


--
-- Name: nutrients fk_nutrients_standart; Type: FK CONSTRAINT; Schema: biogenom; Owner: postgres
--

ALTER TABLE ONLY biogenom.nutrients
    ADD CONSTRAINT fk_nutrients_standart FOREIGN KEY (nutrients_id) REFERENCES biogenom.nutrients_standards(id);


--
-- Name: nutrients fk_vitamins_units; Type: FK CONSTRAINT; Schema: biogenom; Owner: postgres
--

ALTER TABLE ONLY biogenom.nutrients
    ADD CONSTRAINT fk_vitamins_units FOREIGN KEY (unit_id) REFERENCES biogenom.units(id);


--
-- PostgreSQL database dump complete
--


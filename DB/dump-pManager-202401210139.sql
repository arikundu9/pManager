--
-- PostgreSQL database dump
--

-- Dumped from database version 15.5
-- Dumped by pg_dump version 15.5

-- Started on 2024-01-21 01:39:20 IST

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

DROP DATABASE "pManager";
--
-- TOC entry 4404 (class 1262 OID 17044)
-- Name: pManager; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE "pManager" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'en_IN.UTF-8';


ALTER DATABASE "pManager" OWNER TO postgres;

\connect "pManager"

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
-- TOC entry 4 (class 2615 OID 2200)
-- Name: public; Type: SCHEMA; Schema: -; Owner: pg_database_owner
--

CREATE SCHEMA public;


ALTER SCHEMA public OWNER TO pg_database_owner;

--
-- TOC entry 4405 (class 0 OID 0)
-- Dependencies: 4
-- Name: SCHEMA public; Type: COMMENT; Schema: -; Owner: pg_database_owner
--

COMMENT ON SCHEMA public IS 'standard public schema';


--
-- TOC entry 224 (class 1255 OID 17045)
-- Name: create_table(character varying); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.create_table(IN tabname character varying)
    LANGUAGE plpgsql
    AS $$
    begin
        IF tabname <> '' THEN
            EXECUTE concat(
                        'CREATE TABLE public.' || tabname || ' (' ,
                        'id bigserial NOT NULL,',
                        'id bigserial NOT NULL,',
                        'created_at timestamp without time zone NOT NULL,',
                        'updated_at timestamp without time zone NULL,',
                        'created_by bigint NOT NULL,',
                        'updated_by bigint NULL,',
                        'CONSTRAINT ' || tabname || '_pk PRIMARY KEY (id)',
                        ');'
                    );
        END IF;
    END;
$$;


ALTER PROCEDURE public.create_table(IN tabname character varying) OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 214 (class 1259 OID 17046)
-- Name: board; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.board (
    id bigint NOT NULL,
    created_at timestamp without time zone DEFAULT now() NOT NULL,
    updated_at timestamp without time zone,
    created_by bigint NOT NULL,
    updated_by bigint,
    name character(30) NOT NULL
);


ALTER TABLE public.board OWNER TO postgres;

--
-- TOC entry 215 (class 1259 OID 17050)
-- Name: board_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.board_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.board_id_seq OWNER TO postgres;

--
-- TOC entry 4406 (class 0 OID 0)
-- Dependencies: 215
-- Name: board_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.board_id_seq OWNED BY public.board.id;


--
-- TOC entry 216 (class 1259 OID 17051)
-- Name: card; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.card (
    id bigint NOT NULL,
    created_at timestamp without time zone DEFAULT now() NOT NULL,
    updated_at timestamp without time zone,
    created_by bigint NOT NULL,
    updated_by bigint,
    parent_list_id bigint NOT NULL,
    order_value bigint NOT NULL,
    body character varying
);


ALTER TABLE public.card OWNER TO postgres;

--
-- TOC entry 217 (class 1259 OID 17055)
-- Name: card_assigned_to_user; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.card_assigned_to_user (
    id bigint NOT NULL,
    created_at timestamp without time zone DEFAULT now() NOT NULL,
    updated_at timestamp without time zone,
    created_by bigint NOT NULL,
    updated_by bigint,
    card_id bigint NOT NULL,
    user_id bigint NOT NULL
);


ALTER TABLE public.card_assigned_to_user OWNER TO postgres;

--
-- TOC entry 218 (class 1259 OID 17059)
-- Name: card_assigned_to_user_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.card_assigned_to_user_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.card_assigned_to_user_id_seq OWNER TO postgres;

--
-- TOC entry 4407 (class 0 OID 0)
-- Dependencies: 218
-- Name: card_assigned_to_user_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.card_assigned_to_user_id_seq OWNED BY public.card_assigned_to_user.id;


--
-- TOC entry 219 (class 1259 OID 17060)
-- Name: card_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.card_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.card_id_seq OWNER TO postgres;

--
-- TOC entry 4408 (class 0 OID 0)
-- Dependencies: 219
-- Name: card_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.card_id_seq OWNED BY public.card.id;


--
-- TOC entry 220 (class 1259 OID 17061)
-- Name: list; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.list (
    id bigint NOT NULL,
    created_at timestamp without time zone DEFAULT now() NOT NULL,
    updated_at timestamp without time zone,
    created_by bigint NOT NULL,
    updated_by bigint,
    parent_board_id bigint NOT NULL,
    order_value bigint NOT NULL,
    name character(30) NOT NULL
);


ALTER TABLE public.list OWNER TO postgres;

--
-- TOC entry 221 (class 1259 OID 17065)
-- Name: list_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.list_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.list_id_seq OWNER TO postgres;

--
-- TOC entry 4409 (class 0 OID 0)
-- Dependencies: 221
-- Name: list_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.list_id_seq OWNED BY public.list.id;


--
-- TOC entry 222 (class 1259 OID 17066)
-- Name: user; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."user" (
    id bigint NOT NULL,
    created_at timestamp without time zone DEFAULT now() NOT NULL,
    updated_at timestamp without time zone,
    created_by bigint NOT NULL,
    updated_by bigint
);


ALTER TABLE public."user" OWNER TO postgres;

--
-- TOC entry 223 (class 1259 OID 17070)
-- Name: user_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.user_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.user_id_seq OWNER TO postgres;

--
-- TOC entry 4410 (class 0 OID 0)
-- Dependencies: 223
-- Name: user_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.user_id_seq OWNED BY public."user".id;


--
-- TOC entry 4219 (class 2604 OID 17071)
-- Name: board id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.board ALTER COLUMN id SET DEFAULT nextval('public.board_id_seq'::regclass);


--
-- TOC entry 4221 (class 2604 OID 17072)
-- Name: card id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.card ALTER COLUMN id SET DEFAULT nextval('public.card_id_seq'::regclass);


--
-- TOC entry 4223 (class 2604 OID 17073)
-- Name: card_assigned_to_user id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.card_assigned_to_user ALTER COLUMN id SET DEFAULT nextval('public.card_assigned_to_user_id_seq'::regclass);


--
-- TOC entry 4225 (class 2604 OID 17074)
-- Name: list id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.list ALTER COLUMN id SET DEFAULT nextval('public.list_id_seq'::regclass);


--
-- TOC entry 4227 (class 2604 OID 17075)
-- Name: user id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."user" ALTER COLUMN id SET DEFAULT nextval('public.user_id_seq'::regclass);


--
-- TOC entry 4389 (class 0 OID 17046)
-- Dependencies: 214
-- Data for Name: board; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.board VALUES (4, '2023-12-27 16:24:02.380918', '-infinity', 0, 0, 'string                        ');
INSERT INTO public.board VALUES (5, '2023-12-27 16:24:19.738564', '-infinity', 0, 0, 'string                        ');
INSERT INTO public.board VALUES (6, '2023-12-27 16:59:15.246443', NULL, 0, NULL, 'string                        ');
INSERT INTO public.board VALUES (7, '2023-12-27 16:59:53.506945', NULL, 0, NULL, 'string                        ');
INSERT INTO public.board VALUES (8, '2023-12-28 11:36:29.778123', NULL, 0, NULL, 'string                        ');
INSERT INTO public.board VALUES (9, '2023-12-28 12:08:51.011772', NULL, 0, NULL, 'string                        ');
INSERT INTO public.board VALUES (10, '2023-12-28 12:10:06.227451', NULL, 0, NULL, 'string                        ');
INSERT INTO public.board VALUES (11, '2023-12-28 12:10:11.622459', NULL, 0, NULL, 'strixxdvdcdsfdfng             ');
INSERT INTO public.board VALUES (12, '2023-12-28 12:10:19.230276', NULL, 0, NULL, 'strixxdvdcdsfdfng             ');
INSERT INTO public.board VALUES (13, '2023-12-28 12:11:52.6049', NULL, 1, NULL, 'aaaaaa                        ');
INSERT INTO public.board VALUES (14, '2024-01-21 00:21:42.011923', NULL, 1, NULL, 'string1                       ');


--
-- TOC entry 4391 (class 0 OID 17051)
-- Dependencies: 216
-- Data for Name: card; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 4392 (class 0 OID 17055)
-- Dependencies: 217
-- Data for Name: card_assigned_to_user; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 4395 (class 0 OID 17061)
-- Dependencies: 220
-- Data for Name: list; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.list VALUES (3, '2024-01-21 01:35:44.45922', NULL, 1, NULL, 14, 0, 'string                        ');


--
-- TOC entry 4397 (class 0 OID 17066)
-- Dependencies: 222
-- Data for Name: user; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 4411 (class 0 OID 0)
-- Dependencies: 215
-- Name: board_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.board_id_seq', 14, true);


--
-- TOC entry 4412 (class 0 OID 0)
-- Dependencies: 218
-- Name: card_assigned_to_user_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.card_assigned_to_user_id_seq', 1, false);


--
-- TOC entry 4413 (class 0 OID 0)
-- Dependencies: 219
-- Name: card_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.card_id_seq', 1, false);


--
-- TOC entry 4414 (class 0 OID 0)
-- Dependencies: 221
-- Name: list_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.list_id_seq', 3, true);


--
-- TOC entry 4415 (class 0 OID 0)
-- Dependencies: 223
-- Name: user_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.user_id_seq', 1, false);


--
-- TOC entry 4230 (class 2606 OID 17077)
-- Name: board board_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.board
    ADD CONSTRAINT board_pk PRIMARY KEY (id);


--
-- TOC entry 4234 (class 2606 OID 17079)
-- Name: card_assigned_to_user card_assigned_to_user_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.card_assigned_to_user
    ADD CONSTRAINT card_assigned_to_user_pk PRIMARY KEY (id);


--
-- TOC entry 4236 (class 2606 OID 17081)
-- Name: card_assigned_to_user card_assigned_to_user_pk_carduser; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.card_assigned_to_user
    ADD CONSTRAINT card_assigned_to_user_pk_carduser UNIQUE (card_id, user_id);


--
-- TOC entry 4232 (class 2606 OID 17083)
-- Name: card card_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.card
    ADD CONSTRAINT card_pk PRIMARY KEY (id);


--
-- TOC entry 4238 (class 2606 OID 17085)
-- Name: list list_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.list
    ADD CONSTRAINT list_pk PRIMARY KEY (id);


--
-- TOC entry 4240 (class 2606 OID 17087)
-- Name: user user_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."user"
    ADD CONSTRAINT user_pk PRIMARY KEY (id);


--
-- TOC entry 4244 (class 2606 OID 17088)
-- Name: card_assigned_to_user card_assigned_to_user_fk_card; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.card_assigned_to_user
    ADD CONSTRAINT card_assigned_to_user_fk_card FOREIGN KEY (card_id) REFERENCES public.card(id);


--
-- TOC entry 4245 (class 2606 OID 17093)
-- Name: card_assigned_to_user card_assigned_to_user_fk_user; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.card_assigned_to_user
    ADD CONSTRAINT card_assigned_to_user_fk_user FOREIGN KEY (user_id) REFERENCES public."user"(id);


--
-- TOC entry 4241 (class 2606 OID 17098)
-- Name: card card_fk_created_by; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.card
    ADD CONSTRAINT card_fk_created_by FOREIGN KEY (created_by) REFERENCES public."user"(id);


--
-- TOC entry 4242 (class 2606 OID 17103)
-- Name: card card_fk_in_list; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.card
    ADD CONSTRAINT card_fk_in_list FOREIGN KEY (parent_list_id) REFERENCES public.list(id);


--
-- TOC entry 4243 (class 2606 OID 17108)
-- Name: card card_fk_updated_by; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.card
    ADD CONSTRAINT card_fk_updated_by FOREIGN KEY (updated_by) REFERENCES public."user"(id);


--
-- TOC entry 4246 (class 2606 OID 17113)
-- Name: list list_fk_board; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.list
    ADD CONSTRAINT list_fk_board FOREIGN KEY (parent_board_id) REFERENCES public.board(id);


-- Completed on 2024-01-21 01:39:20 IST

--
-- PostgreSQL database dump complete
--


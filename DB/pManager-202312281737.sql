--
-- PostgreSQL database dump
--

-- Dumped from database version 15.2
-- Dumped by pg_dump version 15.2

-- Started on 2023-12-28 17:37:10

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
-- TOC entry 3379 (class 1262 OID 75052)
-- Name: pManager; Type: DATABASE; Schema: -; Owner: -
--

CREATE DATABASE "pManager" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'English_India.1252';


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
-- Name: public; Type: SCHEMA; Schema: -; Owner: -
--

CREATE SCHEMA public;


--
-- TOC entry 3380 (class 0 OID 0)
-- Dependencies: 4
-- Name: SCHEMA public; Type: COMMENT; Schema: -; Owner: -
--

COMMENT ON SCHEMA public IS 'standard public schema';


--
-- TOC entry 224 (class 1255 OID 75053)
-- Name: create_table(character varying); Type: PROCEDURE; Schema: public; Owner: -
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


SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 214 (class 1259 OID 75054)
-- Name: board; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.board (
    id bigint NOT NULL,
    created_at timestamp without time zone DEFAULT now() NOT NULL,
    updated_at timestamp without time zone,
    created_by bigint NOT NULL,
    updated_by bigint,
    name character(30) NOT NULL
);


--
-- TOC entry 215 (class 1259 OID 75058)
-- Name: board_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.board_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 3381 (class 0 OID 0)
-- Dependencies: 215
-- Name: board_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.board_id_seq OWNED BY public.board.id;


--
-- TOC entry 216 (class 1259 OID 75059)
-- Name: card; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.card (
    id bigint NOT NULL,
    created_at timestamp without time zone DEFAULT now() NOT NULL,
    updated_at timestamp without time zone,
    created_by bigint NOT NULL,
    updated_by bigint,
    parent_list_id bigint NOT NULL,
    order_value bigint NOT NULL
);


--
-- TOC entry 217 (class 1259 OID 75063)
-- Name: card_assigned_to_user; Type: TABLE; Schema: public; Owner: -
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


--
-- TOC entry 218 (class 1259 OID 75067)
-- Name: card_assigned_to_user_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.card_assigned_to_user_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 3382 (class 0 OID 0)
-- Dependencies: 218
-- Name: card_assigned_to_user_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.card_assigned_to_user_id_seq OWNED BY public.card_assigned_to_user.id;


--
-- TOC entry 219 (class 1259 OID 75068)
-- Name: card_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.card_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 3383 (class 0 OID 0)
-- Dependencies: 219
-- Name: card_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.card_id_seq OWNED BY public.card.id;


--
-- TOC entry 220 (class 1259 OID 75069)
-- Name: list; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.list (
    id bigint NOT NULL,
    created_at timestamp without time zone DEFAULT now() NOT NULL,
    updated_at timestamp without time zone,
    created_by bigint NOT NULL,
    updated_by bigint,
    parent_board_id bigint NOT NULL,
    order_value bigint NOT NULL
);


--
-- TOC entry 221 (class 1259 OID 75073)
-- Name: list_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.list_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 3384 (class 0 OID 0)
-- Dependencies: 221
-- Name: list_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.list_id_seq OWNED BY public.list.id;


--
-- TOC entry 222 (class 1259 OID 75074)
-- Name: user; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."user" (
    id bigint NOT NULL,
    created_at timestamp without time zone DEFAULT now() NOT NULL,
    updated_at timestamp without time zone,
    created_by bigint NOT NULL,
    updated_by bigint
);


--
-- TOC entry 223 (class 1259 OID 75078)
-- Name: user_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.user_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 3385 (class 0 OID 0)
-- Dependencies: 223
-- Name: user_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.user_id_seq OWNED BY public."user".id;


--
-- TOC entry 3194 (class 2604 OID 75079)
-- Name: board id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.board ALTER COLUMN id SET DEFAULT nextval('public.board_id_seq'::regclass);


--
-- TOC entry 3196 (class 2604 OID 75080)
-- Name: card id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.card ALTER COLUMN id SET DEFAULT nextval('public.card_id_seq'::regclass);


--
-- TOC entry 3198 (class 2604 OID 75081)
-- Name: card_assigned_to_user id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.card_assigned_to_user ALTER COLUMN id SET DEFAULT nextval('public.card_assigned_to_user_id_seq'::regclass);


--
-- TOC entry 3200 (class 2604 OID 75082)
-- Name: list id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.list ALTER COLUMN id SET DEFAULT nextval('public.list_id_seq'::regclass);


--
-- TOC entry 3202 (class 2604 OID 75083)
-- Name: user id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."user" ALTER COLUMN id SET DEFAULT nextval('public.user_id_seq'::regclass);


--
-- TOC entry 3364 (class 0 OID 75054)
-- Dependencies: 214
-- Data for Name: board; Type: TABLE DATA; Schema: public; Owner: -
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


--
-- TOC entry 3366 (class 0 OID 75059)
-- Dependencies: 216
-- Data for Name: card; Type: TABLE DATA; Schema: public; Owner: -
--



--
-- TOC entry 3367 (class 0 OID 75063)
-- Dependencies: 217
-- Data for Name: card_assigned_to_user; Type: TABLE DATA; Schema: public; Owner: -
--



--
-- TOC entry 3370 (class 0 OID 75069)
-- Dependencies: 220
-- Data for Name: list; Type: TABLE DATA; Schema: public; Owner: -
--



--
-- TOC entry 3372 (class 0 OID 75074)
-- Dependencies: 222
-- Data for Name: user; Type: TABLE DATA; Schema: public; Owner: -
--



--
-- TOC entry 3386 (class 0 OID 0)
-- Dependencies: 215
-- Name: board_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public.board_id_seq', 13, true);


--
-- TOC entry 3387 (class 0 OID 0)
-- Dependencies: 218
-- Name: card_assigned_to_user_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public.card_assigned_to_user_id_seq', 1, false);


--
-- TOC entry 3388 (class 0 OID 0)
-- Dependencies: 219
-- Name: card_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public.card_id_seq', 1, false);


--
-- TOC entry 3389 (class 0 OID 0)
-- Dependencies: 221
-- Name: list_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public.list_id_seq', 1, false);


--
-- TOC entry 3390 (class 0 OID 0)
-- Dependencies: 223
-- Name: user_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public.user_id_seq', 1, false);


--
-- TOC entry 3205 (class 2606 OID 75085)
-- Name: board board_pk; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.board
    ADD CONSTRAINT board_pk PRIMARY KEY (id);


--
-- TOC entry 3209 (class 2606 OID 75087)
-- Name: card_assigned_to_user card_assigned_to_user_pk; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.card_assigned_to_user
    ADD CONSTRAINT card_assigned_to_user_pk PRIMARY KEY (id);


--
-- TOC entry 3211 (class 2606 OID 75089)
-- Name: card_assigned_to_user card_assigned_to_user_pk_carduser; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.card_assigned_to_user
    ADD CONSTRAINT card_assigned_to_user_pk_carduser UNIQUE (card_id, user_id);


--
-- TOC entry 3207 (class 2606 OID 75091)
-- Name: card card_pk; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.card
    ADD CONSTRAINT card_pk PRIMARY KEY (id);


--
-- TOC entry 3213 (class 2606 OID 75093)
-- Name: list list_pk; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.list
    ADD CONSTRAINT list_pk PRIMARY KEY (id);


--
-- TOC entry 3215 (class 2606 OID 75095)
-- Name: user user_pk; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."user"
    ADD CONSTRAINT user_pk PRIMARY KEY (id);


--
-- TOC entry 3219 (class 2606 OID 75096)
-- Name: card_assigned_to_user card_assigned_to_user_fk_card; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.card_assigned_to_user
    ADD CONSTRAINT card_assigned_to_user_fk_card FOREIGN KEY (card_id) REFERENCES public.card(id);


--
-- TOC entry 3220 (class 2606 OID 75101)
-- Name: card_assigned_to_user card_assigned_to_user_fk_user; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.card_assigned_to_user
    ADD CONSTRAINT card_assigned_to_user_fk_user FOREIGN KEY (user_id) REFERENCES public."user"(id);


--
-- TOC entry 3216 (class 2606 OID 75106)
-- Name: card card_fk_created_by; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.card
    ADD CONSTRAINT card_fk_created_by FOREIGN KEY (created_by) REFERENCES public."user"(id);


--
-- TOC entry 3217 (class 2606 OID 75111)
-- Name: card card_fk_in_list; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.card
    ADD CONSTRAINT card_fk_in_list FOREIGN KEY (parent_list_id) REFERENCES public.list(id);


--
-- TOC entry 3218 (class 2606 OID 75116)
-- Name: card card_fk_updated_by; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.card
    ADD CONSTRAINT card_fk_updated_by FOREIGN KEY (updated_by) REFERENCES public."user"(id);


--
-- TOC entry 3221 (class 2606 OID 75121)
-- Name: list list_fk_board; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.list
    ADD CONSTRAINT list_fk_board FOREIGN KEY (parent_board_id) REFERENCES public.board(id);


-- Completed on 2023-12-28 17:37:10

--
-- PostgreSQL database dump complete
--


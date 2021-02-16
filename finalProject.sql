PGDMP          1                 y            postgres    13.1    13.1 T               0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false                       0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false                        0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            !           1262    13442    postgres    DATABASE     e   CREATE DATABASE postgres WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'English_Israel.1252';
    DROP DATABASE postgres;
                postgres    false            "           0    0    DATABASE postgres    COMMENT     N   COMMENT ON DATABASE postgres IS 'default administrative connection database';
                   postgres    false    3105                        3079    16384 	   adminpack 	   EXTENSION     A   CREATE EXTENSION IF NOT EXISTS adminpack WITH SCHEMA pg_catalog;
    DROP EXTENSION adminpack;
                   false            #           0    0    EXTENSION adminpack    COMMENT     M   COMMENT ON EXTENSION adminpack IS 'administrative functions for PostgreSQL';
                        false    2            �            1259    16396    administrators    TABLE     �   CREATE TABLE public.administrators (
    id integer NOT NULL,
    first_name text,
    last_name text,
    level integer,
    user_id bigint
);
 "   DROP TABLE public.administrators;
       public         heap    postgres    false            �            1259    16474    administrators_id_seq    SEQUENCE     ~   CREATE SEQUENCE public.administrators_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 ,   DROP SEQUENCE public.administrators_id_seq;
       public          postgres    false    201            $           0    0    administrators_id_seq    SEQUENCE OWNED BY     O   ALTER SEQUENCE public.administrators_id_seq OWNED BY public.administrators.id;
          public          postgres    false    209            �            1259    16426    airline_companies    TABLE     }   CREATE TABLE public.airline_companies (
    id bigint NOT NULL,
    name text,
    country_id integer,
    user_id bigint
);
 %   DROP TABLE public.airline_companies;
       public         heap    postgres    false            �            1259    16477    airline_companies_id_seq    SEQUENCE     �   CREATE SEQUENCE public.airline_companies_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 /   DROP SEQUENCE public.airline_companies_id_seq;
       public          postgres    false    205            %           0    0    airline_companies_id_seq    SEQUENCE OWNED BY     U   ALTER SEQUENCE public.airline_companies_id_seq OWNED BY public.airline_companies.id;
          public          postgres    false    210            �            1259    16406 	   countries    TABLE     J   CREATE TABLE public.countries (
    id integer NOT NULL,
    name text
);
    DROP TABLE public.countries;
       public         heap    postgres    false            �            1259    16480    countries_id_seq    SEQUENCE     y   CREATE SEQUENCE public.countries_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 '   DROP SEQUENCE public.countries_id_seq;
       public          postgres    false    202            &           0    0    countries_id_seq    SEQUENCE OWNED BY     E   ALTER SEQUENCE public.countries_id_seq OWNED BY public.countries.id;
          public          postgres    false    211            �            1259    16450 	   customers    TABLE     �   CREATE TABLE public.customers (
    id bigint NOT NULL,
    first_name text,
    last_name text,
    address text,
    phone_no text,
    credit_card_no text,
    user_id bigint
);
    DROP TABLE public.customers;
       public         heap    postgres    false            �            1259    16483    customers_id_seq    SEQUENCE     y   CREATE SEQUENCE public.customers_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 '   DROP SEQUENCE public.customers_id_seq;
       public          postgres    false    207            '           0    0    customers_id_seq    SEQUENCE OWNED BY     E   ALTER SEQUENCE public.customers_id_seq OWNED BY public.customers.id;
          public          postgres    false    212            �            1259    16421    flights    TABLE     �   CREATE TABLE public.flights (
    id bigint NOT NULL,
    airline_company_id bigint,
    origin_country_id integer,
    destination_country_id integer,
    departure_time date,
    landing_time date,
    remaining_tickets integer
);
    DROP TABLE public.flights;
       public         heap    postgres    false            �            1259    16486    flights_id_seq    SEQUENCE     w   CREATE SEQUENCE public.flights_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 %   DROP SEQUENCE public.flights_id_seq;
       public          postgres    false    204            (           0    0    flights_id_seq    SEQUENCE OWNED BY     A   ALTER SEQUENCE public.flights_id_seq OWNED BY public.flights.id;
          public          postgres    false    213            �            1259    16416    tickets    TABLE     f   CREATE TABLE public.tickets (
    id bigint NOT NULL,
    flight_id bigint,
    customer_id bigint
);
    DROP TABLE public.tickets;
       public         heap    postgres    false            �            1259    16489    tickets_id_seq    SEQUENCE     w   CREATE SEQUENCE public.tickets_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 %   DROP SEQUENCE public.tickets_id_seq;
       public          postgres    false    203            )           0    0    tickets_id_seq    SEQUENCE OWNED BY     A   ALTER SEQUENCE public.tickets_id_seq OWNED BY public.tickets.id;
          public          postgres    false    214            �            1259    16464 
   user_roles    TABLE     P   CREATE TABLE public.user_roles (
    id integer NOT NULL,
    role_name text
);
    DROP TABLE public.user_roles;
       public         heap    postgres    false            �            1259    16492    user_roles_id_seq    SEQUENCE     z   CREATE SEQUENCE public.user_roles_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 (   DROP SEQUENCE public.user_roles_id_seq;
       public          postgres    false    208            *           0    0    user_roles_id_seq    SEQUENCE OWNED BY     G   ALTER SEQUENCE public.user_roles_id_seq OWNED BY public.user_roles.id;
          public          postgres    false    215            �            1259    16438    users    TABLE     �   CREATE TABLE public.users (
    id bigint NOT NULL,
    username text,
    password text,
    email text,
    user_role integer
);
    DROP TABLE public.users;
       public         heap    postgres    false            �            1259    16495    users_id_seq    SEQUENCE     u   CREATE SEQUENCE public.users_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 #   DROP SEQUENCE public.users_id_seq;
       public          postgres    false    206            +           0    0    users_id_seq    SEQUENCE OWNED BY     =   ALTER SEQUENCE public.users_id_seq OWNED BY public.users.id;
          public          postgres    false    216            S           2604    16476    administrators id    DEFAULT     v   ALTER TABLE ONLY public.administrators ALTER COLUMN id SET DEFAULT nextval('public.administrators_id_seq'::regclass);
 @   ALTER TABLE public.administrators ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    209    201            W           2604    16479    airline_companies id    DEFAULT     |   ALTER TABLE ONLY public.airline_companies ALTER COLUMN id SET DEFAULT nextval('public.airline_companies_id_seq'::regclass);
 C   ALTER TABLE public.airline_companies ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    210    205            T           2604    16482    countries id    DEFAULT     l   ALTER TABLE ONLY public.countries ALTER COLUMN id SET DEFAULT nextval('public.countries_id_seq'::regclass);
 ;   ALTER TABLE public.countries ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    211    202            Y           2604    16485    customers id    DEFAULT     l   ALTER TABLE ONLY public.customers ALTER COLUMN id SET DEFAULT nextval('public.customers_id_seq'::regclass);
 ;   ALTER TABLE public.customers ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    212    207            V           2604    16488 
   flights id    DEFAULT     h   ALTER TABLE ONLY public.flights ALTER COLUMN id SET DEFAULT nextval('public.flights_id_seq'::regclass);
 9   ALTER TABLE public.flights ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    213    204            U           2604    16491 
   tickets id    DEFAULT     h   ALTER TABLE ONLY public.tickets ALTER COLUMN id SET DEFAULT nextval('public.tickets_id_seq'::regclass);
 9   ALTER TABLE public.tickets ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    214    203            Z           2604    16494    user_roles id    DEFAULT     n   ALTER TABLE ONLY public.user_roles ALTER COLUMN id SET DEFAULT nextval('public.user_roles_id_seq'::regclass);
 <   ALTER TABLE public.user_roles ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    215    208            X           2604    16497    users id    DEFAULT     d   ALTER TABLE ONLY public.users ALTER COLUMN id SET DEFAULT nextval('public.users_id_seq'::regclass);
 7   ALTER TABLE public.users ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    216    206                      0    16396    administrators 
   TABLE DATA           S   COPY public.administrators (id, first_name, last_name, level, user_id) FROM stdin;
    public          postgres    false    201   �_                 0    16426    airline_companies 
   TABLE DATA           J   COPY public.airline_companies (id, name, country_id, user_id) FROM stdin;
    public          postgres    false    205   �_                 0    16406 	   countries 
   TABLE DATA           -   COPY public.countries (id, name) FROM stdin;
    public          postgres    false    202   I`                 0    16450 	   customers 
   TABLE DATA           j   COPY public.customers (id, first_name, last_name, address, phone_no, credit_card_no, user_id) FROM stdin;
    public          postgres    false    207   �`                 0    16421    flights 
   TABLE DATA           �   COPY public.flights (id, airline_company_id, origin_country_id, destination_country_id, departure_time, landing_time, remaining_tickets) FROM stdin;
    public          postgres    false    204   da                 0    16416    tickets 
   TABLE DATA           =   COPY public.tickets (id, flight_id, customer_id) FROM stdin;
    public          postgres    false    203   �a                 0    16464 
   user_roles 
   TABLE DATA           3   COPY public.user_roles (id, role_name) FROM stdin;
    public          postgres    false    208   b                 0    16438    users 
   TABLE DATA           I   COPY public.users (id, username, password, email, user_role) FROM stdin;
    public          postgres    false    206   Nb       ,           0    0    administrators_id_seq    SEQUENCE SET     C   SELECT pg_catalog.setval('public.administrators_id_seq', 2, true);
          public          postgres    false    209            -           0    0    airline_companies_id_seq    SEQUENCE SET     G   SELECT pg_catalog.setval('public.airline_companies_id_seq', 14, true);
          public          postgres    false    210            .           0    0    countries_id_seq    SEQUENCE SET     >   SELECT pg_catalog.setval('public.countries_id_seq', 8, true);
          public          postgres    false    211            /           0    0    customers_id_seq    SEQUENCE SET     >   SELECT pg_catalog.setval('public.customers_id_seq', 4, true);
          public          postgres    false    212            0           0    0    flights_id_seq    SEQUENCE SET     <   SELECT pg_catalog.setval('public.flights_id_seq', 7, true);
          public          postgres    false    213            1           0    0    tickets_id_seq    SEQUENCE SET     <   SELECT pg_catalog.setval('public.tickets_id_seq', 4, true);
          public          postgres    false    214            2           0    0    user_roles_id_seq    SEQUENCE SET     ?   SELECT pg_catalog.setval('public.user_roles_id_seq', 3, true);
          public          postgres    false    215            3           0    0    users_id_seq    SEQUENCE SET     ;   SELECT pg_catalog.setval('public.users_id_seq', 11, true);
          public          postgres    false    216            \           2606    16403 "   administrators administrators_pkey 
   CONSTRAINT     `   ALTER TABLE ONLY public.administrators
    ADD CONSTRAINT administrators_pkey PRIMARY KEY (id);
 L   ALTER TABLE ONLY public.administrators DROP CONSTRAINT administrators_pkey;
       public            postgres    false    201            ^           2606    16405 )   administrators administrators_user_id_key 
   CONSTRAINT     g   ALTER TABLE ONLY public.administrators
    ADD CONSTRAINT administrators_user_id_key UNIQUE (user_id);
 S   ALTER TABLE ONLY public.administrators DROP CONSTRAINT administrators_user_id_key;
       public            postgres    false    201            i           2606    16435 ,   airline_companies airline_companies_name_key 
   CONSTRAINT     g   ALTER TABLE ONLY public.airline_companies
    ADD CONSTRAINT airline_companies_name_key UNIQUE (name);
 V   ALTER TABLE ONLY public.airline_companies DROP CONSTRAINT airline_companies_name_key;
       public            postgres    false    205            k           2606    16433 (   airline_companies airline_companies_pkey 
   CONSTRAINT     f   ALTER TABLE ONLY public.airline_companies
    ADD CONSTRAINT airline_companies_pkey PRIMARY KEY (id);
 R   ALTER TABLE ONLY public.airline_companies DROP CONSTRAINT airline_companies_pkey;
       public            postgres    false    205            m           2606    16437 /   airline_companies airline_companies_user_id_key 
   CONSTRAINT     m   ALTER TABLE ONLY public.airline_companies
    ADD CONSTRAINT airline_companies_user_id_key UNIQUE (user_id);
 Y   ALTER TABLE ONLY public.airline_companies DROP CONSTRAINT airline_companies_user_id_key;
       public            postgres    false    205            `           2606    16415    countries countries_name_key 
   CONSTRAINT     W   ALTER TABLE ONLY public.countries
    ADD CONSTRAINT countries_name_key UNIQUE (name);
 F   ALTER TABLE ONLY public.countries DROP CONSTRAINT countries_name_key;
       public            postgres    false    202            b           2606    16413    countries countries_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public.countries
    ADD CONSTRAINT countries_pkey PRIMARY KEY (id);
 B   ALTER TABLE ONLY public.countries DROP CONSTRAINT countries_pkey;
       public            postgres    false    202            u           2606    16461 &   customers customers_credit_card_no_key 
   CONSTRAINT     k   ALTER TABLE ONLY public.customers
    ADD CONSTRAINT customers_credit_card_no_key UNIQUE (credit_card_no);
 P   ALTER TABLE ONLY public.customers DROP CONSTRAINT customers_credit_card_no_key;
       public            postgres    false    207            w           2606    16459     customers customers_phone_no_key 
   CONSTRAINT     _   ALTER TABLE ONLY public.customers
    ADD CONSTRAINT customers_phone_no_key UNIQUE (phone_no);
 J   ALTER TABLE ONLY public.customers DROP CONSTRAINT customers_phone_no_key;
       public            postgres    false    207            y           2606    16457    customers customers_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public.customers
    ADD CONSTRAINT customers_pkey PRIMARY KEY (id);
 B   ALTER TABLE ONLY public.customers DROP CONSTRAINT customers_pkey;
       public            postgres    false    207            {           2606    16463    customers customers_user_id_key 
   CONSTRAINT     ]   ALTER TABLE ONLY public.customers
    ADD CONSTRAINT customers_user_id_key UNIQUE (user_id);
 I   ALTER TABLE ONLY public.customers DROP CONSTRAINT customers_user_id_key;
       public            postgres    false    207            g           2606    16425    flights flights_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public.flights
    ADD CONSTRAINT flights_pkey PRIMARY KEY (id);
 >   ALTER TABLE ONLY public.flights DROP CONSTRAINT flights_pkey;
       public            postgres    false    204            e           2606    16420    tickets tickets_pkey 
   CONSTRAINT     R   ALTER TABLE ONLY public.tickets
    ADD CONSTRAINT tickets_pkey PRIMARY KEY (id);
 >   ALTER TABLE ONLY public.tickets DROP CONSTRAINT tickets_pkey;
       public            postgres    false    203            }           2606    16471    user_roles user_roles_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public.user_roles
    ADD CONSTRAINT user_roles_pkey PRIMARY KEY (id);
 D   ALTER TABLE ONLY public.user_roles DROP CONSTRAINT user_roles_pkey;
       public            postgres    false    208                       2606    16473 #   user_roles user_roles_role_name_key 
   CONSTRAINT     c   ALTER TABLE ONLY public.user_roles
    ADD CONSTRAINT user_roles_role_name_key UNIQUE (role_name);
 M   ALTER TABLE ONLY public.user_roles DROP CONSTRAINT user_roles_role_name_key;
       public            postgres    false    208            o           2606    16449    users users_email_key 
   CONSTRAINT     Q   ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_email_key UNIQUE (email);
 ?   ALTER TABLE ONLY public.users DROP CONSTRAINT users_email_key;
       public            postgres    false    206            q           2606    16445    users users_pkey 
   CONSTRAINT     N   ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (id);
 :   ALTER TABLE ONLY public.users DROP CONSTRAINT users_pkey;
       public            postgres    false    206            s           2606    16447    users users_username_key 
   CONSTRAINT     W   ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_username_key UNIQUE (username);
 B   ALTER TABLE ONLY public.users DROP CONSTRAINT users_username_key;
       public            postgres    false    206            c           1259    16498 #   tickets_flight_id_customer_id_index    INDEX     i   CREATE INDEX tickets_flight_id_customer_id_index ON public.tickets USING btree (flight_id, customer_id);
 7   DROP INDEX public.tickets_flight_id_customer_id_index;
       public            postgres    false    203    203            �           2606    16504 )   administrators administrators_users_id_fk    FK CONSTRAINT     �   ALTER TABLE ONLY public.administrators
    ADD CONSTRAINT administrators_users_id_fk FOREIGN KEY (user_id) REFERENCES public.users(id);
 S   ALTER TABLE ONLY public.administrators DROP CONSTRAINT administrators_users_id_fk;
       public          postgres    false    201    206    2929            �           2606    16549 3   airline_companies airline_companies_countries_id_fk    FK CONSTRAINT     �   ALTER TABLE ONLY public.airline_companies
    ADD CONSTRAINT airline_companies_countries_id_fk FOREIGN KEY (country_id) REFERENCES public.countries(id);
 ]   ALTER TABLE ONLY public.airline_companies DROP CONSTRAINT airline_companies_countries_id_fk;
       public          postgres    false    2914    205    202            �           2606    16509 /   airline_companies airline_companies_users_id_fk    FK CONSTRAINT     �   ALTER TABLE ONLY public.airline_companies
    ADD CONSTRAINT airline_companies_users_id_fk FOREIGN KEY (user_id) REFERENCES public.users(id);
 Y   ALTER TABLE ONLY public.airline_companies DROP CONSTRAINT airline_companies_users_id_fk;
       public          postgres    false    205    206    2929            �           2606    16514    customers customers_users_id_fk    FK CONSTRAINT     ~   ALTER TABLE ONLY public.customers
    ADD CONSTRAINT customers_users_id_fk FOREIGN KEY (user_id) REFERENCES public.users(id);
 I   ALTER TABLE ONLY public.customers DROP CONSTRAINT customers_users_id_fk;
       public          postgres    false    206    207    2929            �           2606    16529 '   flights flights_airline_companies_id_fk    FK CONSTRAINT     �   ALTER TABLE ONLY public.flights
    ADD CONSTRAINT flights_airline_companies_id_fk FOREIGN KEY (airline_company_id) REFERENCES public.airline_companies(id);
 Q   ALTER TABLE ONLY public.flights DROP CONSTRAINT flights_airline_companies_id_fk;
       public          postgres    false    205    2923    204            �           2606    16539    flights flights_countries_id_fk    FK CONSTRAINT     �   ALTER TABLE ONLY public.flights
    ADD CONSTRAINT flights_countries_id_fk FOREIGN KEY (origin_country_id) REFERENCES public.countries(id);
 I   ALTER TABLE ONLY public.flights DROP CONSTRAINT flights_countries_id_fk;
       public          postgres    false    202    204    2914            �           2606    16544 !   flights flights_countries_id_fk_2    FK CONSTRAINT     �   ALTER TABLE ONLY public.flights
    ADD CONSTRAINT flights_countries_id_fk_2 FOREIGN KEY (destination_country_id) REFERENCES public.countries(id);
 K   ALTER TABLE ONLY public.flights DROP CONSTRAINT flights_countries_id_fk_2;
       public          postgres    false    2914    202    204            �           2606    16519    tickets tickets_customers_id_fk    FK CONSTRAINT     �   ALTER TABLE ONLY public.tickets
    ADD CONSTRAINT tickets_customers_id_fk FOREIGN KEY (customer_id) REFERENCES public.customers(id);
 I   ALTER TABLE ONLY public.tickets DROP CONSTRAINT tickets_customers_id_fk;
       public          postgres    false    2937    207    203            �           2606    16524    tickets tickets_flights_id_fk    FK CONSTRAINT     �   ALTER TABLE ONLY public.tickets
    ADD CONSTRAINT tickets_flights_id_fk FOREIGN KEY (flight_id) REFERENCES public.flights(id);
 G   ALTER TABLE ONLY public.tickets DROP CONSTRAINT tickets_flights_id_fk;
       public          postgres    false    2919    203    204            �           2606    16499    users users_user_roles_id_fk    FK CONSTRAINT     �   ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_user_roles_id_fk FOREIGN KEY (user_role) REFERENCES public.user_roles(id);
 F   ALTER TABLE ONLY public.users DROP CONSTRAINT users_user_roles_id_fk;
       public          postgres    false    206    2941    208               *   x�3�t��ɩ�����\F�^�y�.���F�F\1z\\\ ��         T   x���
� ���^�ѡͱ� ��0���;�b��`hb���oHb�}���K��g9�`��x���K�7��L�BD?�J         U   x�Ȼ@@�z��H���eu�	��`��l���S���`,7
Z�%�1Ϩh0�]P�c}Y�kȝ�o�-�h�$t4�=�	[����         �   x�-��
�0���_�&�M�c�$�"� H��%����כVO;�v%��?pb�8�w�Qٝu�a� �+mXIZ'�P8�i�u�>��v�����Vtc�e���$t�e�n��']��Q�"�\��bӮ&�؂��У��ѧg�9��͒����xs�\[W���_��2�         [   x�U�Q
�0��x��֭w��ϱve��G�GD��M9n#M�4sW[�p)�������;S*�zi�̕�E�/�o�5��3�-�!"?�         %   x�3�4�4�2�4�4�2�4�4�2�4�4����� 4�{         :   x�3�tL����,.)J,�/�2�t�,���K�w��-H̫�2�t.-.��M-����� �%         �   x�m��N�0E���ڲkx,�"U�(	)�:�q�گ�aC�es���H�qg�;V�C�c��.?[�.�q�\M�b���JP��Ц(:j��hJ��4r��O��76���&>^�ظ�:x��)��DA�pgx�A��.�{��a�'�7�cY%�#��׉Z`�m�5�q	��}��� �V~��ob�cGp�$���8��sX���'�=SJ� I��G     
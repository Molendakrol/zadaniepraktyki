PGDMP                      }           test    17.3    17.3     �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                           false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                           false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                           false            �           1262    24579    test    DATABASE     j   CREATE DATABASE test WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'pl-PL';
    DROP DATABASE test;
                     postgres    false            �            1259    24610    Klijentella    TABLE     �   CREATE TABLE public."Klijentella" (
    "Id" integer NOT NULL,
    "Name" text NOT NULL,
    "Surname" text NOT NULL,
    "PESEL" text NOT NULL,
    "BirthYear" integer NOT NULL,
    "Plec" integer NOT NULL
);
 !   DROP TABLE public."Klijentella";
       public         heap r       postgres    false            �            1259    24609    Klijentella_Id_seq    SEQUENCE     �   CREATE SEQUENCE public."Klijentella_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 +   DROP SEQUENCE public."Klijentella_Id_seq";
       public               postgres    false    218            �           0    0    Klijentella_Id_seq    SEQUENCE OWNED BY     O   ALTER SEQUENCE public."Klijentella_Id_seq" OWNED BY public."Klijentella"."Id";
          public               postgres    false    217            �            1259    24619    __EFMigrationsHistory    TABLE     �   CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);
 +   DROP TABLE public."__EFMigrationsHistory";
       public         heap r       postgres    false            �            1259    24631    tabelajacob    TABLE     �   CREATE TABLE public.tabelajacob (
    "Id" smallint NOT NULL,
    "Name" character varying(50),
    "Surname" character varying(50),
    "PESEL" character varying(11),
    "BirthYear" integer,
    "Płeć" integer
);
    DROP TABLE public.tabelajacob;
       public         heap r       postgres    false            �            1259    24630    tabelajacob_Id_seq    SEQUENCE     �   CREATE SEQUENCE public."tabelajacob_Id_seq"
    AS smallint
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 +   DROP SEQUENCE public."tabelajacob_Id_seq";
       public               postgres    false    221            �           0    0    tabelajacob_Id_seq    SEQUENCE OWNED BY     M   ALTER SEQUENCE public."tabelajacob_Id_seq" OWNED BY public.tabelajacob."Id";
          public               postgres    false    220                       2604    24613    Klijentella Id    DEFAULT     v   ALTER TABLE ONLY public."Klijentella" ALTER COLUMN "Id" SET DEFAULT nextval('public."Klijentella_Id_seq"'::regclass);
 A   ALTER TABLE public."Klijentella" ALTER COLUMN "Id" DROP DEFAULT;
       public               postgres    false    217    218    218                       2604    24634    tabelajacob Id    DEFAULT     t   ALTER TABLE ONLY public.tabelajacob ALTER COLUMN "Id" SET DEFAULT nextval('public."tabelajacob_Id_seq"'::regclass);
 ?   ALTER TABLE public.tabelajacob ALTER COLUMN "Id" DROP DEFAULT;
       public               postgres    false    220    221    221            �          0    24610    Klijentella 
   TABLE DATA           ^   COPY public."Klijentella" ("Id", "Name", "Surname", "PESEL", "BirthYear", "Plec") FROM stdin;
    public               postgres    false    218   W       �          0    24619    __EFMigrationsHistory 
   TABLE DATA           R   COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
    public               postgres    false    219   �       �          0    24631    tabelajacob 
   TABLE DATA           ^   COPY public.tabelajacob ("Id", "Name", "Surname", "PESEL", "BirthYear", "Płeć") FROM stdin;
    public               postgres    false    221          �           0    0    Klijentella_Id_seq    SEQUENCE SET     C   SELECT pg_catalog.setval('public."Klijentella_Id_seq"', 42, true);
          public               postgres    false    217            �           0    0    tabelajacob_Id_seq    SEQUENCE SET     B   SELECT pg_catalog.setval('public."tabelajacob_Id_seq"', 1, true);
          public               postgres    false    220                       2606    24636    tabelajacob Id 
   CONSTRAINT     P   ALTER TABLE ONLY public.tabelajacob
    ADD CONSTRAINT "Id" PRIMARY KEY ("Id");
 :   ALTER TABLE ONLY public.tabelajacob DROP CONSTRAINT "Id";
       public                 postgres    false    221                       2606    24617    Klijentella PK_Klijentella 
   CONSTRAINT     ^   ALTER TABLE ONLY public."Klijentella"
    ADD CONSTRAINT "PK_Klijentella" PRIMARY KEY ("Id");
 H   ALTER TABLE ONLY public."Klijentella" DROP CONSTRAINT "PK_Klijentella";
       public                 postgres    false    218                       2606    24623 .   __EFMigrationsHistory PK___EFMigrationsHistory 
   CONSTRAINT     {   ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");
 \   ALTER TABLE ONLY public."__EFMigrationsHistory" DROP CONSTRAINT "PK___EFMigrationsHistory";
       public                 postgres    false    219            �   �   x���1�0Eg�0�v�a�,,)0�Fj��zzh�?=���g��k�p\�V>�m��h��D#PJ伇g~�;�� Bf�(R@����<O�ˀ���
�(?Elk�6L�Y�'5aw���\sY`��Fe1����s_d�aa      �      x������ � �      �   -   x�3��JL�O������44261622641�4200�4����� �w�     
﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using learn_migration.Infrastructure.DataModels;

#nullable disable

namespace learn_migration.Migrations
{
    [DbContext(typeof(_DbContext))]
    [Migration("20220925233622_tb_jogador_auto_incremento")]
    partial class tb_jogador_auto_incremento
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("learn_migration.Infrastructure.DataModels.TbGenero", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<char>("Genero")
                        .HasMaxLength(1)
                        .HasColumnType("character(1)")
                        .HasColumnName("genero");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Genero" }, "tb_genero_genero_key")
                        .IsUnique();

                    b.ToTable("tb_genero", (string)null);
                });

            modelBuilder.Entity("learn_migration.Infrastructure.DataModels.TbInscrito", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly?>("DataPub")
                        .HasColumnType("date")
                        .HasColumnName("data_pub");

                    b.Property<int>("Genero")
                        .HasColumnType("integer")
                        .HasColumnName("genero");

                    b.Property<int>("Instituicao")
                        .HasColumnType("integer")
                        .HasColumnName("instituicao");

                    b.Property<int>("Jogador")
                        .HasColumnType("integer")
                        .HasColumnName("jogador");

                    b.HasKey("Id");

                    b.HasIndex("Genero");

                    b.HasIndex("Instituicao");

                    b.HasIndex("Jogador");

                    b.ToTable("tb_inscrito", (string)null);
                });

            modelBuilder.Entity("learn_migration.Infrastructure.DataModels.TbInstituicao", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("character varying(35)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Nome" }, "tb_instituicao_nome_key")
                        .IsUnique();

                    b.ToTable("tb_instituicao", (string)null);
                });

            modelBuilder.Entity("learn_migration.Infrastructure.DataModels.TbJogador", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<DateOnly?>("DataNasc")
                        .HasColumnType("date")
                        .HasColumnName("data_nasc");

                    b.Property<string>("Mae")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("nome");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)")
                        .HasColumnName("sobrenome");

                    b.HasKey("Id");

                    b.ToTable("tb_jogador", (string)null);
                });

            modelBuilder.Entity("learn_migration.Infrastructure.DataModels.TbInscrito", b =>
                {
                    b.HasOne("learn_migration.Infrastructure.DataModels.TbGenero", "GeneroNavigation")
                        .WithMany("TbInscritos")
                        .HasForeignKey("Genero")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("tb_inscrito_genero_fkey");

                    b.HasOne("learn_migration.Infrastructure.DataModels.TbInstituicao", "InstituicaoNavigation")
                        .WithMany("TbInscritos")
                        .HasForeignKey("Instituicao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("tb_inscrito_instituicao_fkey");

                    b.HasOne("learn_migration.Infrastructure.DataModels.TbJogador", "JogadorNavigation")
                        .WithMany("TbInscritos")
                        .HasForeignKey("Jogador")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("tb_inscrito_jogador_fkey");

                    b.Navigation("GeneroNavigation");

                    b.Navigation("InstituicaoNavigation");

                    b.Navigation("JogadorNavigation");
                });

            modelBuilder.Entity("learn_migration.Infrastructure.DataModels.TbGenero", b =>
                {
                    b.Navigation("TbInscritos");
                });

            modelBuilder.Entity("learn_migration.Infrastructure.DataModels.TbInstituicao", b =>
                {
                    b.Navigation("TbInscritos");
                });

            modelBuilder.Entity("learn_migration.Infrastructure.DataModels.TbJogador", b =>
                {
                    b.Navigation("TbInscritos");
                });
#pragma warning restore 612, 618
        }
    }
}

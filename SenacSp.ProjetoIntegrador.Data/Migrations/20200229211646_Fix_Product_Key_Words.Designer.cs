﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SenacSp.ProjetoIntegrador.Data;

namespace SenacSp.ProjetoIntegrador.Data.Migrations
{
    [DbContext(typeof(ECommerceDataContext))]
    [Migration("20200229211646_Fix_Product_Key_Words")]
    partial class Fix_Product_Key_Words
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("senac_ecommerce")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("SenacSp.ProjetoIntegrador.Domain.Entities.KeyWord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<string>("Word")
                        .HasColumnName("word")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Word")
                        .IsUnique();

                    b.ToTable("key_words");
                });

            modelBuilder.Entity("SenacSp.ProjetoIntegrador.Domain.Entities.Log", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<string>("Exception")
                        .HasColumnName("exception")
                        .HasColumnType("text");

                    b.Property<string>("Level")
                        .HasColumnName("level")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Logger")
                        .HasColumnName("logger")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Message")
                        .HasColumnName("message")
                        .HasColumnType("text");

                    b.Property<DateTime>("OccurredAt")
                        .HasColumnName("occurred_at")
                        .HasColumnType("timestamp");

                    b.HasKey("Id");

                    b.ToTable("logs");
                });

            modelBuilder.Entity("SenacSp.ProjetoIntegrador.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnName("desciption")
                        .HasColumnType("Varchar(255)");

                    b.Property<bool>("IsActive")
                        .HasColumnName("is_active")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("Varchar(255)");

                    b.Property<decimal>("Price")
                        .HasColumnName("price")
                        .HasColumnType("numeric");

                    b.Property<int>("Quantity")
                        .HasColumnName("quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("products");
                });

            modelBuilder.Entity("SenacSp.ProjetoIntegrador.Domain.Entities.ProductImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<string>("ImageFullPath")
                        .IsRequired()
                        .HasColumnName("image_path")
                        .HasColumnType("text");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("product_images");
                });

            modelBuilder.Entity("SenacSp.ProjetoIntegrador.Domain.Entities.ProductKeyWord", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("KeyWordId")
                        .HasColumnType("uuid");

                    b.HasKey("ProductId", "KeyWordId");

                    b.HasIndex("KeyWordId");

                    b.ToTable("product_key_words");
                });

            modelBuilder.Entity("SenacSp.ProjetoIntegrador.Domain.Entities.ProductQA", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("product_question_answers");
                });

            modelBuilder.Entity("SenacSp.ProjetoIntegrador.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<bool>("Active")
                        .HasColumnName("active")
                        .HasColumnType("boolean");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasColumnType("Varchar(255)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("Varchar(255)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnName("senha")
                        .HasColumnType("Varchar(255)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnName("type")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Senha")
                        .IsUnique();

                    b.ToTable("users");
                });

            modelBuilder.Entity("SenacSp.ProjetoIntegrador.Domain.Entities.ProductImage", b =>
                {
                    b.HasOne("SenacSp.ProjetoIntegrador.Domain.Entities.Product", "Product")
                        .WithMany("Images")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SenacSp.ProjetoIntegrador.Domain.Entities.ProductKeyWord", b =>
                {
                    b.HasOne("SenacSp.ProjetoIntegrador.Domain.Entities.KeyWord", "KeyWord")
                        .WithMany("Products")
                        .HasForeignKey("KeyWordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SenacSp.ProjetoIntegrador.Domain.Entities.Product", "Product")
                        .WithMany("KeyWords")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SenacSp.ProjetoIntegrador.Domain.Entities.ProductQA", b =>
                {
                    b.HasOne("SenacSp.ProjetoIntegrador.Domain.Entities.Product", "Product")
                        .WithMany("QuestionsAndAnswers")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("SenacSp.ProjetoIntegrador.Shared.ValueObjects.QuestionAnswer", "QuestionAndAnswer", b1 =>
                        {
                            b1.Property<Guid>("ProductQAId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Answer")
                                .HasColumnName("answer")
                                .HasColumnType("varchar(525)");

                            b1.Property<string>("Question")
                                .HasColumnName("question")
                                .HasColumnType("varchar(255)");

                            b1.HasKey("ProductQAId");

                            b1.ToTable("product_question_answers");

                            b1.WithOwner()
                                .HasForeignKey("ProductQAId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

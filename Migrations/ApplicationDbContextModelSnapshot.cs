﻿// <auto-generated />
using CRUDContatos.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CRUDContatos.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("CRUDContatos.Models.Contato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Emails")
                        .HasColumnType("TEXT");

                    b.Property<string>("Empresa")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TelefoneComercial")
                        .HasColumnType("TEXT");

                    b.Property<string>("TelefonePessoal")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Contato");
                });
#pragma warning restore 612, 618
        }
    }
}

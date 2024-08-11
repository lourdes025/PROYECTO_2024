﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PROYECTO_2024.BD.DATA;

#nullable disable

namespace PROYECTO_2024.BD.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240806042900_ClavesUnicas")]
    partial class ClavesUnicas
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PROYECTO_2024.BD.DATA.ENTITY.Localidad", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("codigo")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.HasKey("ID");

                    b.HasIndex(new[] { "codigo" }, "LocalidadUq")
                        .IsUnique();

                    b.ToTable("Localidades");
                });

            modelBuilder.Entity("PROYECTO_2024.BD.DATA.ENTITY.Persona", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Celular")
                        .HasMaxLength(11)
                        .HasColumnType("int");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Edad")
                        .HasMaxLength(3)
                        .HasColumnType("int");

                    b.Property<int>("LocalidadId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("NumDoc")
                        .HasMaxLength(12)
                        .HasColumnType("int");

                    b.Property<int>("TdocumentoId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex(new[] { "Apellido", "Nombre" }, "PersonaApellido_Nombre");

                    b.HasIndex(new[] { "TdocumentoId", "NumDoc" }, "PersonaUq")
                        .IsUnique();

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("PROYECTO_2024.BD.DATA.ENTITY.Tdocumento", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("codigo")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.HasKey("ID");

                    b.HasIndex(new[] { "codigo" }, "TdocumentoUq")
                        .IsUnique();

                    b.ToTable("Tdocumentos");
                });

            modelBuilder.Entity("PROYECTO_2024.BD.DATA.ENTITY.Validacion", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.HasKey("ID");

                    b.ToTable("Validaciones");
                });

            modelBuilder.Entity("PROYECTO_2024.BD.DATA.ENTITY.Persona", b =>
                {
                    b.HasOne("PROYECTO_2024.BD.DATA.ENTITY.Tdocumento", "Tdocumento")
                        .WithMany("Personas")
                        .HasForeignKey("TdocumentoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Tdocumento");
                });

            modelBuilder.Entity("PROYECTO_2024.BD.DATA.ENTITY.Tdocumento", b =>
                {
                    b.Navigation("Personas");
                });
#pragma warning restore 612, 618
        }
    }
}

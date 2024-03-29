﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SISPR.Models.DataBase;

namespace SISPR.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20210813082930_343341")]
    partial class _343341
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.8");

            modelBuilder.Entity("SISPR.Models.DataBase.Basic.Location.City", b =>
                {
                    b.Property<int>("city_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("fias_code")
                        .HasColumnType("longtext");

                    b.Property<int>("mo_id")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("longtext");

                    b.Property<string>("search_name")
                        .HasColumnType("longtext");

                    b.HasKey("city_id");

                    b.ToTable("City");
                });

            modelBuilder.Entity("SISPR.Models.DataBase.Basic.Location.MO", b =>
                {
                    b.Property<int>("mo_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("fias_code")
                        .HasColumnType("longtext");

                    b.Property<string>("name")
                        .HasColumnType("longtext");

                    b.Property<int>("region_id")
                        .HasColumnType("int");

                    b.Property<string>("searсh_name")
                        .HasColumnType("longtext");

                    b.HasKey("mo_id");

                    b.ToTable("MO");
                });

            modelBuilder.Entity("SISPR.Models.DataBase.Basic.Location.OO", b =>
                {
                    b.Property<int>("oo_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("city_id")
                        .HasColumnType("int");

                    b.Property<string>("inn")
                        .HasColumnType("longtext");

                    b.Property<string>("name")
                        .HasColumnType("longtext");

                    b.Property<string>("name_short")
                        .HasColumnType("longtext");

                    b.HasKey("oo_id");

                    b.ToTable("OO");
                });

            modelBuilder.Entity("SISPR.Models.DataBase.Basic.Location.Region", b =>
                {
                    b.Property<int>("region_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("code")
                        .HasColumnType("int");

                    b.Property<string>("fias_code")
                        .HasColumnType("longtext");

                    b.Property<string>("name")
                        .HasColumnType("longtext");

                    b.Property<string>("search_name")
                        .HasColumnType("longtext");

                    b.HasKey("region_id");

                    b.ToTable("Region");
                });

            modelBuilder.Entity("SISPR.Models.DataBase.Course.Category_student", b =>
                {
                    b.Property<int>("category_student_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("longtext");

                    b.HasKey("category_student_id");

                    b.ToTable("Category_student");
                });

            modelBuilder.Entity("SISPR.Models.DataBase.Course.Course", b =>
                {
                    b.Property<int>("course_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("budjet_vnebudjet")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("date_end")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("date_start")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("dpp_pk")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("kafedra_id")
                        .HasColumnType("int");

                    b.Property<int>("kol_group")
                        .HasColumnType("int");

                    b.Property<int>("kvota")
                        .HasColumnType("int");

                    b.Property<string>("mesto_providenia")
                        .HasColumnType("longtext");

                    b.Property<bool>("pp_pkp")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("rukovoditel_user_id")
                        .HasColumnType("int");

                    b.Property<string>("tema")
                        .HasColumnType("longtext");

                    b.Property<int>("utp_id")
                        .HasColumnType("int");

                    b.HasKey("course_id");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("SISPR.Models.DataBase.Course.Course_category_student", b =>
                {
                    b.Property<int>("course_category_stident_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("category_stident_id")
                        .HasColumnType("int");

                    b.Property<int>("course_id")
                        .HasColumnType("int");

                    b.HasKey("course_category_stident_id");

                    b.ToTable("Course_category_student");
                });

            modelBuilder.Entity("SISPR.Models.DataBase.Course.Group", b =>
                {
                    b.Property<int>("group_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("course_id")
                        .HasColumnType("int");

                    b.Property<int>("kol_student")
                        .HasColumnType("int");

                    b.Property<int>("kol_subgroup")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("longtext");

                    b.HasKey("group_id");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("SISPR.Models.DataBase.Course.Subgroup", b =>
                {
                    b.Property<int>("subgroup_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("group_id")
                        .HasColumnType("int");

                    b.Property<int>("kol_student")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("longtext");

                    b.HasKey("subgroup_id");

                    b.ToTable("Subgroup");
                });

            modelBuilder.Entity("SISPR.Models.DataBase.UTP.Type_training_load", b =>
                {
                    b.Property<int>("type_training_load_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("longtext");

                    b.Property<float>("number_control_forms")
                        .HasColumnType("float");

                    b.Property<float>("number_groups")
                        .HasColumnType("float");

                    b.Property<float>("number_hours")
                        .HasColumnType("float");

                    b.Property<float>("number_listeners")
                        .HasColumnType("float");

                    b.Property<float>("number_subgroups")
                        .HasColumnType("float");

                    b.Property<int>("type")
                        .HasColumnType("int");

                    b.Property<float>("volume_hours")
                        .HasColumnType("float");

                    b.HasKey("type_training_load_id");

                    b.ToTable("Type_training_load");
                });

            modelBuilder.Entity("SISPR.Models.DataBase.UTP.UTP", b =>
                {
                    b.Property<int>("utp_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("forma_obuchen_id")
                        .HasColumnType("int");

                    b.Property<float>("hour")
                        .HasColumnType("float");

                    b.Property<int>("kol_groups")
                        .HasColumnType("int");

                    b.Property<int>("kol_slushatel_v_group")
                        .HasColumnType("int");

                    b.Property<int>("kol_subgroups")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("longtext");

                    b.Property<int>("rejim_zanyati")
                        .HasColumnType("int");

                    b.HasKey("utp_id");

                    b.ToTable("UTPs");
                });

            modelBuilder.Entity("SISPR.Models.DataBase.UTP.UTP_type_training_load", b =>
                {
                    b.Property<int>("utp_type_training_load_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("type_training_load_id")
                        .HasColumnType("int");

                    b.Property<int>("utp_id")
                        .HasColumnType("int");

                    b.HasKey("utp_type_training_load_id");

                    b.ToTable("UTP_type_training_load");
                });
#pragma warning restore 612, 618
        }
    }
}

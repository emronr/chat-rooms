﻿// <auto-generated />
using System;
using Chatter.Persistence.Application.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Chatter.PostgreMigrations.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240304140710_ChangeRoomChatterIndex")]
    partial class ChangeRoomChatterIndex
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Chatter.Domain.Entities.EFCore.Application.Invitation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_date");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("deleted_date");

                    b.Property<string>("InvitedUserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("invited_user_id");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("modified_date");

                    b.Property<int>("RoomId")
                        .HasColumnType("integer")
                        .HasColumnName("room_id");

                    b.Property<string>("SenderUserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("sender_user_id");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.HasKey("Id")
                        .HasName("pk_invitations");

                    b.HasIndex("InvitedUserId")
                        .HasDatabaseName("ix_invitations_invited_user_id");

                    b.HasIndex("RoomId")
                        .HasDatabaseName("ix_invitations_room_id");

                    b.HasIndex("SenderUserId")
                        .HasDatabaseName("ix_invitations_sender_user_id");

                    b.ToTable("invitations", (string)null);
                });

            modelBuilder.Entity("Chatter.Domain.Entities.EFCore.Application.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacity")
                        .HasColumnType("integer")
                        .HasColumnName("capacity");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_date");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("deleted_date");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("boolean")
                        .HasColumnName("is_public");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("modified_date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_rooms");

                    b.ToTable("rooms", (string)null);
                });

            modelBuilder.Entity("Chatter.Domain.Entities.EFCore.Application.RoomChatterUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ChatterUserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("chatter_user_id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_date");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("deleted_date");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("boolean")
                        .HasColumnName("is_blocked");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("modified_date");

                    b.Property<int>("RoomId")
                        .HasColumnType("integer")
                        .HasColumnName("room_id");

                    b.HasKey("Id")
                        .HasName("pk_room_chatter_user");

                    b.HasIndex("RoomId")
                        .HasDatabaseName("ix_room_chatter_user_room_id");

                    b.HasIndex("ChatterUserId", "RoomId")
                        .HasDatabaseName("ix_room_chatter_user_chatter_user_id_room_id")
                        .HasFilter("is_deleted = false");

                    b.ToTable("room_chatter_user", (string)null);
                });

            modelBuilder.Entity("Chatter.Domain.Entities.EFCore.Application.RoomPermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ChatterUserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("chatter_user_id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_date");

                    b.Property<int>("PermissionType")
                        .HasColumnType("integer")
                        .HasColumnName("permission_type");

                    b.Property<int>("RoomId")
                        .HasColumnType("integer")
                        .HasColumnName("room_id");

                    b.HasKey("Id")
                        .HasName("pk_room_permissions");

                    b.HasIndex("ChatterUserId")
                        .HasDatabaseName("ix_room_permissions_chatter_user_id");

                    b.HasIndex("RoomId")
                        .HasDatabaseName("ix_room_permissions_room_id");

                    b.ToTable("room_permissions", (string)null);
                });

            modelBuilder.Entity("Chatter.Domain.Entities.EFCore.Identity.ChatterUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer")
                        .HasColumnName("access_failed_count");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text")
                        .HasColumnName("concurrency_stamp");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_date");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("deleted_date");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("email");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean")
                        .HasColumnName("email_confirmed");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean")
                        .HasColumnName("lockout_enabled");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("lockout_end");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("modified_date");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("normalized_email");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("normalized_user_name");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text")
                        .HasColumnName("password_hash");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean")
                        .HasColumnName("phone_number_confirmed");

                    b.Property<string>("ProfileImagePath")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("profile_image_path");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text")
                        .HasColumnName("security_stamp");

                    b.Property<string>("StatusDescription")
                        .HasColumnType("text")
                        .HasColumnName("status_description");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean")
                        .HasColumnName("two_factor_enabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("user_name");

                    b.HasKey("Id")
                        .HasName("pk_asp_net_users");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text")
                        .HasColumnName("concurrency_stamp");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("name");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("normalized_name");

                    b.HasKey("Id")
                        .HasName("pk_asp_net_roles");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text")
                        .HasColumnName("claim_value");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("role_id");

                    b.HasKey("Id")
                        .HasName("pk_asp_net_role_claims");

                    b.HasIndex("RoleId")
                        .HasDatabaseName("ix_asp_net_role_claims_role_id");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text")
                        .HasColumnName("claim_value");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_asp_net_user_claims");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_asp_net_user_claims_user_id");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text")
                        .HasColumnName("login_provider");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text")
                        .HasColumnName("provider_key");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text")
                        .HasColumnName("provider_display_name");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.HasKey("LoginProvider", "ProviderKey")
                        .HasName("pk_asp_net_user_logins");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_asp_net_user_logins_user_id");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.Property<string>("RoleId")
                        .HasColumnType("text")
                        .HasColumnName("role_id");

                    b.HasKey("UserId", "RoleId")
                        .HasName("pk_asp_net_user_roles");

                    b.HasIndex("RoleId")
                        .HasDatabaseName("ix_asp_net_user_roles_role_id");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text")
                        .HasColumnName("login_provider");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Value")
                        .HasColumnType("text")
                        .HasColumnName("value");

                    b.HasKey("UserId", "LoginProvider", "Name")
                        .HasName("pk_asp_net_user_tokens");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Chatter.Domain.Entities.EFCore.Application.Invitation", b =>
                {
                    b.HasOne("Chatter.Domain.Entities.EFCore.Identity.ChatterUser", "InvitedUser")
                        .WithMany("ReceivedInvitations")
                        .HasForeignKey("InvitedUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_invitations_users_invited_user_id");

                    b.HasOne("Chatter.Domain.Entities.EFCore.Application.Room", "Room")
                        .WithMany("Invitations")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_invitations_rooms_room_id");

                    b.HasOne("Chatter.Domain.Entities.EFCore.Identity.ChatterUser", "SenderUser")
                        .WithMany("SentInvitations")
                        .HasForeignKey("SenderUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_invitations_users_chatter_user_id");

                    b.Navigation("InvitedUser");

                    b.Navigation("Room");

                    b.Navigation("SenderUser");
                });

            modelBuilder.Entity("Chatter.Domain.Entities.EFCore.Application.RoomChatterUser", b =>
                {
                    b.HasOne("Chatter.Domain.Entities.EFCore.Identity.ChatterUser", "ChatterUser")
                        .WithMany("RoomChatterUsers")
                        .HasForeignKey("ChatterUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_room_chatter_user_users_chatter_user_id");

                    b.HasOne("Chatter.Domain.Entities.EFCore.Application.Room", "Room")
                        .WithMany("RoomChatterUsers")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_room_chatter_user_rooms_room_id");

                    b.Navigation("ChatterUser");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Chatter.Domain.Entities.EFCore.Application.RoomPermission", b =>
                {
                    b.HasOne("Chatter.Domain.Entities.EFCore.Identity.ChatterUser", "ChatterUser")
                        .WithMany()
                        .HasForeignKey("ChatterUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_room_permissions_users_chatter_user_id");

                    b.HasOne("Chatter.Domain.Entities.EFCore.Application.Room", "Room")
                        .WithMany("RoomPermissions")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_room_permissions_rooms_room_id");

                    b.Navigation("ChatterUser");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_asp_net_role_claims_asp_net_roles_role_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Chatter.Domain.Entities.EFCore.Identity.ChatterUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_asp_net_user_claims_asp_net_users_user_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Chatter.Domain.Entities.EFCore.Identity.ChatterUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_asp_net_user_logins_asp_net_users_user_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_asp_net_user_roles_asp_net_roles_role_id");

                    b.HasOne("Chatter.Domain.Entities.EFCore.Identity.ChatterUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_asp_net_user_roles_asp_net_users_user_id");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Chatter.Domain.Entities.EFCore.Identity.ChatterUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_asp_net_user_tokens_asp_net_users_user_id");
                });

            modelBuilder.Entity("Chatter.Domain.Entities.EFCore.Application.Room", b =>
                {
                    b.Navigation("Invitations");

                    b.Navigation("RoomChatterUsers");

                    b.Navigation("RoomPermissions");
                });

            modelBuilder.Entity("Chatter.Domain.Entities.EFCore.Identity.ChatterUser", b =>
                {
                    b.Navigation("ReceivedInvitations");

                    b.Navigation("RoomChatterUsers");

                    b.Navigation("SentInvitations");
                });
#pragma warning restore 612, 618
        }
    }
}

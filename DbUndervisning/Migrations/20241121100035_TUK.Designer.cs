﻿// <auto-generated />
using System;
using DbUndervisning.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DbUndervisning.Migrations
{
    [DbContext(typeof(WorldContext))]
    [Migration("20241121100035_TUK")]
    partial class TUK
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DbUndervisning.Model.Abilities.Ability", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClassConstraint")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Damage")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Ability");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("DbUndervisning.Model.Account.Character", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Class")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Currency")
                        .HasColumnType("float");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("Characters", "DbUndervisningProject");
                });

            modelBuilder.Entity("DbUndervisning.Model.Account.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("HashedPw")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Players", "DbUndervisningProject");
                });

            modelBuilder.Entity("DbUndervisning.Model.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CharacterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("Rarity")
                        .HasColumnType("int");

                    b.Property<string>("Texture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("Items", "DbUndervisningProject");
                });

            modelBuilder.Entity("DbUndervisning.Model.NPCStuff.NPC", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Attackable")
                        .HasColumnType("bit");

                    b.Property<string>("Behavior")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Class")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("Health")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Texture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable((string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("DbUndervisning.Model.Quests.Quest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CharacterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Dialogue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("HumanoidId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ItemToCreateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Objective")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("HumanoidId")
                        .IsUnique();

                    b.HasIndex("ItemToCreateId");

                    b.ToTable("Quests", "DbUndervisningProject");
                });

            modelBuilder.Entity("DbUndervisning.Model.Quests.Reward", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Currency")
                        .HasColumnType("float");

                    b.Property<double>("Experience")
                        .HasColumnType("float");

                    b.Property<Guid>("QuestId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("QuestId")
                        .IsUnique();

                    b.ToTable("Rewards", "DbUndervisningProject");
                });

            modelBuilder.Entity("DbUndervisning.Model.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Asset")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("placeholder siden jeg ikke har noget reelt asset");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions", "DbUndervisningProject");
                });

            modelBuilder.Entity("DbUndervisning.Model.Stat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Boost")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("StatType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("Stats", "DbUndervisningProject");
                });

            modelBuilder.Entity("DbUndervisning.Model.Abilities.CharacterAbility", b =>
                {
                    b.HasBaseType("DbUndervisning.Model.Abilities.Ability");

                    b.Property<Guid>("CharacterId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("CharacterId");

                    b.ToTable("CharacterAbilities", "DbUndervisningProject");
                });

            modelBuilder.Entity("DbUndervisning.Model.Abilities.HumanoidAbility", b =>
                {
                    b.HasBaseType("DbUndervisning.Model.Abilities.Ability");

                    b.Property<Guid>("HumanoidId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("HumanoidId");

                    b.ToTable("HumanoidAbilities", "DbUndervisningProject");
                });

            modelBuilder.Entity("DbUndervisning.Model.Abilities.MobAbility", b =>
                {
                    b.HasBaseType("DbUndervisning.Model.Abilities.Ability");

                    b.Property<Guid>("MobId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("MobId");

                    b.ToTable("MobAbilities", "DbUndervisningProject");
                });

            modelBuilder.Entity("DbUndervisning.Model.NPCStuff.Humanoid", b =>
                {
                    b.HasBaseType("DbUndervisning.Model.NPCStuff.NPC");

                    b.Property<Guid?>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("RegionId");

                    b.ToTable("Humanoids", "DbUndervisningProject");
                });

            modelBuilder.Entity("DbUndervisning.Model.NPCStuff.Mob", b =>
                {
                    b.HasBaseType("DbUndervisning.Model.NPCStuff.NPC");

                    b.Property<Guid?>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("RegionId");

                    b.ToTable("Mobs", "DbUndervisningProject");
                });

            modelBuilder.Entity("DbUndervisning.Model.Account.Character", b =>
                {
                    b.HasOne("DbUndervisning.Model.Account.Player", null)
                        .WithMany("Characters")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DbUndervisning.Model.Item", b =>
                {
                    b.HasOne("DbUndervisning.Model.Account.Character", null)
                        .WithMany("Items")
                        .HasForeignKey("CharacterId");
                });

            modelBuilder.Entity("DbUndervisning.Model.Quests.Quest", b =>
                {
                    b.HasOne("DbUndervisning.Model.Account.Character", null)
                        .WithMany("CompletedQuests")
                        .HasForeignKey("CharacterId");

                    b.HasOne("DbUndervisning.Model.NPCStuff.Humanoid", null)
                        .WithOne("Quest")
                        .HasForeignKey("DbUndervisning.Model.Quests.Quest", "HumanoidId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DbUndervisning.Model.Item", "ItemToCreate")
                        .WithMany()
                        .HasForeignKey("ItemToCreateId");

                    b.Navigation("ItemToCreate");
                });

            modelBuilder.Entity("DbUndervisning.Model.Quests.Reward", b =>
                {
                    b.HasOne("DbUndervisning.Model.Quests.Quest", null)
                        .WithOne("Reward")
                        .HasForeignKey("DbUndervisning.Model.Quests.Reward", "QuestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DbUndervisning.Model.Stat", b =>
                {
                    b.HasOne("DbUndervisning.Model.Item", null)
                        .WithMany("Stats")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DbUndervisning.Model.Abilities.CharacterAbility", b =>
                {
                    b.HasOne("DbUndervisning.Model.Account.Character", null)
                        .WithMany("Abilities")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DbUndervisning.Model.Abilities.Ability", null)
                        .WithOne()
                        .HasForeignKey("DbUndervisning.Model.Abilities.CharacterAbility", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DbUndervisning.Model.Abilities.HumanoidAbility", b =>
                {
                    b.HasOne("DbUndervisning.Model.NPCStuff.Humanoid", null)
                        .WithMany("Abilities")
                        .HasForeignKey("HumanoidId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DbUndervisning.Model.Abilities.Ability", null)
                        .WithOne()
                        .HasForeignKey("DbUndervisning.Model.Abilities.HumanoidAbility", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DbUndervisning.Model.Abilities.MobAbility", b =>
                {
                    b.HasOne("DbUndervisning.Model.Abilities.Ability", null)
                        .WithOne()
                        .HasForeignKey("DbUndervisning.Model.Abilities.MobAbility", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DbUndervisning.Model.NPCStuff.Mob", null)
                        .WithMany("Abilities")
                        .HasForeignKey("MobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DbUndervisning.Model.NPCStuff.Humanoid", b =>
                {
                    b.HasOne("DbUndervisning.Model.Region", null)
                        .WithMany("Humanoids")
                        .HasForeignKey("RegionId");
                });

            modelBuilder.Entity("DbUndervisning.Model.NPCStuff.Mob", b =>
                {
                    b.HasOne("DbUndervisning.Model.Region", null)
                        .WithMany("Mobs")
                        .HasForeignKey("RegionId");
                });

            modelBuilder.Entity("DbUndervisning.Model.Account.Character", b =>
                {
                    b.Navigation("Abilities");

                    b.Navigation("CompletedQuests");

                    b.Navigation("Items");
                });

            modelBuilder.Entity("DbUndervisning.Model.Account.Player", b =>
                {
                    b.Navigation("Characters");
                });

            modelBuilder.Entity("DbUndervisning.Model.Item", b =>
                {
                    b.Navigation("Stats");
                });

            modelBuilder.Entity("DbUndervisning.Model.Quests.Quest", b =>
                {
                    b.Navigation("Reward");
                });

            modelBuilder.Entity("DbUndervisning.Model.Region", b =>
                {
                    b.Navigation("Humanoids");

                    b.Navigation("Mobs");
                });

            modelBuilder.Entity("DbUndervisning.Model.NPCStuff.Humanoid", b =>
                {
                    b.Navigation("Abilities");

                    b.Navigation("Quest")
                        .IsRequired();
                });

            modelBuilder.Entity("DbUndervisning.Model.NPCStuff.Mob", b =>
                {
                    b.Navigation("Abilities");
                });
#pragma warning restore 612, 618
        }
    }
}

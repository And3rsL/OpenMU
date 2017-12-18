﻿namespace MUnique.OpenMU.Persistence.EntityFramework.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Migrations;
    using MUnique.OpenMU.Persistence.EntityFramework;

    [DbContext(typeof(EntityDataContext))]
    [Migration("00000000000000_Initial")]
    partial class Initial
    {
        /// <inheritdoc/>
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EMail");

                    b.Property<bool>("IsVaultExtended");

                    b.Property<string>("LoginName")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PasswordSalt");

                    b.Property<DateTime>("RegistrationDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("SecurityCode");

                    b.Property<int>("State");

                    b.Property<short>("TimeZone");

                    b.Property<Guid?>("VaultId");

                    b.Property<string>("VaultPassword");

                    b.HasKey("Id");

                    b.HasIndex("LoginName")
                        .IsUnique();

                    b.HasIndex("VaultId");

                    b.ToTable("Account","data");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.AccountCharacterClass", b =>
                {
                    b.Property<Guid>("AccountId");

                    b.Property<Guid>("CharacterClassId");

                    b.HasKey("AccountId", "CharacterClassId");

                    b.HasIndex("CharacterClassId");

                    b.ToTable("AccountCharacterClass","data");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.AttributeDefinition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Designation");

                    b.Property<Guid?>("GameConfigurationId");

                    b.HasKey("Id");

                    b.HasIndex("GameConfigurationId");

                    b.ToTable("AttributeDefinition","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.AttributeRelationship", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CharacterClassId");

                    b.Property<Guid?>("InputAttributeId");

                    b.Property<float>("InputOperand");

                    b.Property<int>("InputOperator");

                    b.Property<Guid?>("PowerUpDefinitionValueId");

                    b.Property<Guid?>("TargetAttributeId");

                    b.HasKey("Id");

                    b.HasIndex("CharacterClassId");

                    b.HasIndex("InputAttributeId");

                    b.HasIndex("PowerUpDefinitionValueId");

                    b.HasIndex("TargetAttributeId");

                    b.ToTable("AttributeRelationship","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.AttributeRequirement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AttributeId");

                    b.Property<Guid?>("ItemDefinitionId");

                    b.Property<int>("MinimumValue");

                    b.Property<Guid?>("SkillId");

                    b.Property<Guid?>("SkillId1");

                    b.HasKey("Id");

                    b.HasIndex("AttributeId");

                    b.HasIndex("ItemDefinitionId");

                    b.HasIndex("SkillId");

                    b.HasIndex("SkillId1");

                    b.ToTable("AttributeRequirement","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.Character", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AccountId");

                    b.Property<Guid?>("CharacterClassId")
                        .IsRequired();

                    b.Property<byte>("CharacterSlot");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<Guid?>("CurrentMapId");

                    b.Property<long>("Experience");

                    b.Property<Guid?>("GuildMemberInfoId");

                    b.Property<int>("InventoryExtensions");

                    b.Property<Guid?>("InventoryId");

                    b.Property<byte[]>("KeyConfiguration");

                    b.Property<int>("LevelUpPoints");

                    b.Property<long>("MasterExperience");

                    b.Property<int>("MasterLevelUpPoints");

                    b.Property<int>("Money")
                        .HasDefaultValue(0);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<int>("PlayerKillCount");

                    b.Property<byte>("PositionX");

                    b.Property<byte>("PositionY");

                    b.Property<byte[]>("QuestInfo");

                    b.Property<int>("State");

                    b.Property<int>("StateRemainingSeconds");

                    b.Property<int>("UsedFruitPoints");

                    b.Property<int>("UsedNegFruitPoints");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("CharacterClassId");

                    b.HasIndex("CurrentMapId");

                    b.HasIndex("GuildMemberInfoId");

                    b.HasIndex("InventoryId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Character","data");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.CharacterClass", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("CanGetCreated");

                    b.Property<byte>("CreationAllowedFlag");

                    b.Property<Guid?>("GameConfigurationId");

                    b.Property<Guid?>("HomeMapId");

                    b.Property<bool>("IsMasterClass");

                    b.Property<short>("LevelRequirementByCreation");

                    b.Property<int>("LevelWarpRequirementReductionPercent");

                    b.Property<string>("Name");

                    b.Property<Guid?>("NextGenerationClassId");

                    b.Property<byte>("Number");

                    b.Property<short>("PointsPerLevelUp");

                    b.HasKey("Id");

                    b.HasIndex("GameConfigurationId");

                    b.HasIndex("HomeMapId");

                    b.HasIndex("NextGenerationClassId");

                    b.ToTable("CharacterClass","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.CharacterDropItemGroup", b =>
                {
                    b.Property<Guid>("CharacterId");

                    b.Property<Guid>("DropItemGroupId");

                    b.HasKey("CharacterId", "DropItemGroupId");

                    b.HasIndex("DropItemGroupId");

                    b.ToTable("CharacterDropItemGroup","data");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.ConstValueAttribute", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CharacterClassId");

                    b.Property<Guid?>("DefinitionId");

                    b.Property<float>("Value");

                    b.HasKey("Id");

                    b.HasIndex("CharacterClassId");

                    b.HasIndex("DefinitionId");

                    b.ToTable("ConstValueAttribute","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.DropItemGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Chance");

                    b.Property<Guid?>("GameConfigurationId");

                    b.Property<int>("ItemType");

                    b.HasKey("Id");

                    b.HasIndex("GameConfigurationId");

                    b.ToTable("DropItemGroup","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.DropItemGroupItemDefinition", b =>
                {
                    b.Property<Guid>("DropItemGroupId");

                    b.Property<Guid>("ItemDefinitionId");

                    b.HasKey("DropItemGroupId", "ItemDefinitionId");

                    b.HasIndex("ItemDefinitionId");

                    b.ToTable("DropItemGroupItemDefinition","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.EnterGate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("GameMapDefinitionId");

                    b.Property<short>("LevelRequirement");

                    b.Property<short>("Number");

                    b.Property<Guid?>("TargetGateId");

                    b.Property<byte>("X1");

                    b.Property<byte>("X2");

                    b.Property<byte>("Y1");

                    b.Property<byte>("Y2");

                    b.HasKey("Id");

                    b.HasIndex("GameMapDefinitionId");

                    b.HasIndex("TargetGateId");

                    b.ToTable("EnterGate","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.ExitGate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Direction");

                    b.Property<Guid?>("MapId");

                    b.Property<byte>("X1");

                    b.Property<byte>("X2");

                    b.Property<byte>("Y1");

                    b.Property<byte>("Y2");

                    b.HasKey("Id");

                    b.HasIndex("MapId");

                    b.ToTable("ExitGate","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.FriendViewItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Accepted");

                    b.Property<Guid>("CharacterId");

                    b.Property<Guid>("FriendId");

                    b.Property<bool>("RequestOpen");

                    b.HasKey("Id");

                    b.ToTable("FriendViewItem","data");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.GameConfiguration", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("AreaSkillHitsPlayer");

                    b.Property<string>("CharacterNameRegex");

                    b.Property<byte>("InfoRange");

                    b.Property<byte>("MaximumCharactersPerAccount");

                    b.Property<int>("MaximumInventoryMoney");

                    b.Property<int>("MaximumLetters");

                    b.Property<short>("MaximumLevel");

                    b.Property<byte>("MaximumPartySize");

                    b.Property<int>("MaximumPasswordLength");

                    b.Property<int>("RecoveryInterval");

                    b.HasKey("Id");

                    b.ToTable("GameConfiguration","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.GameMapDefinition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("DeathSafezoneId");

                    b.Property<double>("ExpMultiplier");

                    b.Property<Guid?>("GameConfigurationId");

                    b.Property<Guid?>("GameServerConfigurationId");

                    b.Property<string>("Name");

                    b.Property<short>("Number");

                    b.Property<byte[]>("TerrainData");

                    b.HasKey("Id");

                    b.HasIndex("DeathSafezoneId");

                    b.HasIndex("GameConfigurationId");

                    b.HasIndex("GameServerConfigurationId");

                    b.ToTable("GameMapDefinition","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.GameMapDefinitionDropItemGroup", b =>
                {
                    b.Property<Guid>("GameMapDefinitionId");

                    b.Property<Guid>("DropItemGroupId");

                    b.HasKey("GameMapDefinitionId", "DropItemGroupId");

                    b.HasIndex("DropItemGroupId");

                    b.ToTable("GameMapDefinitionDropItemGroup","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.GameServerConfiguration", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<short>("MaximumNPCs");

                    b.Property<short>("MaximumPlayers");

                    b.HasKey("Id");

                    b.ToTable("GameServerConfiguration","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.GameServerDefinition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<Guid?>("GameConfigurationId");

                    b.Property<int>("NetworkPort");

                    b.Property<Guid?>("ServerConfigurationId");

                    b.Property<byte>("ServerID");

                    b.HasKey("Id");

                    b.HasIndex("GameConfigurationId");

                    b.HasIndex("ServerConfigurationId");

                    b.ToTable("GameServerDefinition","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.Guild", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AllianceGuildId");

                    b.Property<Guid?>("HostilityId");

                    b.Property<byte[]>("Logo");

                    b.Property<string>("Master");

                    b.Property<Guid>("MasterId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(8);

                    b.Property<string>("Notice");

                    b.Property<int>("Score");

                    b.HasKey("Id");

                    b.HasIndex("AllianceGuildId");

                    b.HasIndex("HostilityId");

                    b.ToTable("Guild","data");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.GuildMemberInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CharacterId");

                    b.Property<Guid>("GuildId");

                    b.Property<byte>("ServerId");

                    b.Property<byte>("Status");

                    b.HasKey("Id");

                    b.HasIndex("GuildId");

                    b.ToTable("GuildMemberInfo","data");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.IncreasableItemOption", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ItemOptionDefinitionId");

                    b.Property<int>("Number");

                    b.Property<Guid?>("OptionTypeId");

                    b.Property<Guid?>("PowerUpDefinitionId");

                    b.HasKey("Id");

                    b.HasIndex("ItemOptionDefinitionId");

                    b.HasIndex("OptionTypeId");

                    b.HasIndex("PowerUpDefinitionId");

                    b.ToTable("IncreasableItemOption","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("DefinitionId");

                    b.Property<byte>("Durability");

                    b.Property<bool>("HasSkill");

                    b.Property<byte>("ItemSlot");

                    b.Property<byte>("Level");

                    b.Property<int>("SocketCount");

                    b.Property<Guid?>("StorageId");

                    b.HasKey("Id");

                    b.HasIndex("DefinitionId");

                    b.HasIndex("StorageId");

                    b.ToTable("Item","data");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.ItemBasePowerUpDefinition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("BaseValue");

                    b.Property<Guid?>("ItemDefinitionId");

                    b.Property<Guid?>("TargetAttributeId");

                    b.HasKey("Id");

                    b.HasIndex("ItemDefinitionId");

                    b.HasIndex("TargetAttributeId");

                    b.ToTable("ItemBasePowerUpDefinition","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.ItemCrafting", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ItemCraftingHandlerClassName");

                    b.Property<Guid?>("MonsterDefinitionId");

                    b.Property<string>("Name");

                    b.Property<byte>("Number");

                    b.Property<Guid?>("SimpleCraftingSettingsId");

                    b.HasKey("Id");

                    b.HasIndex("MonsterDefinitionId");

                    b.HasIndex("SimpleCraftingSettingsId");

                    b.ToTable("ItemCrafting","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.ItemCraftingRequiredItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte>("AddPercentage");

                    b.Property<int>("FailResult");

                    b.Property<Guid?>("ItemDefinitionId");

                    b.Property<byte>("MinAmount");

                    b.Property<byte>("MinLvl");

                    b.Property<int>("NPCPriceDiv");

                    b.Property<byte>("RefID");

                    b.Property<Guid?>("SimpleCraftingSettingsId");

                    b.Property<int>("SuccessResult");

                    b.HasKey("Id");

                    b.HasIndex("ItemDefinitionId");

                    b.HasIndex("SimpleCraftingSettingsId");

                    b.ToTable("ItemCraftingRequiredItem","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.ItemCraftingRequiredItemItemOptionType", b =>
                {
                    b.Property<Guid>("ItemCraftingRequiredItemId");

                    b.Property<Guid>("ItemOptionTypeId");

                    b.HasKey("ItemCraftingRequiredItemId", "ItemOptionTypeId");

                    b.HasIndex("ItemOptionTypeId");

                    b.ToTable("ItemCraftingRequiredItemItemOptionType","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.ItemCraftingResultItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte>("AddLevel");

                    b.Property<Guid?>("ItemDefinitionId");

                    b.Property<byte>("RandLvlMax");

                    b.Property<byte>("RandLvlMin");

                    b.Property<byte>("RefID");

                    b.Property<Guid?>("SimpleCraftingSettingsId");

                    b.HasKey("Id");

                    b.HasIndex("ItemDefinitionId");

                    b.HasIndex("SimpleCraftingSettingsId");

                    b.ToTable("ItemCraftingResultItem","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.ItemDefinition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConsumeHandlerClass");

                    b.Property<byte>("DropLevel");

                    b.Property<bool>("DropsFromMonsters");

                    b.Property<byte>("Durability");

                    b.Property<Guid?>("GameConfigurationId");

                    b.Property<byte>("Group");

                    b.Property<byte>("Height");

                    b.Property<Guid?>("ItemSlotId");

                    b.Property<int>("MaximumSockets");

                    b.Property<string>("Name");

                    b.Property<byte>("Number");

                    b.Property<Guid?>("SkillId");

                    b.Property<int>("Value");

                    b.Property<byte>("Width");

                    b.HasKey("Id");

                    b.HasIndex("GameConfigurationId");

                    b.HasIndex("ItemSlotId");

                    b.HasIndex("SkillId");

                    b.ToTable("ItemDefinition","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.ItemDefinitionCharacterClass", b =>
                {
                    b.Property<Guid>("ItemDefinitionId");

                    b.Property<Guid>("CharacterClassId");

                    b.HasKey("ItemDefinitionId", "CharacterClassId");

                    b.HasIndex("CharacterClassId");

                    b.ToTable("ItemDefinitionCharacterClass","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.ItemDefinitionItemSetGroup", b =>
                {
                    b.Property<Guid>("ItemDefinitionId");

                    b.Property<Guid>("ItemSetGroupId");

                    b.HasKey("ItemDefinitionId", "ItemSetGroupId");

                    b.HasIndex("ItemSetGroupId");

                    b.ToTable("ItemDefinitionItemSetGroup","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.ItemItemSetGroup", b =>
                {
                    b.Property<Guid>("ItemId");

                    b.Property<Guid>("ItemSetGroupId");

                    b.HasKey("ItemId", "ItemSetGroupId");

                    b.HasIndex("ItemSetGroupId");

                    b.ToTable("ItemItemSetGroup","data");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.ItemOfItemSet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("BonusOptionId");

                    b.Property<Guid?>("ItemDefinitionId");

                    b.Property<Guid?>("ItemSetGroupId");

                    b.HasKey("Id");

                    b.HasIndex("BonusOptionId");

                    b.HasIndex("ItemDefinitionId");

                    b.HasIndex("ItemSetGroupId");

                    b.ToTable("ItemOfItemSet","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.ItemOption", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Number");

                    b.Property<Guid?>("OptionTypeId");

                    b.Property<Guid?>("PowerUpDefinitionId");

                    b.HasKey("Id");

                    b.HasIndex("OptionTypeId");

                    b.HasIndex("PowerUpDefinitionId");

                    b.ToTable("ItemOption","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.ItemOptionDefinition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("AddChance");

                    b.Property<bool>("AddsRandomly");

                    b.Property<Guid?>("GameConfigurationId");

                    b.Property<Guid?>("ItemDefinitionId");

                    b.Property<int>("MaximumOptionsPerItem");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("GameConfigurationId");

                    b.HasIndex("ItemDefinitionId");

                    b.ToTable("ItemOptionDefinition","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.ItemOptionLink", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ItemId");

                    b.Property<Guid?>("ItemOptionId");

                    b.Property<int>("Level");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("ItemOptionId");

                    b.ToTable("ItemOptionLink","data");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.ItemOptionOfLevel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("IncreasableItemOptionId");

                    b.Property<int>("Level");

                    b.Property<Guid?>("PowerUpDefinitionId");

                    b.Property<int>("RequiredItemLevel");

                    b.HasKey("Id");

                    b.HasIndex("IncreasableItemOptionId");

                    b.HasIndex("PowerUpDefinitionId");

                    b.ToTable("ItemOptionOfLevel","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.ItemOptionType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<Guid?>("GameConfigurationId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("GameConfigurationId");

                    b.ToTable("ItemOptionType","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.ItemSetGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("AlwaysApplies");

                    b.Property<bool>("CountDistinct");

                    b.Property<Guid?>("GameConfigurationId");

                    b.Property<int>("MinimumItemCount");

                    b.Property<int>("MinimumSetLevel");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("GameConfigurationId");

                    b.ToTable("ItemSetGroup","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.ItemSetGroupItemOption", b =>
                {
                    b.Property<Guid>("ItemSetGroupId");

                    b.Property<Guid>("ItemOptionId");

                    b.HasKey("ItemSetGroupId", "ItemOptionId");

                    b.HasIndex("ItemOptionId");

                    b.ToTable("ItemSetGroupItemOption","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.ItemSlotType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<Guid?>("GameConfigurationId");

                    b.Property<string>("RawItemSlots")
                        .HasColumnName("ItemSlots");

                    b.HasKey("Id");

                    b.HasIndex("GameConfigurationId");

                    b.ToTable("ItemSlotType","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.ItemStorage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Money");

                    b.HasKey("Id");

                    b.ToTable("ItemStorage","data");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.JewelMix", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("GameConfigurationId");

                    b.Property<Guid?>("MixedJewelId");

                    b.Property<byte>("Number");

                    b.Property<Guid?>("SingleJewelId");

                    b.HasKey("Id");

                    b.HasIndex("GameConfigurationId");

                    b.HasIndex("MixedJewelId");

                    b.HasIndex("SingleJewelId");

                    b.ToTable("JewelMix","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.LetterHeader", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CharacterId");

                    b.Property<DateTime>("LetterDate");

                    b.Property<bool>("ReadFlag");

                    b.Property<string>("Receiver");

                    b.Property<string>("Sender");

                    b.Property<string>("Subject");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("LetterHeader","data");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.LevelBonus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("AdditionalValue");

                    b.Property<Guid?>("ItemBasePowerUpDefinitionId");

                    b.Property<int>("Level");

                    b.HasKey("Id");

                    b.HasIndex("ItemBasePowerUpDefinitionId");

                    b.ToTable("LevelBonus","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.LevelDependentDamage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Damage");

                    b.Property<int>("Level");

                    b.Property<Guid?>("SkillId");

                    b.HasKey("Id");

                    b.HasIndex("SkillId");

                    b.ToTable("LevelDependentDamage","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.MagicEffectDefinition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("GameConfigurationId");

                    b.Property<bool>("InformObservers");

                    b.Property<string>("Name");

                    b.Property<byte>("Number");

                    b.Property<Guid?>("PowerUpDefinitionId");

                    b.Property<bool>("SendDuration");

                    b.Property<bool>("StopByDeath");

                    b.Property<byte>("SubType");

                    b.HasKey("Id");

                    b.HasIndex("GameConfigurationId");

                    b.HasIndex("PowerUpDefinitionId");

                    b.ToTable("MagicEffectDefinition","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.MainPacketHandlerConfiguration", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppearanceSerializerClassName");

                    b.Property<byte[]>("ClientSerial");

                    b.Property<byte[]>("ClientVersion");

                    b.Property<Guid?>("GameServerConfigurationId");

                    b.HasKey("Id");

                    b.HasIndex("GameServerConfigurationId");

                    b.ToTable("MainPacketHandlerConfiguration","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.MasterSkillDefinition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CharacterClassId");

                    b.Property<byte>("Rank");

                    b.Property<Guid?>("RootId");

                    b.HasKey("Id");

                    b.HasIndex("CharacterClassId");

                    b.HasIndex("RootId");

                    b.ToTable("MasterSkillDefinition","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.MasterSkillDefinitionSkill", b =>
                {
                    b.Property<Guid>("MasterSkillDefinitionId");

                    b.Property<Guid>("SkillId");

                    b.HasKey("MasterSkillDefinitionId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("MasterSkillDefinitionSkill","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.MasterSkillRoot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("GameConfigurationId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("GameConfigurationId");

                    b.ToTable("MasterSkillRoot","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.MonsterAttribute", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AttributeDefinitionId");

                    b.Property<Guid?>("MonsterDefinitionId");

                    b.Property<float>("Value");

                    b.HasKey("Id");

                    b.HasIndex("AttributeDefinitionId");

                    b.HasIndex("MonsterDefinitionId");

                    b.ToTable("MonsterAttribute","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.MonsterDefinition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<TimeSpan>("AttackDelay");

                    b.Property<byte>("AttackRange");

                    b.Property<Guid?>("AttackSkillId");

                    b.Property<byte>("Attribute");

                    b.Property<string>("Designation");

                    b.Property<Guid?>("GameConfigurationId");

                    b.Property<Guid?>("MerchantStoreId");

                    b.Property<TimeSpan>("MoveDelay");

                    b.Property<byte>("MoveRange");

                    b.Property<int>("NpcWindow");

                    b.Property<short>("Number");

                    b.Property<int>("NumberOfMaximumItemDrops");

                    b.Property<TimeSpan>("RespawnDelay");

                    b.Property<short>("Skill");

                    b.Property<short>("ViewRange");

                    b.HasKey("Id");

                    b.HasIndex("AttackSkillId");

                    b.HasIndex("GameConfigurationId");

                    b.HasIndex("MerchantStoreId");

                    b.ToTable("MonsterDefinition","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.MonsterDefinitionDropItemGroup", b =>
                {
                    b.Property<Guid>("MonsterDefinitionId");

                    b.Property<Guid>("DropItemGroupId");

                    b.HasKey("MonsterDefinitionId", "DropItemGroupId");

                    b.HasIndex("DropItemGroupId");

                    b.ToTable("MonsterDefinitionDropItemGroup","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.MonsterSpawnArea", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Direction");

                    b.Property<Guid?>("GameMapId");

                    b.Property<Guid?>("MonsterDefinitionId");

                    b.Property<short>("Quantity");

                    b.Property<int>("SpawnTrigger");

                    b.Property<byte>("X1");

                    b.Property<byte>("X2");

                    b.Property<byte>("Y1");

                    b.Property<byte>("Y2");

                    b.HasKey("Id");

                    b.HasIndex("GameMapId");

                    b.HasIndex("MonsterDefinitionId");

                    b.ToTable("MonsterSpawnArea","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.PacketHandlerConfiguration", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("MainPacketHandlerConfigurationId");

                    b.Property<bool>("NeedsToBeEncrypted");

                    b.Property<string>("PacketHandlerClassName");

                    b.Property<Guid?>("PacketHandlerConfigurationId");

                    b.Property<byte>("PacketIdentifier");

                    b.HasKey("Id");

                    b.HasIndex("MainPacketHandlerConfigurationId");

                    b.HasIndex("PacketHandlerConfigurationId");

                    b.ToTable("PacketHandlerConfiguration","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.PowerUpDefinition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("BoostId");

                    b.Property<Guid?>("TargetAttributeId");

                    b.HasKey("Id");

                    b.HasIndex("BoostId");

                    b.HasIndex("TargetAttributeId");

                    b.ToTable("PowerUpDefinition","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.PowerUpDefinitionValue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AggregateType");

                    b.Property<Guid?>("ParentAsBoostId");

                    b.Property<Guid?>("ParentAsDurationId");

                    b.Property<float>("Value");

                    b.HasKey("Id");

                    b.ToTable("PowerUpDefinitionValue","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.PowerUpDefinitionWithDuration", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("BoostId");

                    b.Property<Guid?>("DurationId");

                    b.Property<Guid?>("TargetAttributeId");

                    b.HasKey("Id");

                    b.HasIndex("BoostId")
                        .IsUnique();

                    b.HasIndex("DurationId")
                        .IsUnique();

                    b.HasIndex("TargetAttributeId");

                    b.ToTable("PowerUpDefinitionWithDuration","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.SimpleCraftingSettings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte>("ExcOptionChance");

                    b.Property<byte>("LuckOptionChance");

                    b.Property<byte>("MaxExcOptions");

                    b.Property<int>("Money");

                    b.Property<bool>("MultipleAllowed");

                    b.Property<int>("ResultItemSelect");

                    b.Property<byte>("SkillOptionChance");

                    b.Property<byte>("SuccessPercent");

                    b.HasKey("Id");

                    b.ToTable("SimpleCraftingSettings","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.Skill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DamageType");

                    b.Property<Guid?>("GameConfigurationId");

                    b.Property<Guid?>("MagicEffectDefId");

                    b.Property<string>("Name");

                    b.Property<short>("Range");

                    b.Property<short>("SkillID");

                    b.Property<int>("SkillType");

                    b.HasKey("Id");

                    b.HasIndex("GameConfigurationId");

                    b.HasIndex("MagicEffectDefId");

                    b.ToTable("Skill","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.SkillCharacterClass", b =>
                {
                    b.Property<Guid>("SkillId");

                    b.Property<Guid>("CharacterClassId");

                    b.HasKey("SkillId", "CharacterClassId");

                    b.HasIndex("CharacterClassId");

                    b.ToTable("SkillCharacterClass","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.SkillEntry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CharacterId");

                    b.Property<int>("Level");

                    b.Property<Guid?>("SkillId");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("SkillId");

                    b.ToTable("SkillEntry","data");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.SkillMasterSkillDefinition", b =>
                {
                    b.Property<Guid>("SkillId");

                    b.Property<Guid>("MasterSkillDefinitionId");

                    b.HasKey("SkillId", "MasterSkillDefinitionId");

                    b.HasIndex("MasterSkillDefinitionId");

                    b.ToTable("SkillMasterSkillDefinition","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.SkillPowerUpDefinition", b =>
                {
                    b.Property<int>("Key");

                    b.Property<Guid>("ValueId");

                    b.Property<Guid?>("SkillId");

                    b.HasKey("Key", "ValueId");

                    b.HasIndex("SkillId");

                    b.HasIndex("ValueId");

                    b.ToTable("SkillPowerUpDefinition","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.StatAttribute", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CharacterId");

                    b.Property<Guid?>("DefinitionId");

                    b.Property<float>("Value");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("DefinitionId");

                    b.ToTable("StatAttribute","data");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.StatAttributeDefinition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AttributeId");

                    b.Property<float>("BaseValue");

                    b.Property<Guid?>("CharacterClassId");

                    b.Property<bool>("IncreasableByPlayer");

                    b.HasKey("Id");

                    b.HasIndex("AttributeId");

                    b.HasIndex("CharacterClassId");

                    b.ToTable("StatAttributeDefinition","config");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.Account", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.ItemStorage", "RawVault")
                        .WithMany()
                        .HasForeignKey("VaultId");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.AccountCharacterClass", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.Account", "Account")
                        .WithMany("JoinedCharacterClasss")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.CharacterClass", "CharacterClass")
                        .WithMany()
                        .HasForeignKey("CharacterClassId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.AttributeDefinition", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.GameConfiguration")
                        .WithMany("RawAttributes")
                        .HasForeignKey("GameConfigurationId");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.AttributeRelationship", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.CharacterClass")
                        .WithMany("RawAttributeCombinations")
                        .HasForeignKey("CharacterClassId");

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.AttributeDefinition", "RawInputAttribute")
                        .WithMany()
                        .HasForeignKey("InputAttributeId");

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.PowerUpDefinitionValue")
                        .WithMany("RawRelatedValues")
                        .HasForeignKey("PowerUpDefinitionValueId");

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.AttributeDefinition", "RawTargetAttribute")
                        .WithMany()
                        .HasForeignKey("TargetAttributeId");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.AttributeRequirement", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.AttributeDefinition", "RawAttribute")
                        .WithMany()
                        .HasForeignKey("AttributeId");

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.ItemDefinition")
                        .WithMany("RawRequirements")
                        .HasForeignKey("ItemDefinitionId");

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.Skill")
                        .WithMany("RawConsumeRequirements")
                        .HasForeignKey("SkillId");

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.Skill")
                        .WithMany("RawRequirements")
                        .HasForeignKey("SkillId1");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.Character", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.Account")
                        .WithMany("RawCharacters")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.CharacterClass", "RawCharacterClass")
                        .WithMany()
                        .HasForeignKey("CharacterClassId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.GameMapDefinition", "RawCurrentMap")
                        .WithMany()
                        .HasForeignKey("CurrentMapId");

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.GuildMemberInfo", "RawGuildMemberInfo")
                        .WithMany()
                        .HasForeignKey("GuildMemberInfoId");

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.ItemStorage", "RawInventory")
                        .WithMany()
                        .HasForeignKey("InventoryId");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.CharacterClass", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.GameConfiguration")
                        .WithMany("RawCharacterClasses")
                        .HasForeignKey("GameConfigurationId");

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.GameMapDefinition", "RawHomeMap")
                        .WithMany()
                        .HasForeignKey("HomeMapId");

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.CharacterClass", "RawNextGenerationClass")
                        .WithMany()
                        .HasForeignKey("NextGenerationClassId");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.CharacterDropItemGroup", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.Character", "Character")
                        .WithMany("JoinedDropItemGroups")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.DropItemGroup", "DropItemGroup")
                        .WithMany()
                        .HasForeignKey("DropItemGroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.ConstValueAttribute", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.CharacterClass", "CharacterClass")
                        .WithMany("RawBaseAttributeValues")
                        .HasForeignKey("CharacterClassId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.AttributeDefinition", "RawDefinition")
                        .WithMany()
                        .HasForeignKey("DefinitionId");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.DropItemGroup", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.GameConfiguration")
                        .WithMany("RawBaseDropItemGroups")
                        .HasForeignKey("GameConfigurationId");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.DropItemGroupItemDefinition", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.DropItemGroup", "DropItemGroup")
                        .WithMany("JoinedItemDefinitions")
                        .HasForeignKey("DropItemGroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.ItemDefinition", "ItemDefinition")
                        .WithMany()
                        .HasForeignKey("ItemDefinitionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.EnterGate", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.GameMapDefinition")
                        .WithMany("RawGates")
                        .HasForeignKey("GameMapDefinitionId");

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.ExitGate", "RawTargetGate")
                        .WithMany()
                        .HasForeignKey("TargetGateId");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.ExitGate", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.GameMapDefinition", "RawMap")
                        .WithMany("RawSpawnGates")
                        .HasForeignKey("MapId");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.GameMapDefinition", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.ExitGate", "RawDeathSafezone")
                        .WithMany()
                        .HasForeignKey("DeathSafezoneId");

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.GameConfiguration")
                        .WithMany("RawMaps")
                        .HasForeignKey("GameConfigurationId");

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.GameServerConfiguration")
                        .WithMany("RawMaps")
                        .HasForeignKey("GameServerConfigurationId");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.GameMapDefinitionDropItemGroup", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.DropItemGroup", "DropItemGroup")
                        .WithMany()
                        .HasForeignKey("DropItemGroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.GameMapDefinition", "GameMapDefinition")
                        .WithMany("JoinedDropItemGroups")
                        .HasForeignKey("GameMapDefinitionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.GameServerDefinition", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.GameConfiguration", "RawGameConfiguration")
                        .WithMany()
                        .HasForeignKey("GameConfigurationId");

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.GameServerConfiguration", "RawServerConfiguration")
                        .WithMany()
                        .HasForeignKey("ServerConfigurationId");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.Guild", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.Guild", "RawAllianceGuild")
                        .WithMany()
                        .HasForeignKey("AllianceGuildId");

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.Guild", "RawHostility")
                        .WithMany()
                        .HasForeignKey("HostilityId");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.GuildMemberInfo", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.Guild")
                        .WithMany("RawMembers")
                        .HasForeignKey("GuildId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.IncreasableItemOption", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.ItemOptionDefinition")
                        .WithMany("RawPossibleOptions")
                        .HasForeignKey("ItemOptionDefinitionId");

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.ItemOptionType", "RawOptionType")
                        .WithMany()
                        .HasForeignKey("OptionTypeId");

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.PowerUpDefinition", "RawPowerUpDefinition")
                        .WithMany()
                        .HasForeignKey("PowerUpDefinitionId");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.Item", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.ItemDefinition", "RawDefinition")
                        .WithMany()
                        .HasForeignKey("DefinitionId");

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.ItemStorage", "RawStorage")
                        .WithMany("RawItems")
                        .HasForeignKey("StorageId");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.ItemBasePowerUpDefinition", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.ItemDefinition")
                        .WithMany("RawBasePowerUpAttributes")
                        .HasForeignKey("ItemDefinitionId");

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.AttributeDefinition", "RawTargetAttribute")
                        .WithMany()
                        .HasForeignKey("TargetAttributeId");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.ItemCrafting", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.MonsterDefinition")
                        .WithMany("RawItemCraftings")
                        .HasForeignKey("MonsterDefinitionId");

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.SimpleCraftingSettings", "RawSimpleCraftingSettings")
                        .WithMany()
                        .HasForeignKey("SimpleCraftingSettingsId");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.ItemCraftingRequiredItem", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.ItemDefinition", "RawItemDefinition")
                        .WithMany()
                        .HasForeignKey("ItemDefinitionId");

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.SimpleCraftingSettings")
                        .WithMany("RawRequiredItems")
                        .HasForeignKey("SimpleCraftingSettingsId");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.ItemCraftingRequiredItemItemOptionType", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.ItemCraftingRequiredItem", "ItemCraftingRequiredItem")
                        .WithMany("JoinedItemOptionTypes")
                        .HasForeignKey("ItemCraftingRequiredItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.ItemOptionType", "ItemOptionType")
                        .WithMany()
                        .HasForeignKey("ItemOptionTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.ItemCraftingResultItem", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.ItemDefinition", "RawItemDefinition")
                        .WithMany()
                        .HasForeignKey("ItemDefinitionId");

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.SimpleCraftingSettings")
                        .WithMany("RawResultItems")
                        .HasForeignKey("SimpleCraftingSettingsId");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.ItemDefinition", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.GameConfiguration")
                        .WithMany("RawItems")
                        .HasForeignKey("GameConfigurationId");

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.ItemSlotType", "RawItemSlot")
                        .WithMany()
                        .HasForeignKey("ItemSlotId");

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.Skill", "RawSkill")
                        .WithMany()
                        .HasForeignKey("SkillId");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.ItemDefinitionCharacterClass", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.CharacterClass", "CharacterClass")
                        .WithMany()
                        .HasForeignKey("CharacterClassId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.ItemDefinition", "ItemDefinition")
                        .WithMany("JoinedCharacterClasss")
                        .HasForeignKey("ItemDefinitionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.ItemDefinitionItemSetGroup", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.ItemDefinition", "ItemDefinition")
                        .WithMany("JoinedItemSetGroups")
                        .HasForeignKey("ItemDefinitionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.ItemSetGroup", "ItemSetGroup")
                        .WithMany()
                        .HasForeignKey("ItemSetGroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.ItemItemSetGroup", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.Item", "Item")
                        .WithMany("JoinedItemSetGroups")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.ItemSetGroup", "ItemSetGroup")
                        .WithMany()
                        .HasForeignKey("ItemSetGroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.ItemOfItemSet", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.IncreasableItemOption", "RawBonusOption")
                        .WithMany()
                        .HasForeignKey("BonusOptionId");

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.ItemDefinition", "RawItemDefinition")
                        .WithMany()
                        .HasForeignKey("ItemDefinitionId");

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.ItemSetGroup")
                        .WithMany("RawItems")
                        .HasForeignKey("ItemSetGroupId");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.ItemOption", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.ItemOptionType", "RawOptionType")
                        .WithMany()
                        .HasForeignKey("OptionTypeId");

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.PowerUpDefinition", "RawPowerUpDefinition")
                        .WithMany()
                        .HasForeignKey("PowerUpDefinitionId");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.ItemOptionDefinition", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.GameConfiguration")
                        .WithMany("RawItemOptions")
                        .HasForeignKey("GameConfigurationId");

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.ItemDefinition")
                        .WithMany("RawPossibleItemOptions")
                        .HasForeignKey("ItemDefinitionId");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.ItemOptionLink", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.Item")
                        .WithMany("RawItemOptions")
                        .HasForeignKey("ItemId");

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.ItemOption", "RawItemOption")
                        .WithMany()
                        .HasForeignKey("ItemOptionId");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.ItemOptionOfLevel", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.IncreasableItemOption")
                        .WithMany("RawLevelDependentOptions")
                        .HasForeignKey("IncreasableItemOptionId");

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.PowerUpDefinition", "RawPowerUpDefinition")
                        .WithMany()
                        .HasForeignKey("PowerUpDefinitionId");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.ItemOptionType", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.GameConfiguration")
                        .WithMany("RawItemOptionTypes")
                        .HasForeignKey("GameConfigurationId");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.ItemSetGroup", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.GameConfiguration")
                        .WithMany("RawItemSetGroups")
                        .HasForeignKey("GameConfigurationId");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.ItemSetGroupItemOption", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.ItemOption", "ItemOption")
                        .WithMany()
                        .HasForeignKey("ItemOptionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.ItemSetGroup", "ItemSetGroup")
                        .WithMany("JoinedItemOptions")
                        .HasForeignKey("ItemSetGroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.ItemSlotType", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.GameConfiguration")
                        .WithMany("RawItemSlotTypes")
                        .HasForeignKey("GameConfigurationId");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.JewelMix", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.GameConfiguration")
                        .WithMany("RawJewelMixes")
                        .HasForeignKey("GameConfigurationId");

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.ItemDefinition", "RawMixedJewel")
                        .WithMany()
                        .HasForeignKey("MixedJewelId");

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.ItemDefinition", "RawSingleJewel")
                        .WithMany()
                        .HasForeignKey("SingleJewelId");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.LetterHeader", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.Character")
                        .WithMany("RawLetters")
                        .HasForeignKey("CharacterId");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.LevelBonus", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.ItemBasePowerUpDefinition")
                        .WithMany("RawBonusPerLevel")
                        .HasForeignKey("ItemBasePowerUpDefinitionId");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.LevelDependentDamage", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.Skill")
                        .WithMany("RawAttackDamage")
                        .HasForeignKey("SkillId");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.MagicEffectDefinition", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.GameConfiguration")
                        .WithMany("RawMagicEffects")
                        .HasForeignKey("GameConfigurationId");

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.PowerUpDefinitionWithDuration", "RawPowerUpDefinition")
                        .WithMany()
                        .HasForeignKey("PowerUpDefinitionId");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.MainPacketHandlerConfiguration", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.GameServerConfiguration")
                        .WithMany("RawSupportedPacketHandlers")
                        .HasForeignKey("GameServerConfigurationId");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.MasterSkillDefinition", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.CharacterClass", "RawCharacterClass")
                        .WithMany()
                        .HasForeignKey("CharacterClassId");

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.MasterSkillRoot", "RawRoot")
                        .WithMany()
                        .HasForeignKey("RootId");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.MasterSkillDefinitionSkill", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.MasterSkillDefinition", "MasterSkillDefinition")
                        .WithMany("JoinedSkills")
                        .HasForeignKey("MasterSkillDefinitionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.MasterSkillRoot", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.GameConfiguration")
                        .WithMany("RawMasterSkillRoots")
                        .HasForeignKey("GameConfigurationId");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.MonsterAttribute", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.AttributeDefinition", "RawAttributeDefinition")
                        .WithMany()
                        .HasForeignKey("AttributeDefinitionId");

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.MonsterDefinition")
                        .WithMany("RawAttributes")
                        .HasForeignKey("MonsterDefinitionId");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.MonsterDefinition", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.Skill", "RawAttackSkill")
                        .WithMany()
                        .HasForeignKey("AttackSkillId");

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.GameConfiguration")
                        .WithMany("RawMonsters")
                        .HasForeignKey("GameConfigurationId");

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.ItemStorage", "RawMerchantStore")
                        .WithMany()
                        .HasForeignKey("MerchantStoreId");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.MonsterDefinitionDropItemGroup", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.DropItemGroup", "DropItemGroup")
                        .WithMany()
                        .HasForeignKey("DropItemGroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.MonsterDefinition", "MonsterDefinition")
                        .WithMany("JoinedDropItemGroups")
                        .HasForeignKey("MonsterDefinitionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.MonsterSpawnArea", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.GameMapDefinition", "RawGameMap")
                        .WithMany("RawMonsterSpawns")
                        .HasForeignKey("GameMapId");

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.MonsterDefinition", "RawMonsterDefinition")
                        .WithMany()
                        .HasForeignKey("MonsterDefinitionId");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.PacketHandlerConfiguration", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.MainPacketHandlerConfiguration")
                        .WithMany("RawPacketHandlers")
                        .HasForeignKey("MainPacketHandlerConfigurationId");

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.PacketHandlerConfiguration")
                        .WithMany("RawSubPacketHandlers")
                        .HasForeignKey("PacketHandlerConfigurationId");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.PowerUpDefinition", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.PowerUpDefinitionValue", "RawBoost")
                        .WithMany()
                        .HasForeignKey("BoostId");

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.AttributeDefinition", "RawTargetAttribute")
                        .WithMany()
                        .HasForeignKey("TargetAttributeId");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.PowerUpDefinitionWithDuration", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.PowerUpDefinitionValue", "RawBoost")
                        .WithOne("ParentAsBoost")
                        .HasForeignKey("MUnique.OpenMU.Persistence.EntityFramework.PowerUpDefinitionWithDuration", "BoostId")
                        .HasConstraintName("PowerUpDefinitionWithDuration_Boost")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.PowerUpDefinitionValue", "RawDuration")
                        .WithOne("ParentAsDuration")
                        .HasForeignKey("MUnique.OpenMU.Persistence.EntityFramework.PowerUpDefinitionWithDuration", "DurationId")
                        .HasConstraintName("PowerUpDefinitionWithDuration_Duration")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.AttributeDefinition", "RawTargetAttribute")
                        .WithMany()
                        .HasForeignKey("TargetAttributeId");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.Skill", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.GameConfiguration")
                        .WithMany("RawSkills")
                        .HasForeignKey("GameConfigurationId");

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.MagicEffectDefinition", "RawMagicEffectDef")
                        .WithMany()
                        .HasForeignKey("MagicEffectDefId");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.SkillCharacterClass", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.CharacterClass", "CharacterClass")
                        .WithMany()
                        .HasForeignKey("CharacterClassId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.Skill", "Skill")
                        .WithMany("JoinedCharacterClasss")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.SkillEntry", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.Character")
                        .WithMany("RawLearnedSkills")
                        .HasForeignKey("CharacterId");

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.Skill", "RawSkill")
                        .WithMany()
                        .HasForeignKey("SkillId");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.SkillMasterSkillDefinition", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.MasterSkillDefinition", "MasterSkillDefinition")
                        .WithMany()
                        .HasForeignKey("MasterSkillDefinitionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.Skill", "Skill")
                        .WithMany("JoinedMasterSkillDefinitions")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.SkillPowerUpDefinition", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.Skill")
                        .WithMany("RawPassivePowerUps")
                        .HasForeignKey("SkillId");

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.PowerUpDefinition", "Value")
                        .WithMany()
                        .HasForeignKey("ValueId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.StatAttribute", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.Character")
                        .WithMany("RawAttributes")
                        .HasForeignKey("CharacterId");

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.AttributeDefinition", "RawDefinition")
                        .WithMany()
                        .HasForeignKey("DefinitionId");
                });

            modelBuilder.Entity("MUnique.OpenMU.Persistence.EntityFramework.StatAttributeDefinition", b =>
                {
                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.AttributeDefinition", "RawAttribute")
                        .WithMany()
                        .HasForeignKey("AttributeId");

                    b.HasOne("MUnique.OpenMU.Persistence.EntityFramework.CharacterClass")
                        .WithMany("RawStatAttributes")
                        .HasForeignKey("CharacterClassId");
                });
        }
    }
}

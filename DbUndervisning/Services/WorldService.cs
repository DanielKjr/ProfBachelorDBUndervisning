﻿using DbUndervisning.Context;
using DbUndervisning.Model;
using DbUndervisning.Model.Abilities;
using DbUndervisning.Model.Account;
using DbUndervisning.Model.Enums;
using DbUndervisning.Model.NPCStuff;
using DbUndervisning.Model.Quests;
using DbUndervisning.Services.Interfaces;
using EF_InteractionFrameworkCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using System.Linq.Expressions;

namespace DbUndervisning.Services
{
    public class WorldService(IAsyncRepository<WorldContext> _asyncRepository) : IWorldService
	{
		

	
		public async Task<World> GetWorld()
		{
			return await _asyncRepository.GetItem<World>(q => q.Where(x => x.Id != null).Include(r => r.Regions).ThenInclude(e => e.Mobs).ThenInclude(e => e.Abilities).Include(r => r.Regions).ThenInclude(r => r.Humanoids).ThenInclude(a => a.Abilities)
			.Include(r => r.Regions).ThenInclude(h => h.Humanoids).ThenInclude(q => q.Quest).ThenInclude(e => e.ItemToCreate)
			.Include(r => r.Regions).ThenInclude(h => h.Humanoids).ThenInclude(q => q.Quest).ThenInclude(e => e.Reward));
		}

		public async Task<World> GetWorldById(Guid id)
		{
			return await _asyncRepository.GetItem<World>(q => q.Where(x => x.Id == id));
		}

		public async Task<World> GetWorldByName(string name)
		{
			return await _asyncRepository.GetItem<World>(q => q.Where(x => x.Name == name));
		}



		public async void DeleteAll()
		{
#pragma warning disable CS8073 // The result of the expression is always the same since a value of this type is never equal to 'null'
			await _asyncRepository.RemoveItems<Quest>(q=> q.Where(q => q.Id != null));
			await _asyncRepository.RemoveItems<Humanoid>(q=> q.Where(q => q.Id != null));
			await _asyncRepository.RemoveItems<Item>(q => q.Where(q => q.Id != null));
			await _asyncRepository.RemoveItems<HumanoidAbility>(q => q.Where(q => q.Id != null));
			await _asyncRepository.RemoveItems<Mob>(q => q.Where(q => q.Id != null));
			await _asyncRepository.RemoveItems<MobAbility>(q => q.Where(q => q.Id != null));
			await _asyncRepository.RemoveItems<Region>(q => q.Where(q => q.Id != null));
			await _asyncRepository.RemoveItems<World>(q => q.Where(q => q.Id != null));
			await _asyncRepository.RemoveItems<Character>(q => q.Where(q => q.Id != null));
			await _asyncRepository.RemoveItems<Player>(q => q.Where(q => q.Id != null));
#pragma warning restore CS8073 // The result of the expression is always the same since a value of this type is never equal to 'null'

		}

	

	

		public async Task<string> GetQuery()
		{
			return await _asyncRepository.GetQueryString<Region>(q => q.Where(x => x.Id == Guid.Parse("035A3DCE-226A-45DC-9110-08DD0A142C24")).Include(i => i.Mobs).ThenInclude(a => a.Abilities));
		}

		public async Task<string> GetQuery<TEntity>(Func<IQueryable<TEntity>, IQueryable<TEntity>> queryOperation) where TEntity : class
		{
			return await _asyncRepository.GetQueryString(queryOperation);
		}

		public async Task<List<string>> GetQueries<TEntity>(List<Func<IQueryable<TEntity>, IQueryable<TEntity>>> queryOperations) where TEntity : class
		{
			var queryStrings = new List<string>();
			queryOperations.ForEach(async i => queryStrings.Add(await _asyncRepository.GetQueryString(i)));
			return queryStrings;
		}

		public async Task<string> GetQuery<TEntity>(
	Func<Func<IQueryable<TEntity>, IQueryable<TEntity>>> queryGenerator
) where TEntity : class
		{
			// Dynamically execute the query generator to get the query operation
			var queryOperation = queryGenerator();

			// Pass the generated query operation to the repository and return the query string
			return await _asyncRepository.GetQueryString(queryOperation);
		}

		public async void CreateStuff()
		{
			var player = new Player() { Name ="Rolf", HashedPw = "Rolferten" };
			var character = new Character() { Level = 1, Name = "Ged", Class = ClassType.Thief, Position = "300,200", Currency = 5};
			character.Abilities.Add(new CharacterAbility() { ClassConstraint = ClassType.Thief, Damage = -10, Description = "You lie down and cry in the corner", Name = "Cry" });
			player.Characters.Add(character);

			
			var world = new World() { Name = "Kandarin" };
			var region = new Region() { Asset = "idk", Description = "something", Name = "Generic location", Size = "500,200" };

			var quest = new Quest()
			{
				Dialogue = "you dun started something",
				Objective = "Do stuff",
				Title = "First quest",
				ItemToCreate = new Item() { Description = "A rubber duck", Name = "Ducky", Rarity = RarityLevel.Epic }
			};
			player.Characters.First().Items.Add(new Item() { Description = "A rubber duck but unique", Name = "Ducky", Rarity = RarityLevel.Epic });
			
			quest.ItemToCreate.Stats.Add(new Stat() { Boost = 50, StatType = StatType.Strength, Name = "GenericStatName" });
			quest.Reward = new Reward() { Currency = 200, Experience = 10 };
			var humanoid = new Humanoid()
			{
				Name = "Human",
				Attackable = false,
				Abilities = null,
				Behavior = BehaviorType.QuestNPC,
				Class = "Warrior",
				Health = 500,
				Level = 99,
				Position = "5,10",
				Texture = "something",
				Quest = quest
			};
			region.Humanoids.Add(humanoid);
			var mob = new Mob() { Attackable = true, Behavior = BehaviorType.Deer, Class = "Deer", Health = 100, Level = 1, Name = "Deer", Position = "5,5", Texture = "something" };
			mob.Abilities.Add(new MobAbility() { ClassConstraint = ClassType.Mob, Damage = 10, Description = "Deer kick", Name = "Kick" });
			region.Mobs.Add(mob);

			world.Regions.Add(region);

			await _asyncRepository.AddItem(player);
			await _asyncRepository.AddItem(world);
		}


	}
}

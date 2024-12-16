using EF_InteractionFrameworkCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using MultiPlayerDb.Context;
using MultiPlayerDb.Model;
using MultiPlayerDb.Model.Abilities;
using MultiPlayerDb.Model.Account;
using MultiPlayerDb.Model.Enums;
using MultiPlayerDb.Model.NPCStuff;
using MultiPlayerDb.Model.Quests;
using MultiPlayerDb.Services.Interfaces;

namespace MultiPlayerDb.Services
{

	
	public class WorldService(IAsyncRepository<WorldContext> _asyncRepository) : IWorldService
	{
		

	
		public async Task<World> GetWorld()
		{
			return await _asyncRepository.GetItem<World>(q => q.Where(x => x.Name == "Kandarin").IncludeAll());
			
		}

		public async Task<World> GetWorldById(Guid id)
		{
			return await _asyncRepository.GetItem<World>(q => q.Where(x => x.Id == id).Include(r => r.Regions));
		}

		public async Task<World> GetWorldByName(string name)
		{
			return await _asyncRepository.GetItem<World>(q => q.Where(x => x.Name == name));
		}



		public async void DeleteAll()
		{
#pragma warning disable CS8073 // The result of the expression is always the same since a value of this type is never equal to 'null'
		
			await _asyncRepository.RemoveItems<Ability>(q => q.Where(q => q.Id != null));
			await _asyncRepository.RemoveItems<NPC>(q => q.Where(q => q.Id != null));
			await _asyncRepository.RemoveItems<Region>(q => q.Where(q => q.Id != null));
			await _asyncRepository.RemoveItems<Quest>(q=> q.Where(q => q.Id != null));
			await _asyncRepository.RemoveItems<Item>(q => q.Where(q => q.Id != null));
			await _asyncRepository.RemoveItems<World>(q => q.Where(q => q.Id != null));
			await _asyncRepository.RemoveItems<Character>(q => q.Where(q => q.Id != null));
			await _asyncRepository.RemoveItems<Player>(q => q.Where(q => q.Id != null));
#pragma warning restore CS8073 // The result of the expression is always the same since a value of this type is never equal to 'null'

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


		/// <summary>
		/// Clusterfuck af kode der genererer en masse entiteter og gemmer dem for at teste
		/// </summary>
		public async void CreateStuff()
		{
			var random = new Random();
			var player = new Player() { Name ="Rolf", HashedPw = "Rolferten" };
			var character = new Character() { Level = 1, Name = "Ged", Class = ClassType.Thief, Position = "300,200", Currency = 5};
			character.Abilities.Add(new Ability() { ClassConstraint = ClassType.Thief, Damage = -10, Description = "You lie down and cry in the corner", Name = "Cry" });
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
			var humanoid = new NPC()
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
			region.NPCS.Add(humanoid);
			var mob = new NPC() { Attackable = true, Behavior = BehaviorType.Deer, Class = "Deer", Health = 100, Level = 1, Name = "Deer", Position = "5,5", Texture = "something" };
			mob.Abilities.Add(new Ability() { ClassConstraint = ClassType.Mob, Damage = 10, Description = "Deer kick", Name = "Kick" });
			region.NPCS.Add(mob);

			
			for (int i = 0; i < 30; i++) 
			{
				var npcName = $"NPC_{i}";
				var behavior = (BehaviorType)random.Next(Enum.GetValues(typeof(BehaviorType)).Length);
				var npcClass = behavior == BehaviorType.QuestNPC ? "Warrior" : "Mob";
				var npcLevel = random.Next(1, 101);
				var npcHealth = random.Next(50, 501);

		
				quest = null;
				if (behavior == BehaviorType.QuestNPC)
				{
					quest = new Quest()
					{
						Dialogue = $"Quest dialogue for {npcName}",
						Objective = $"Complete objective {i}",
						Title = $"Quest {i}",
						ItemToCreate = new Item()
						{
							Description = $"A random item {i}",
							Name = $"Item_{i}",
							Rarity = (RarityLevel)random.Next(1, 4)
						},
						Reward = new Reward()
						{
							Currency = random.Next(50, 301),
							Experience = random.Next(10, 51)
						}
					};

					quest.ItemToCreate.Stats.Add(new Stat()
					{
						Boost = random.Next(1, 101),
						StatType = (StatType)random.Next(Enum.GetValues(typeof(StatType)).Length),
						Name = $"Stat_{i}"
					});
				}

			
				var abilities = new List<Ability>();
				int numAbilities = random.Next(1, 4);
				for (int j = 0; j < numAbilities; j++)
				{
					abilities.Add(new Ability()
					{
						ClassConstraint = npcClass == "Mob" ? ClassType.Mob : (ClassType)random.Next(0, 4),
						Damage = random.Next(5, 51),
						Description = $"Ability description {j} for {npcName}",
						Name = $"Ability_{j}"
					});
				}

				// Create the NPC
				var npc = new NPC()
				{
					Name = npcName,
					Attackable = behavior != BehaviorType.QuestNPC,
					Abilities = abilities,
					Behavior = behavior,
					Class = npcClass,
					Health = npcHealth,
					Level = npcLevel,
					Position = $"{random.Next(1, 101)},{random.Next(1, 101)}",
					Texture = $"Texture_{i}",
					Quest = quest
				};

				region.NPCS.Add(npc);
			}
			world.Regions.Add(region);
			var worlds = new List<World>();
			for (int i = 0; i < 50; i++)
			{
				worlds.Add(new World() { Name = $"Something +{i}" });
			}
			await _asyncRepository.AddItems(worlds);
			await _asyncRepository.AddItem(player);
			await _asyncRepository.AddItem(world);
		}

		public async Task<Player> GetPlayer()
		{
			return await Task.FromResult(await _asyncRepository.GetItem<Player>(q => q.Where(i => i.Id != null)
			.Include(c => c.Characters).ThenInclude(c => c.Abilities)
			.Include(c => c.Characters).ThenInclude(i => i.CompletedQuests)
			.Include(c => c.Characters).ThenInclude(i => i.Items).ThenInclude(s => s.Stats)));
		}
	}
}

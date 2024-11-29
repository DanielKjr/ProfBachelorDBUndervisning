using MultiPlayerDb.Model;
using MultiPlayerDb.Model.Quests;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Text.Json;
using MultiPlayerDb.Model.Account;

int apiPort = 44397;
string baseUrl = $"https://localhost:{apiPort}";

HttpClient client = new HttpClient();


async Task<Guid> GetWorldId(string worldName)
{
	var response = await client.GetAsync($"{baseUrl}/Guid/worldName/{worldName}");
	var content = await response.Content.ReadAsStringAsync();
	return Guid.Parse(content.Replace("\"", ""));
}

async Task<Guid> GetRegionId(Guid worldId)
{
	var response = await client.GetAsync($"{baseUrl}/Guid/regionId/{worldId}");
	var content = await response.Content.ReadAsStringAsync();
	content = content.Replace("[", "").Replace("]", "").Replace("\"", "");
	return Guid.Parse(content);
}

async Task<Guid> GetMobId(Guid regionId)
{
	var response = await client.GetAsync($"{baseUrl}/Guid/mobId/{regionId}");
	var content = await response.Content.ReadAsStringAsync();
	content = content.Replace("[", "").Replace("]", "").Replace("\"", "");
	return Guid.Parse(content);
}

async Task<Guid> GetMobAbilitiesId(Guid mobId)
{
	var response = await client.GetAsync($"{baseUrl}/Guid/abilitiesById/{mobId}");
	var content = await response.Content.ReadAsStringAsync();
	content = content.Replace("[", "").Replace("]", "").Replace("\"", "");
	return Guid.Parse(content);
}

async Task<List<Guid>> GetNPCsByRegion(Guid regionId)
{
	var response = await client.GetAsync($"{baseUrl}/Guid/npcs/{regionId}");
	var content = await response.Content.ReadAsStringAsync();
	content = content.Replace("[", "").Replace("]", "").Replace("\"", "");
	return content.Split(',').Select(Guid.Parse).ToList();
	
}

//async Task<Guid> GetHumanoidAbilitiesId(Guid humanoidId)
//{
//	var response = await client.GetAsync($"{baseUrl}/Guid/humanoidAbilities/{humanoidId}");
//	var content = await response.Content.ReadAsStringAsync();
//	content = content.Replace("[", "").Replace("]", "").Replace("\"", "");
//	return Guid.Parse(content);
//}

async Task<Guid> GetHumanoidQuestId(Guid humanoidId)
{
	var response = await client.GetAsync($"{baseUrl}/Guid/questByHumanoidId/{humanoidId}");
	var content = await response.Content.ReadAsStringAsync();
	content = content.Replace("[", "").Replace("]", "").Replace("\"", "");
	return Guid.Parse(content);
}

async Task<Guid> GetQuestRewardId(Guid questId)
{
	var response = await client.GetAsync($"{baseUrl}/Guid/questItems/{questId}");
	var content = await response.Content.ReadAsStringAsync();
	content = content.Replace("[", "").Replace("]", "").Replace("\"", "");
	return Guid.Parse(content);
}
async Task<World> GetWorldById(Guid worldId)
{
	var response = await client.GetAsync($"{baseUrl}/World/worldId/{worldId}");
	var content = await response.Content.ReadAsStringAsync();
	World world = JsonConvert.DeserializeObject<World>(content)!;
	return world;
}
async Task<Region> GetRegiondByWorldId(Guid worldId)
{
	var response = await client.GetAsync($"{baseUrl}/Region/world/{worldId}");
	var content = await response.Content.ReadAsStringAsync();
	Region region = JsonConvert.DeserializeObject<Region>(content)!;
	return region;
}

//async Task<Mob> GetMobBydId(Guid id)
//{
//	var response = await client.GetAsync($"{baseUrl}/Mob/byId/{id}");
//	var content = await response.Content.ReadAsStringAsync();
//	Mob mob = JsonConvert.DeserializeObject<Mob>(content)!;
//	return mob;
//}

//async Task<MobAbility> GetMobAbilityBydId(Guid abilityId)
//{
//	var response = await client.GetAsync($"{baseUrl}/Mob/mobabilities/{abilityId}");
//	var content = await response.Content.ReadAsStringAsync();
//	List<MobAbility> mobabilities = JsonConvert.DeserializeObject<List<MobAbility>>(content)!;
//	return mobabilities.First();
//}

//async Task<Humanoid> GetHumanoidBydId(Guid humanoidId)
//{
//	var response = await client.GetAsync($"{baseUrl}/Humanoid/humanoidById/{humanoidId}");
//	var content = await response.Content.ReadAsStringAsync();
//	Humanoid humanoid = JsonConvert.DeserializeObject<Humanoid>(content)!;
//	return humanoid;
//}

//async Task<HumanoidAbility> GetHumanoidAbilityBydId(Guid humanoidId)
//{
//	var response = await client.GetAsync($"{baseUrl}/Humanoid/abilitiesById/{humanoidId}");
//	var content = await response.Content.ReadAsStringAsync();
//	HumanoidAbility humanoidAbility = JsonConvert.DeserializeObject<HumanoidAbility>(content)!;
//	return humanoidAbility;
//}

async Task<Quest> GetQuestBydHumanoidId(Guid humanoidId)
{
	var response = await client.GetAsync($"{baseUrl}/Humanoid/questById/{humanoidId}");
	var content = await response.Content.ReadAsStringAsync();
	List<Quest> quests = JsonConvert.DeserializeObject<List<Quest>>(content)!;
	return quests.First();
}



async Task<World> GetWorld()
{
	var response = await client.GetAsync($"{baseUrl}/World/get");
	var content = await response.Content.ReadAsStringAsync();
	World world = JsonConvert.DeserializeObject<World>(content)!;
	return world;
}

async Task<Player> GetPlayer()
{
	var response = await client.GetAsync($"{baseUrl}/World/get/player");
	var content = await response.Content.ReadAsStringAsync();
	Player player = JsonConvert.DeserializeObject<Player>(content)!;
	return player;
}

Console.WriteLine("Enter name of the World to search for");
string worldName = Console.ReadLine();
var worldId = await GetWorldId(worldName == "" ? "Kandarin" : worldName);
Console.WriteLine("World Id=" +worldId);
var regionId = await GetRegionId(worldId);
Console.WriteLine("Region Id=" +regionId);
var humanoidId = await GetNPCsByRegion(regionId);
humanoidId.ForEach(i => Console.WriteLine("NPC Id=" + i));

//var humanoidAbilitiesId = await GetHumanoidAbilitiesId(humanoidId);
//Console.WriteLine("Humanoid Ability Id=" + humanoidAbilitiesId + "(npcen har ikke nogen men kaldet virker)");

Guid questId = Guid.Empty;
try
{

	foreach (var id in humanoidId)
	{
		questId = await GetHumanoidQuestId(id);
	}
	
}
catch (Exception)
{
	
	
}
Console.WriteLine("Quest Id=" + questId);
var questRewardId = await GetQuestRewardId(questId);
Console.WriteLine("Quest Reward Id=" + questRewardId);
//var mobId = await GetMobId(regionId);
//Console.WriteLine("Mob Id="+mobId);


//var mobAbilitiesId = await GetMobAbilitiesId(mobId);
//Console.WriteLine("MobAbility Id="+mobAbilitiesId);
Console.WriteLine("Hit enter to get objects from these ids)");
Console.ReadLine();

var world = await GetWorldById(worldId);
Console.WriteLine("World: " + JsonConvert.SerializeObject(world) +"\n");
var region = await GetRegiondByWorldId(worldId);
Console.WriteLine("Region: " + JsonConvert.SerializeObject(region) + "\n");
//var humanoid = await GetHumanoidBydId(humanoidId);
//Console.WriteLine("Humanoid: " + JsonConvert.SerializeObject(humanoid) + "\n");
//var humanoidAbility = await GetHumanoidAbilityBydId(humanoidAbilitiesId);
//Console.WriteLine("Humanoid Ability: " + JsonConvert.SerializeObject(humanoidAbility) + "\n");
//var quest = await GetQuestBydHumanoidId(humanoidId);
//Console.WriteLine("Quest: " + JsonConvert.SerializeObject(quest) + "\n");
//var mob = await GetMobBydId(mobId);
//Console.WriteLine("Mob: " + JsonConvert.SerializeObject(mob) + "\n");
//var mobAbilities = await GetMobAbilityBydId(mobAbilitiesId);
//Console.WriteLine("Mob Abilities: " + JsonConvert.SerializeObject(mobAbilities) + "\n");

Console.WriteLine("Hit enter to execute get all from world in single query");
Console.ReadLine();

var newWorld = await GetWorld();
var player = await GetPlayer();


Console.WriteLine("World: " + JsonConvert.SerializeObject(newWorld) + "\n");
Console.WriteLine("Player: " + JsonConvert.SerializeObject(player) + "\n");

Console.ReadLine();
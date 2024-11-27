
using DbUndervisning.Model;
using DbUndervisning.Model.Abilities;
using DbUndervisning.Model.NPCStuff;
using Newtonsoft.Json;

int apiPort = 44339;
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
	var response = await client.GetAsync($"{baseUrl}/Guid/mobAbilitiesById/{mobId}");
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

async Task<Mob> GetMobBydId(Guid id)
{
	var response = await client.GetAsync($"{baseUrl}/Mob/byId/{id}");
	var content = await response.Content.ReadAsStringAsync();
	Mob mob = JsonConvert.DeserializeObject<Mob>(content)!;
	return mob;
}

async Task<MobAbility> GetMobAbilityBydId(Guid abilityId)
{
	var response = await client.GetAsync($"{baseUrl}/Mob/mobabilities/{abilityId}");
	var content = await response.Content.ReadAsStringAsync();
	List<MobAbility> mobabilities = JsonConvert.DeserializeObject<List<MobAbility>>(content)!;
	return mobabilities.First();
}

async Task<World> GetWorld()
{
	var response = await client.GetAsync($"{baseUrl}/World/get");
	var content = await response.Content.ReadAsStringAsync();
	World world = JsonConvert.DeserializeObject<World>(content)!;
	return world;
}

Console.WriteLine("Enter name of the World to search for");
string worldName = Console.ReadLine() == "" ? "Kandarin" : Console.ReadLine();
var worldId = await GetWorldId(worldName);
Console.WriteLine("World Id=" +worldId);
var regionId = await GetRegionId(worldId);
Console.WriteLine("Region Id=" +regionId);
var mobId = await GetMobId(regionId);
Console.WriteLine("Mob Id="+mobId);
var mobAbilitiesId = await GetMobAbilitiesId(mobId);
Console.WriteLine("MobAbility Id="+mobAbilitiesId);
Console.WriteLine("Hit enter to get objects from these ids)");
Console.ReadLine();

var world = await GetWorldById(worldId);
Console.WriteLine("World: " + JsonConvert.SerializeObject(world) +"\n");
var region = await GetRegiondByWorldId(worldId);
Console.WriteLine("Region: " + JsonConvert.SerializeObject(region) + "\n");
var mob = await GetMobBydId(mobId);
Console.WriteLine("Mob: " + JsonConvert.SerializeObject(mob) + "\n");
var mobAbilities = await GetMobAbilityBydId(mobAbilitiesId);
Console.WriteLine("Mob Abilities: " + JsonConvert.SerializeObject(mobAbilities) + "\n");
Console.WriteLine("Hit enter to execute get all from world in single query");
Console.ReadLine();

var newWorld = await GetWorld();
Console.WriteLine("World: " + JsonConvert.SerializeObject(newWorld) + "\n");

Console.ReadLine();
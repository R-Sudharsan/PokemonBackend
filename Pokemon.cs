namespace PokemonBackend;
// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class Pokemon
{
    public int num { get; set; }
    public string name { get; set; }
    public List<Variation> variations { get; set; }
    public string link { get; set; }
}

public class Stats
{
    public int total { get; set; }
    public int hp { get; set; }
    public int attack { get; set; }
    public int defense { get; set; }
    public int speedAttack { get; set; }
    public int speedDefense { get; set; }
    public int speed { get; set; }
}

public class Variation
{
    public string name { get; set; }
    public string description { get; set; }
    public string image { get; set; }
    public List<string> types { get; set; }
    public string specie { get; set; }
    public double height { get; set; }
    public double weight { get; set; }
    public List<string> abilities { get; set; }
    public Stats stats { get; set; }
    public List<string> evolutions { get; set; }
}


using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Nodes;
using Three.ConsoleApp1.Helpers;
using Three.ConsoleApp1.Models;


var userOne = new UserModel { UserId = 1, UserName = "chan", Email = "user@123", Password = "123123123" };

string userStr = JsonConvert.SerializeObject(userOne);
//string userStr = JsonConvert.SerializeObject(userOne,Formatting.Indented);

Console.WriteLine(userOne);
Console.WriteLine(userStr);

object? userObj = JsonConvert.DeserializeObject(userStr);
Console.WriteLine(userObj);


UserModel? userModel = JsonConvert.DeserializeObject<UserModel>(userStr);
Console.WriteLine(userModel);


var jsonStr = userOne.ToJson();
Console.WriteLine(new { jsonStr });

UserModel? user = jsonStr.ToObject<UserModel>();
var user2 = jsonStr.ToObject();
Console.WriteLine(user);
Console.WriteLine(new { user2 });


Console.WriteLine("--------------------------");

string filepath = "Data/Birds2.json";

var data = File.ReadAllText(filepath, Encoding.UTF8);

//var birds = JsonConvert.DeserializeObject<BirdRepo>(data);
var birds = data.ToObject<List<Bird>>();



foreach (var bird in birds!)
{
    Console.WriteLine($"bird name =  {bird.BirdEnglishName}");
}
Console.WriteLine("--------------------------");


string quotesFilePath = @"Data/Quotes.json";

var quoteJsonStr = File.ReadAllText(quotesFilePath, Encoding.UTF8);

var quoteRepo = quoteJsonStr.ToObject<QuoteRepo>();

foreach (var quote in quoteRepo.quotes)
{
    Console.WriteLine($"{quote.quote} \n \" Author Name is {quote?.author} \" \n");
}

public class BirdRepo
{
    public List<BirdModel>? Tbl_Bird { get; set; }
}

public class BirdModel
{
    public int Id { get; set; }
    public string BirdMyanmarName { get; set; }
    public string BirdEnglishName { get; set; }
    public string Description { get; set; }
    public string ImagePath { get; set; }
}



public class Bird
{
    public int Id { get; set; }
    public string BirdMyanmarName { get; set; }
    public string BirdEnglishName { get; set; }
    public string Description { get; set; }
    public string ImagePath { get; set; }
}



public class QuoteRepo
{
    public Quote[] quotes { get; set; }
}

public class Quote
{
    public int id { get; set; }
    public string quote { get; set; }
    public string author { get; set; }
}


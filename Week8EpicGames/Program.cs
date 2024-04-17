string folderPath = @"C:\data\";
string heroFile = "Heroes.txt";
string villainFile = "Villains.txt";

string[] heroes = File.ReadAllLines(Path.Combine(folderPath, heroFile));
string[] villains = File.ReadAllLines(Path.Combine(folderPath, villainFile));
string[] weapons = { "Magic powers", "Demon Strom Slayer Sword", "Omnitrix", "Death blade" };

string hero  = GetRandomValueFromArray(heroes);
string heroWeapon = GetRandomValueFromArray(weapons);
int heroHP = GetCharacterHP(hero);
int heroStikresStrength = heroHP;
Console.WriteLine($"Today {hero} ({heroHP} HP) with {heroWeapon} saves the day!");


string villain = GetRandomValueFromArray(villains);
string villainsWeapon = GetRandomValueFromArray(weapons);
int villainHP = GetCharacterHP(villain);
int villainsStrength = villainHP;
Console.WriteLine($"Today {villain} ({villainHP} HP) with {villainsWeapon} tries to take over the world!!!");

while(heroHP > 0 && villainHP > 0)
{
    heroHP = heroHP - Hit(villain, villainsStrength);
    villainHP = villainHP - Hit(hero, heroStikresStrength);
}

Console.WriteLine($"Hero {hero} HP: {heroHP}");
Console.WriteLine($"Villain {villain} HP: {villainHP}");
if (heroHP > 0 && villainHP > 0)
{
    Console.WriteLine($"{hero} saves the day!");
} 
else if (villainHP > 0)
{
    Console.WriteLine($"Dark side wins!");
}
else
{
    Console.WriteLine("Draw.");
}
static string GetRandomValueFromArray(string[] someArray)
{
    Random rnd = new Random();
    int randomindex = rnd.Next(0, someArray.Length);
    string randomStringFromArray = someArray[randomindex];
    return randomStringFromArray;
}


static int GetCharacterHP(string CharacterName)
{
    if(CharacterName.Length < 10)
    {
        return 10;
    }
    else
    {
        return CharacterName.Length;
    }
}

static int Hit(string characterName, int characterHP)
{
    Random rnd = new Random();
    int strike = rnd.Next(0, characterHP);

    if (strike == 0)
    {
        Console.WriteLine($"{characterName} missed the target!");
    }
    else if (strike == characterHP - 1)
    {
        Console.WriteLine($"{characterHP} made a critical hit!");
    }
    else
    {
        Console.WriteLine($"{characterName} hit {strike}!");
    }

    return strike;

}
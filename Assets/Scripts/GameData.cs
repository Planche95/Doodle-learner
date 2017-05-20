using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class GameData{

    public enum LANGUAGE { ENGLISH, POLISH, DEUTSCH };

    public static LANGUAGE CURR_LAN = LANGUAGE.POLISH;

    public static string SET = "Fruits and vegetables";

    public static GameType GAME_TYPE = new NormalGame(5);

    public static string BASE_SPRITE = "broccoli";

    public static readonly Dictionary<string, Dictionary<string, string[]>> words = new Dictionary<string, Dictionary<string, string[]>>()
    {
        { "Animals", new Dictionary<string, string[]>()
            {
                { "ant",        new string[]{"mrówka",      "Ameise" } },
                { "bear",       new string[]{"niedźwiedź",  "Bär" } },
                { "bug",        new string[]{"robak",       "Wurm"} },
                { "bull",       new string[]{"byk",         "Stier"} },
                { "butterfly",  new string[]{"motyl",       "Schmetterling" } },
                { "camel",      new string[]{"wielbłąd",    "Kamel"} },
                { "cancer",     new string[]{"rak",         "Krebs"} },
                { "cat",        new string[]{"kot",         "Katze"} },
                { "chameleon",  new string[]{"kameleon",    "Chamäleon" } },
                { "cow",        new string[]{"krowa",       "Kuh"} },
                { "deer",       new string[]{"jeleń",       "Hirsch"} },
                { "dog",        new string[]{"pies",        "Hund"} },
                { "dolphin",    new string[]{"delfin",      "Delphin"} },
                { "duck",       new string[]{"kaczka",      "Ente"} },
                { "elephant",   new string[]{"słoń",        "Elefant"} },
                { "fish",       new string[]{"ryba",        "Fish"} },
                { "fox",        new string[]{"lis",         "Fuchs"} },
                { "giraffe",    new string[]{"żyrafa",      "Giraffe"} },
                { "gorilla",    new string[]{"goryl",       "Gorilla"} },
                { "hedgehog",   new string[]{"jeż",         "Igel"} },
                { "hen",        new string[]{"kura",        "Henne"} },
                { "horse",      new string[]{"koń",         "Pferd"} },
                { "kangaroo",   new string[]{"kangur",      "Känguru" } },
                { "mouse",      new string[]{"mysz",        "Maus"} },
                { "octopus",    new string[]{"ośmiornica",  "Krake"} },
                { "owl",        new string[]{"sowa",        "Eule"} },
                { "panda",      new string[]{"panda",       "Panda"} },
                { "pig",        new string[]{"świnia",      "Schwein" } },
                { "rabbit",     new string[]{"królik",      "Kaninchen" } },
                { "reindeer",   new string[]{"renifer",     "Rentier"} },
                { "rhino",      new string[]{"nosorożec",   "Nashorn" } },
                { "sheep",      new string[]{"owca",        "Schaf"} },
                { "snail",      new string[]{"ślimak",      "Schnecke" } },
                { "spider",     new string[]{"pająk",       "Spinne" } },
                { "squirrel",   new string[]{"wiewiórka",   "Eichhörnchen" } },
                { "stork",      new string[]{"bocian",      "Storch" } },
                { "swan",       new string[]{"łabędź",      "Schwan"} },
                { "turkey",     new string[]{"indyk",       "Truthahn" } },
                { "turtle",     new string[]{"żółw",        "Schildkröte" } },
                { "wasp",       new string[]{"osa",         "Wespe"} }
            }
        },
        { "Fruits and vegetables", new Dictionary<string, string[]>()
            {
                { "apple",      new string[]{"jabłko",      "Apfel" } },
                { "avocado",    new string[]{"awokado",     "Avocado" } },
                { "banana",     new string[]{"banan",       "Banane" } },
                { "bean",       new string[]{"fasola",      "Bohne" } },
                { "beetroot",   new string[]{"burak",       "Schmetterling" } },
                { "blueberries",new string[]{"jagody",      "Blaubeeren" } },
                { "broccoli",   new string[]{"brokuły",     "Brokkoli" } },
                { "cabbage",    new string[]{"kapusta",     "Kohl" } },
                { "carrot",     new string[]{"marchewka",   "Karotte" } },
                { "celery",     new string[]{"seler",       "Sellerie" } },
                { "cherries",   new string[]{"wiśnie",      "Kirschen" } },
                { "chili",      new string[]{"chili",       "Chili" } },
                { "chives",     new string[]{"szczypiorek", "Schnittlauch" } },
                { "citron",     new string[]{"cytryna",     "Zitrone" } },
                { "coconut",    new string[]{"kokos",       "Kokosnuss" } },
                { "corn",       new string[]{"kukurydza",   "Mais" } },
                { "cucumber",   new string[]{"ogórek",      "Gurke" } },
                { "eggplant",   new string[]{"bakłażan",    "Aubergine" } },
                { "garlic",     new string[]{"czosnek",     "Knoblauch" } },
                { "grapes",     new string[]{"winogrona",   "Trauben" } },
                { "kiwi",       new string[]{"kiwi",        "Kiwi" } },
                { "leek",       new string[]{"por",         "Lauch" } },
                { "lime",       new string[]{"limonka",     "Limette" } },
                { "mushroom",   new string[]{"grzyb",       "Pilz" } },
                { "onion",      new string[]{"cebula",      "Zwiebel" } },
                { "orange",     new string[]{"pomarańcza",  "Orange" } },
                { "peach",      new string[]{"brzoskwinia", "Pfirsich" } },
                { "peanut",     new string[]{"arachid",     "Erdnuss" } },
                { "pear",       new string[]{"gruszka",     "Birne" } },
                { "peas",       new string[]{"groszek",     "Erbsen" } },
                { "pepper",     new string[]{"papryka",     "Paprika" } },
                { "pineapple",  new string[]{"ananas",      "ananas"} },
                { "pomegranate",new string[]{"granat",      "Granatapfel" } },
                { "potatoes",   new string[]{"ziemniaki",   "Kartoffeln" } },
                { "pumpkin",    new string[]{"dynia",       "Kürbis" } },
                { "radish",     new string[]{"rzodkiewka",  "Rettich" } },
                { "raspberry",  new string[]{"malina",      "Himbeere" } },
                { "strawberry", new string[]{"truskawka",   "Erdbeere" } },
                { "tomato",     new string[]{"pomidor",     "Tomate" } },
                { "watermelon", new string[]{"arbuz",       "Wassermelone" } }
            }
        }
    };

    public static string getWord(string eng)
    {
        return CURR_LAN.Equals(LANGUAGE.ENGLISH) ? eng : words[SET][eng][(int)CURR_LAN - 1];
    }

    public static List<string> getListof(string set)
    {
        return new List<string>(words.Keys);
    }
}

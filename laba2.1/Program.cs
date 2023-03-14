using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

void first()
{

    string[] lines = File.ReadAllLines(Directory.GetCurrentDirectory() + "//text.txt");
    List<string> list = lines.ToList();
    
    for(int i = 0; i < list.Count; i++)
    {
        bool upper = list[i].Equals(list[i].ToUpper());
        string word = list[i];
        bool firstIsUpper = Char.IsUpper(word[0]);
        if (upper == true || firstIsUpper == true)
        {
            list[i] = list[i].ToLower();
        }
    }
    var uniqueWords = list.GroupBy(w => w).Where(g => g.Count() == 1).Select(g => g.Key); // группировка_по_идентичности->выбор_неидентичных->запись_в_новую_коллекцию
    foreach (string word in uniqueWords)
    {
        Console.WriteLine(word);
    }
}
void second()
{
    Dictionary<string, int> din1 = new Dictionary<string, int>()
    {
        ["item1"] = 400
    };

    Dictionary<string, int> din2 = new Dictionary<string, int>()
    {
        ["item2"] = 300
    };
    Dictionary<string, int> din3 = new Dictionary<string, int>()
    {
        ["item1"] = 750
    };

    Dictionary<string, int> dout = new Dictionary<string, int>();

    foreach (KeyValuePair<string, int> i in din1)
    {
        if (dout.ContainsKey("item1"))
        {
            dout["item1"] += din1[i.Key];
        }
        else
        {
            dout.Add(i.Key, i.Value);
        }
    }

    foreach (KeyValuePair<string, int> i in din2)
    {
        if (dout.ContainsKey("item1"))
        {
            dout["item1"] += din2[i.Key];
        }
        else
        {
            dout.Add(i.Key, i.Value);
        }
    }

    foreach (KeyValuePair<string, int> i in din3)
    {
        if (dout.ContainsKey("item1"))
        {
            dout["item1"] += din3[i.Key];
        }
        else
        {
            dout.Add(i.Key, i.Value);
        }
    }

    foreach (var i in dout)
    {
        Console.WriteLine(i.Key + " " + i.Value);
    }

    var itemsjson = new 
    {
        Items = dout.Select(x => new { Key = x.Key, Value = x.Value })
    };

    string json = JsonConvert.SerializeObject(itemsjson, Formatting.Indented);
    string pathjson = Directory.GetCurrentDirectory() + "//file.json";

    File.AppendAllText(pathjson, json);

    Console.WriteLine("JSON file is done !");

}
void third()
{
    //-First, FirstOrDefault, Last, LastOrDefault, Single, SingleOrDefault(поелементні операції)
    //- Count, Sum, Average, Max, Min, Aggregate(агрегування); • Range(генерування послідовностей).

    //-Select, SelectMany, Where


    // создается dictionary (ключ: товар, значение: цена) -> сортировка больше ста/меньше ста грн -> вывод товаров

    Dictionary<string, int> store = new Dictionary<string, int>()
    {
        ["Cream"] = 69,
        ["Kiwi (per kg)"] = 95,
        ["Cheese"] = 300,
        ["Jamon"] = 500,
        ["Yogurt"] = 25,
        ["Pasta"] = 88,
        ["Bread"] = 23
    };

    Console.WriteLine("Choose your budget...\n1. Less then 100 hrn\n2. More than 100 hrn\n3. I don`t have money");
    string variants = "0";
    variants = Console.ReadLine();
    switch (variants)
    {
        case "1":
            foreach (KeyValuePair<string, int> i in store)
            {
                if (Convert.ToInt32(i.Value) <= 100)
                {
                    Console.WriteLine(i.Key + " - " + i.Value + " hrn.");
                }
            }
            break;

        case "2":
            foreach (KeyValuePair<string, int> i in store)
            {
                if (Convert.ToInt32(i.Value) >= 100)
                {
                    Console.WriteLine(i.Key + "-" + i.Value + "hrn.");
                }
            }
            break;

        case "3":
            break;
    } 
}




while (true)
{
    Console.WriteLine("Choose: 1, 2 or 3? If you want to exit press 4");
    string vars = "0";
    vars = Console.ReadLine();
    switch (vars)
    {
        case "1":
            first();
            break;
        case "2":
            second();
            break;
        case "3":
            third();
            break;
        case "4":
                return;
        default:
            Console.WriteLine("Unnknown command");
            break;
            
    }
    Console.ReadKey();
    Console.Clear();
}
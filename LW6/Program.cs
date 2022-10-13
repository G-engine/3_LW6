using LW6;

using HttpClient client = new HttpClient();
List<Weather> list = new List<Weather>();
Random rnd = new Random();
int i = 0;

while (i < 50)
{
    double lat = rnd.Next(-90, 90) + rnd.NextDouble();
    double lon = rnd.Next(-180, 180) + rnd.NextDouble();
    var content = await client.GetStringAsync($"http://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&APPID=f9db82f0483aa6ce398baf3e85d4d59f");
    Weather w = new Weather(content);
    if (w.Country != null && w.Name != null)
    {
        list.Add(w);
        ++i;
        list[^1].Print();
    }
}

Weather min = list.Min();
/*double min = list.Min(w => w.Temp);
Weather resultMin = list.FirstOrDefault(w => w.Temp == min);*/
Weather max = list.Max();
/*double max = list.Min(w => w.Temp);
Weather resultMax = list.FirstOrDefault(w => w.Temp == min);*/

double average = list.Average(w => w.Temp);

int count = list.Count();

Console.WriteLine();
Console.WriteLine($"MinTemp: {min.Temp} in {min.Country}; MaxTemp: {max.Temp} in {max.Country}; Average: {average}; Count: {count}");


Weather w1 = list.FirstOrDefault(w => w.Description == "clear sky");
Weather w2 = list.FirstOrDefault(w => w.Description == "rain");
Weather w3 = list.FirstOrDefault(w => w.Description == "few clouds");

Console.WriteLine($"Clear sky in {w1.Country}, {w1.Name}");
Console.WriteLine($"Rain in {w2.Country}, {w2.Name}");
Console.WriteLine($"Few clouds in {w3.Country}, {w3.Name}");
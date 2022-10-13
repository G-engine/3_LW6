using System.Text;
namespace LW6;

public struct Weather : IComparable<Weather>
{
    public string? Country { get; private set; }
    public string? Name { get; private set; }
    public string Description { get; private set; }
    public int Temp { get; private set; }

    public Weather(string data)
    {
        StringBuilder buf = new StringBuilder();

        #region Country
        int i = data.IndexOf("country");
            if (i != -1)
            {
                i += 10; //начало названия
                while (data[i] != '\"')
                {
                    buf.Append(data[i]);
                    ++i;
                }
                Country = buf.ToString();
            }
            else
                Country = null;
        #endregion

        #region Name
            buf.Clear();
            i = data.IndexOf("name");
            if (i != -1)
            {
                i += 7; //начало названия
                while (data[i] != '\"')
                {
                    buf.Append(data[i]);
                    ++i;
                }
                Name = buf.ToString();
            }
            else
                Name = null;
        #endregion

        #region Description
            buf.Clear();
            i = data.IndexOf("description"); 
            i += 14; //начало описания
            while (data[i] != '\"') 
            { 
                buf.Append(data[i]); 
                ++i;
            }
            Description = buf.ToString();
        #endregion

        #region Temp
            buf.Clear();
            i = data.IndexOf("temp"); 
            i += 6; //начало числа
            while (data[i] != '.' && data[i] != ',' && data[i] != '\"') 
            { 
                buf.Append(data[i]); 
                ++i;
            }
            Temp = Int32.Parse(buf.ToString()) - 271; // K -> 'C
        #endregion
    }

    public int CompareTo(Weather other)
    {
        return Temp.CompareTo(other.Temp);
    }
    public void Print()
    {
        Console.WriteLine($"{Country}, {Name}: Temp = {Temp} 'C, {Description}");
    }
}
using System;

public class Journal
{
    public string Name { get; }
    public int Description { get; set; }
    public DateTime Date { get; set; }
    public int Type { get; set; }
    public string Logg { get; set; }

    public Journal(string name)
    {
        this.Name = name;
    }
}
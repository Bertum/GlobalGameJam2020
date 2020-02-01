using System;

[Serializable]
public class Ranking
{
    public Ranking(string name, float time)
    {
        Name = name;
        Time = time;
    }
    public string Name { get; set; }
    public float Time { get; set; }
}

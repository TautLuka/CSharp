using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Grybai
{
    public int Day { get; set; }
    public int Mushroom1Count { get; set; }
    public int Mushroom2Count { get; set; }
    public int Mushroom3Count { get; set; }

    public Grybai(int day, int mushroom1count, int mushroom2count, int mushroom3count)
    {
        this.Day = day;
        this.Mushroom1Count = mushroom1count;
        this.Mushroom2Count = mushroom2count;
        this.Mushroom3Count = mushroom3count;
    }
}


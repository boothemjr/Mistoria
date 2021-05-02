using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordEntry
{
    public readonly string key;
    private readonly List<string> values;
    private BKT bkt;

    public WordEntry(string key, List<string> values)
    {
        this.key = key;
        this.values = values;
        bkt = new BKT();
    }
    

    public bool containsWord(string toCheck)
    {
        return values.Contains(toCheck);
    }

    public float getMastery()
    {
        return bkt.getPMastery();
    }
    
}

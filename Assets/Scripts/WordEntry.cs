using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordEntry
{
    public string key;
    public List<string> values;

    public WordEntry(string key, List<string> values)
    {
        this.key = key;
        this.values = values;
    }


}

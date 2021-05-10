using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordEntry
{
    public readonly string key;
    private readonly List<string> values;
    private BKT bkt;
    private int count;
    

    public WordEntry(string key, List<string> values)
    {
        this.key = key;
        this.values = values;
        bkt = new BKT();
    }
    
    // check values for word, return true if found
    public bool ContainsWord(string toCheck)
    {
        return values.Contains(toCheck);
    }

    // return probability of mastering the word 
    public float GetMastery()
    {
        return bkt.getPMastery();
    }

    // return number of times the word has been used
    public int GetCount()
    {
        return count;
    }
    
    // increment the number of instances by one
    public void CountWord()
    {
        count++;
    }

    // updates BKT with whether or not they got it correct
    public void AddCorrect(bool isCorrect)
    {
        bkt.CalculateNewBKT(isCorrect);
        Debug.Log("The new BKT of " + key + " is " + bkt.getPMastery());
    }
    
}

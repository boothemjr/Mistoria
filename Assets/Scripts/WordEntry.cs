using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordEntry
{
    public readonly string key; // the key value for each set of words
    private readonly List<string> values; // all the values for each key
    private BKT bkt; // a BKT object for holding probabalistic information
    private int count; // the number of times this word has been counted, ie. appeared.
    
    // make a new wordentry
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glossary
{
    // container for all the word entries
    private List<WordEntry> glossary = new List<WordEntry>();

    // todo - is this needed? I think so..
    // empty constructor
    public Glossary()
    {
        
    }

    // adds a wordEntry to the database
    public void Add(WordEntry entry)
    {
        glossary.Add(entry);
    }
    
    // searches the the word collection of each work entry to see if the variation of the word is found
    // returns whether or not it's found
    public bool findWord(string key)
    {
        int i = 0;
        bool found = false;
        while (!found && i < glossary.Count) // todo - always starts at i=0, different data structure could optimize
        {
            found = glossary[i].containsWord(key);
            i++;
        }
        return found;
    }

}

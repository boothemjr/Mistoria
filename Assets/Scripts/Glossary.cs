using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Glossary
{

    // container for all the word entries
    private List<WordEntry> glossary = new List<WordEntry>();

    // empty constructor
    public Glossary()
    {
        string text = Resources.Load<TextAsset>("glossary").ToString(); // load the text asset as a string


        while (text.Length > 0)
        {
            string key = text.Substring(0, text.IndexOf(',')); // store key which is the first string
            string nextLine = text.Substring(0, text.IndexOf('\n')); // grab the next line of text
            List<string> values = nextLine.Split(',').ToList(); // parse into separate strings
            text = text.Substring(text.IndexOf('\n')+1); //remove the parsed line from text
            var temp = new WordEntry(key, values);
            glossary.Add(temp);
        }
        Debug.Log(glossary.Count + " words were added to the database!"); //todo - log not needed

    }

    // todo - consider removing
    // adds a wordEntry to the database
    public void Add(WordEntry entry)
    {
        glossary.Add(entry);
    }
    
    // searches the the word collection of each work entry to see if the variation of the word is found
    // returns whether or not it's found
    public bool findWord(string key)
    {
        int i = -1; // have to start -1 for while loop
        bool found = false;
        while (!found && i < glossary.Count-1) // todo - always starts at i=0, different data structure could optimize
        {
            i++; //increase index
            found = glossary[i].containsWord(key);
        }

        if (found)
        {
            glossary[i].countWord(); // increase the count of word encounters
        }
        
        return found;
    }

}

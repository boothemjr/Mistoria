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
        Debug.Log(glossary.Count + " words were added to the database!");

    }
    
    // searches the word collection of each word entry to see if the variation of the word is found
    // returns the wordEntry object
    public WordEntry getWord(string key)
    {
        int i = -1; // have to start -1 for while loop
        bool found = false;
        while (!found && i < glossary.Count-1) // todo - always starts at i=0, different data structure could optimize
        {
            i++; //increase index
            found = glossary[i].ContainsWord(key);
        }

        return glossary[i];
    }
    
    // does same as above, but increments the count of each world
    public bool findAndCountWord(string key)
    {
        int i = -1; // have to start -1 for while loop
        bool found = false;
        while (!found && i < glossary.Count-1) // todo - always starts at i=0, different data structure could optimize
        {
            i++; //increase index
            found = glossary[i].ContainsWord(key);
        }

        if (found)
        {
            glossary[i].CountWord(); // increase the count of word encounters
        }
        
        return found;
    }

}

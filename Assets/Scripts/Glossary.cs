using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Glossary
{

    // container for all the word entries
    private List<WordEntry> glossary = new List<WordEntry>();

    // todo - is this needed? I think so..
    // empty constructor
    public Glossary()
    {
        string text = Resources.Load<TextAsset>("glossary").ToString(); // load the text asset as a string

        Debug.Log("working1");
        while (text.Length > 0)
        {
            Debug.Log("working2");

            string key = text.Substring(0, text.IndexOf(',')); // store key which is the first string
            string nextLine = text.Substring(0, text.IndexOf('\n')); // grab the next line of text
            List<string> values = nextLine.Split(',').ToList(); // parse into separate strings
            text = text.Substring(text.IndexOf('\n')); //remove the parsed line from text
            Debug.Log("line of text added!\n");
        }
        

        /*while (text != String.Empty) // repeat while text isn't empty
        {
        Debug.Log("text = " + text);
        resolve !verbs
        if (text.StartsWith("!"))
        {
            text = text.Substring(1); // remove "!"
            Debug.Log("! removed, text = " + text);
        }
        if (text.StartsWith("verb")) // todo - change to set flag via switch
        {
        text = text.Substring(text.IndexOf(' ')+1); // remove "verb", +1 to move past the space
        Debug.Log("verb removed, text = " + text);
        string key = text.Substring(0, text.IndexOf(',')); // store key
        Debug.Log("key = " + key);
        List<string> values = text.Split(',').ToList();

        }
        text = text.Substring(text.IndexOf(' '));
        
        //check if there's more
        }
        else
        {
            
        }
            
        }*/

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

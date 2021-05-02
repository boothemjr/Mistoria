using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        // for testing
        var wordList = new Glossary();
        wordList.Add(new WordEntry("comer", 
            new List<string>(){"como", "comes", "come", "comemos", "comen"}));
        wordList.Add(new WordEntry("hablar",
            new List<string>() {"hablo", "hablas", "habla", "hablamos", "hablan"}));
        
        Debug.Log("findWord = " + wordList.findWord("coma"));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

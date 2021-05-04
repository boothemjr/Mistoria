using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // enumerations of the different proficiency levels
    enum ProficiencyLevel { novLow, novMid, novHi, interLow, interMid, interHi, advLow, advMid, advHi, superior }
    
    
    // Start is called before the first frame update
    void Start()
    {
        var wordList = new Glossary(); //initialize the glossary
        
        // for testing
        /*wordList.Add(new WordEntry("comer", 
            new List<string>(){"como", "comes", "come", "comemos", "comen"}));
        wordList.Add(new WordEntry("hablar",
            new List<string>() {"hablo", "hablas", "habla", "hablamos", "hablan"}));
        
        Debug.Log("findWord = " + wordList.findWord("coma"));*/

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

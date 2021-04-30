using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float temp = BKT.CalculateBKT(true);
        Debug.Log("temp = " + temp);

        var wordList = new List<WordEntry>();
        
        wordList.Add(new WordEntry("comer", 
            new List<string>(){"como", "comes", "come", "comemos", "comen"}));
        wordList.Add(new WordEntry("hablar", 
            new List<string>(){"hablo", "hablas", "habla", "hablamos", "hablan"}));

        //todo - check below, here's my attempt to setup a searchable word database
        var dict = wordList.ToLookup(x => x.key, x => x.values);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

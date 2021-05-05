using System.Collections;
using System.Collections.Generic;
using Michsky.UI.ModernUIPack;
using UnityEngine;
using Mistoria;
public class GameManager : MonoBehaviour
{
    private ProficiencyLevel currLevel;
    public GameObject progressBar;
    //private Component progressBarComp;
    private float timeRemaining;
    private readonly float maxTime = 10f; 
    
    
    // enumerations of the different proficiency levels
    
    
    // Start is called before the first frame update
    void Start()
    {
        var wordList = new Glossary(); //initialize the glossary
        timeRemaining = maxTime;
        currLevel = ProficiencyLevel.novLow;
        
        //progressBarComp = progressBar.GetComponent<ProgressBarMB>();
    }

    // Update is called once per frame
    void Update()
    {
        //reset the timer
        if (Input.GetKeyDown(KeyCode.R))
        {
            timeRemaining = maxTime;
        }

        // stop the timer when 0
        if (timeRemaining > 0f)
        {
            timeRemaining -= Time.deltaTime;
        }

        // update time
        // wait until event (speech + text)

    }
}

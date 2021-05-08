using System.Collections;
using System.Collections.Generic;
using Michsky.UI.ModernUIPack;
using UnityEngine;
using Mistoria;
public class GameManager : MonoBehaviour
{
    private ProficiencyLevel currLevel;
    public ProgressBar timerBar;
    private readonly float maxTime = 10f; //todo - replace with a timer based on the length of the prompt

    // Start is called before the first frame update
    void Start()
    {
        // SET INITIAL VARIABLES
        currLevel = ProficiencyLevel.NovLow;
        
        // BUILD GLOSSARY
        var wordList = new Glossary();
        
        // SET TIMER
        timerBar.currentPercent = 100f;

    }

    // Update is called once per frame
    void Update()
    {
        CheckKeys();
    }

    // Check for any keyboard input
    private void CheckKeys()
    {
        //reset the timer
        if (Input.GetKeyDown(KeyCode.R))
        {
            timerBar.currentPercent = 100f;
        }
    }

}

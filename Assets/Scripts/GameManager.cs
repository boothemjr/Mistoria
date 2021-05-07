using System.Collections;
using System.Collections.Generic;
using Michsky.UI.ModernUIPack;
using UnityEngine;
using Mistoria;
public class GameManager : MonoBehaviour
{
    private ProficiencyLevel currLevel;
    public GameObject progressBar;
    private float timeRemaining;
    private readonly float maxTime = 10f; //todo - replace with a timer based on the length of the prompt

    // Start is called before the first frame update
    void Start()
    {
        // SET INITIAL VARIABLES
        timeRemaining = maxTime;
        currLevel = ProficiencyLevel.NovLow;
        
        // BUILD GLOSSARY
        var wordList = new Glossary();

    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
        CheckKeys();
    }

    // Check for any keyboard input
    private void CheckKeys()
    {
        //reset the timer
        if (Input.GetKeyDown(KeyCode.R))
        {
            timeRemaining = maxTime;
        }
    }

    // Update the timer
    private void UpdateTimer()
    {
        // stop the timer when 0
        if (timeRemaining > 0f)
        {
            timeRemaining -= Time.deltaTime;
        }
    }
}

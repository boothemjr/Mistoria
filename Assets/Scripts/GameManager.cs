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
        var wordList = new Glossary(); //initialize the glossary

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

        // todo - update time
        // todo - wait until event (speech + text)

    }
}

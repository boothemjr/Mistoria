using System.Collections;
using System.Collections.Generic;
using Michsky.UI.ModernUIPack;
using UnityEngine;
using Mistoria;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public ProficiencyLevel currLevel; // the current proficiency level\
    public NotionScriptableObject startNotion; // the dialogue notion to start with
    private NotionScriptableObject currNotion; // the current notion being discussed in the dialogue
    public ProgressBar timerBar; // the countdown timer progress bar
    public GameObject[] buttons; // the arr of button objects

    // Start is called before the first frame update
    void Start()
    {
        // SET INITIAL VARIABLES
        currLevel = ProficiencyLevel.NovLow;
        currNotion = startNotion;
        
        // BUILD GLOSSARY
        var wordList = new Glossary();
        
        // SET TIMER
        timerBar.currentPercent = 100f;
        
        // SET UP NOTION
        currNotion.UpdateProfLevel(currLevel);
        
        // ASSIGN BUTTONS   
        buttons = GameObject.FindGameObjectsWithTag("Button");
        for (int i = 0; i < buttons.Length; i++)
        {
            // assign each button with the new prompt text
            string temp = currNotion.currPrompt.responseOptions[i]; // grab response options
            buttons[i].GetComponent<ButtonManagerBasic>().buttonText = temp; // place on each button
            buttons[i].GetComponent<ButtonManagerBasic>().UpdateUI(); // update UI
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckKeys();
        
        // if selection
            // update notion + dialogues
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

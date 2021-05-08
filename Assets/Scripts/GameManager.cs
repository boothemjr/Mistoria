using System.Collections;
using System.Collections.Generic;
using Michsky.UI.ModernUIPack;
using UnityEngine;
using Mistoria;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public ProficiencyLevel currLevel; // the current proficiency level\
    public NotionScriptableObject startNotion; // the dialogue notion to start with
    private NotionScriptableObject currNotion; // the current notion being discussed in the dialogue
    public ProgressBar timerBar; // the countdown timer progress bar
    private GameObject[] buttons; // the arr of button objects
    public GameObject eventSystemObject; // the object holding the canvas/ui event system
    private EventSystem eventSystem; // the canvas/ui event system
    //public GameObject modalWindowManagerObject;
    //private ModalWindowManager modalWindowManager; 
    
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        // SET INITIAL VARIABLES
        currLevel = ProficiencyLevel.NovLow;
        currNotion = startNotion;
        timerBar.currentPercent = 100f;
        eventSystem = eventSystemObject.GetComponent<EventSystem>();
        //modalWindowManager = modalWindowManagerObject.GetComponent<ModalWindowManager>();
        
        // BUILD GLOSSARY
        var wordList = new Glossary();

        // SET UP NOTION
        currNotion.UpdateProfLevel(currLevel);
        
        // UPDATE NPC DIALOGUE UI
        //modalWindowManager.UpdateUI();
        //modalWindowManager.UpdateUI();


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
        //modalWindowManager.UpdateUI();
    }

    // Check and resolve if a dialogue option has been selected.
    public void SelectDialogueOption(int choice)
    {
        Debug.Log("Button #" + choice + " was selected.");
    }

    // todo - remove when no longer needed
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

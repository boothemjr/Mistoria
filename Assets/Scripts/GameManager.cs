using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Michsky.UI.ModernUIPack;
using UnityEngine;
using Mistoria;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // for the singleton
    public ProficiencyLevel currLevel; // the current proficiency level\
    public NotionScriptableObject startNotion; // the dialogue notion to start with
    private NotionScriptableObject currNotion; // the current notion being discussed in the dialogue
    public ProgressBar timerBar; // the countdown timer progress bar
    private GameObject[] buttons; // the arr of button objects
    public GameObject eventSystemObject; // the object holding the canvas/ui event system
    private EventSystem eventSystem; // the canvas/ui event system
    private GameObject npcDialogueObject; // the object holding the NPC's dialogue text
    private List<string> focusWords; // the list of words that will be impacted at the end of this notion
    public Glossary wordList; // the database of word entries

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
        string temp;
        currLevel = ProficiencyLevel.NovLow;
        currNotion = startNotion;
        timerBar.currentPercent = 100f;
        eventSystem = eventSystemObject.GetComponent<EventSystem>();
        focusWords = new List<string>();

        // BUILD GLOSSARY
        wordList = new Glossary();

        // SET UP NOTION
        currNotion.UpdateProfLevel(currLevel);

        // UPDATE NPC DIALOGUE UI
        npcDialogueObject = GameObject.FindWithTag("NPCDialogue");
        temp = currNotion.currPrompt.promptText; //grab prompt text
        npcDialogueObject.GetComponent<ModalWindowManager>().descriptionText = temp; // put prompt text in dialogue box
        npcDialogueObject.GetComponent<ModalWindowManager>().UpdateUI(); // update UI
        // count words in dialogue
        CountWords(wordList, temp);

        // ASSIGN BUTTONS   
        buttons = GameObject.FindGameObjectsWithTag("Button");

        for (int i = 0; i < buttons.Length; i++)
        {
            // assign each button with the new prompt text
            temp = currNotion.currPrompt.responseOptions[i]; // grab response options
            buttons[i].GetComponent<ButtonManagerBasic>().buttonText = temp; // place on each button
            buttons[i].GetComponent<ButtonManagerBasic>().UpdateUI(); // update UI

            // count words when added to button
            CountWords(wordList, temp);
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckKeys();
    }

    // Resolve if a dialogue option has been selected.
    public void SelectDialogueOption(int choice)
    {
        int i = 0;
        bool isCorrect = false;

        // loop while there are more correct responses options to check or you haven't already gotten it correct
        while (i < currNotion.currPrompt.correctResponses.Length && isCorrect == false)
        {
            if (currNotion.currPrompt.correctResponses[i] == choice)
            {
                isCorrect = true;
            }
            i++;
        }
        
        Debug.Log("isCorrect = " + isCorrect);
            
         //add a correct for each in the focus list

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

    private void CountWords(Glossary glossary, string wordsToCheck)
    {
        wordsToCheck = wordsToCheck.ToLower(); // set to lower case
        var arrWordsToCheck = wordsToCheck.Split(' '); // split up each word
        foreach (var word in arrWordsToCheck)
        {
            string temp // remove punctuation from each word
                = new string(word.ToCharArray().Where(c => !char.IsPunctuation(c)).ToArray());
            
            // add to focus list if not already added
            if (wordList.getWord(temp).getCount() == 0) // if not yet counted
            {
                focusWords.Add(wordList.getWord(temp).key); // add key to focus words
            }
            
            glossary.findAndCountWord(temp); // increment the number of instances of the word in glossary
            
        }
    }

}

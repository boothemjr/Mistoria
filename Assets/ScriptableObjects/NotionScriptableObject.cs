using System;
using System.Collections;
using System.Collections.Generic;
using Mistoria;
using UnityEngine;

[CreateAssetMenu (fileName = "New Notion", 
    menuName = "Dialogue/Notion", order = 0)]

public class NotionScriptableObject : ScriptableObject
{
    private ProficiencyLevel currLevel; // the current proficiency level
    public PromptScriptableObject[] prompt; // arr of prompts, depending on level
    public PromptScriptableObject currPrompt; // the current prompt given the level
    public NotionScriptableObject nextNotionScriptableObject; // the notion that will follow this one

    // update the proficiency level
    public void UpdateProfLevel(ProficiencyLevel newLevel)
    {
        currLevel = newLevel; // set the proficiency level
                
        //todo - add logic for prompt selection
        currPrompt = prompt[0]; // select the corresponding prompt
    }
    
}
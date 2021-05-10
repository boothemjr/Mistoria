using System;
using System.Collections;
using System.Collections.Generic;
using Mistoria;
using UnityEngine;

[CreateAssetMenu (fileName = "New Notion", 
    menuName = "Dialogue/Notion", order = 0)]

public class NotionScriptableObject : ScriptableObject
{
    private ProficiencyLevel currLevel;
    public PromptScriptableObject[] prompt;
    public PromptScriptableObject currPrompt;
    public NotionScriptableObject nextNotionScriptableObject;

    public void UpdateProfLevel(ProficiencyLevel newLevel)
    {
        currLevel = newLevel;
                
        //todo - add logic for prompt selection
        currPrompt = prompt[0];
    }
    
}
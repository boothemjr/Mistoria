using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Prompt", 
    menuName = "Dialogue/Prompt", order = 0)]

public class PromptScriptableObject : ScriptableObject
{
    public string promptText; // the text of this prompt
    public string[] responseOptions = new string[4]; // the 4 responses the player can choose from
    public string[] npcResponses = new string[4]; // the 4 responses the npc will respond with
    public int[] correctResponses; // which responses will be "correct"
    public string npcIgnoreResponse; // the npcs response if the time expires
    public int minLevel, maxLevel; // the min and max proficiency level for this prompt

}

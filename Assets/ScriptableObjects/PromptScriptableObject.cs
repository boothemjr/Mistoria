using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Prompt", 
    menuName = "Dialogue/Prompt", order = 0)]

public class PromptScriptableObject : ScriptableObject
{
    public string promptText;
    public string[] responseOptions = new string[4];
    public string[] npcResponses = new string[4];
    public string npcIgnoreResponse;
    public int minLevel, maxLevel;

}

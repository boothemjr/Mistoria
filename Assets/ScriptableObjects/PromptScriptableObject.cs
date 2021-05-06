using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Prompt", 
    menuName = "Dialogue/Prompt", order = 0)]

public class PromptScriptableObject : ScriptableObject
{
    public string prompt;
    public ResponsesScriptableObject responseOptions;
    public int minLevel;
    public int maxLevel;

}

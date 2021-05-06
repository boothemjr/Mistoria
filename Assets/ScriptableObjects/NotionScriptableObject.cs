using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Notion", 
    menuName = "Dialogue/Notion", order = 0)]

public class NotionScriptableObject : ScriptableObject
{
    public PromptScriptableObject[] prompt;
    public NotionScriptableObject nextNotionScriptableObject;
}

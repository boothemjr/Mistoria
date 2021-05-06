using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Responses", 
    menuName = "Dialogue/Responses", order = 0)]
public class ResponsesScriptableObject : ScriptableObject
{
    public string[] responseOptions = new string[4];
    
}

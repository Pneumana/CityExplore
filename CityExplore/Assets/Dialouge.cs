using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialouge
{
    [Header("Name of the NPC the player is talking to.")]
    public string name;
    [Header("Number of buttons on reaching the last sentence")]
    public int options;
    public string[] buttons = new string[3] { "button1", "button2", "button3" };
    public string[] buttonAction = new string[3] { "END", "", "" };
    [TextArea(3,10)]
    public string[] sentences;

}

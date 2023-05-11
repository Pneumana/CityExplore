using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class DialougeSystem : MonoBehaviour
{
    public GameObject rightButton;
    public GameObject leftButton;
    public GameObject middleButton;

    private Queue<string> sentences;

    public Image character;
    public GameObject greyout;
    public GameObject textbox;

    int options;
    string[] fishman = new string[] { "Hello", "I'm Fishman :D" };
    string[] buttonNames;
    string[] buttonActions;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        ExitDialouge();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ExitDialouge()
    {
        character.gameObject.SetActive(false);
        greyout.SetActive(false);
        textbox.SetActive(false);
        //enable player input
        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
    }
    public void EnterDialouge(Dialouge talk)
    {
        textbox.transform.Find("Name").gameObject.GetComponent<TextMeshProUGUI>().text = talk.name;
        Debug.Log(talk.name);
        sentences.Clear();
        foreach(string line in talk.sentences)
        {
            sentences.Enqueue(line);
        }
        character.gameObject.SetActive(true);
        character.sprite = Resources.Load<Sprite>("Textures/UI/NPCS/" + talk.name);
        greyout.SetActive(true);
        textbox.SetActive(true);
        DisplayNextSentence();
        options = talk.options;
        buttonNames = talk.buttons;
        buttonActions = talk.buttonAction;
        leftButton.transform.Find("Option1Text").gameObject.GetComponent<TextMeshProUGUI>().text = buttonNames[0];
        middleButton.transform.Find("Option2Text").gameObject.GetComponent<TextMeshProUGUI>().text = buttonNames[1];
        rightButton.transform.Find("Option3Text").gameObject.GetComponent<TextMeshProUGUI>().text = buttonNames[2];
        if(talk.sentences.Length == 1) 
        {
            if (options == 0)
            {
                leftButton.SetActive(false);
                rightButton.SetActive(false);
                middleButton.SetActive(false);
            }
            else if (options == 1)
            {
                leftButton.SetActive(false);
                rightButton.SetActive(false);
                middleButton.SetActive(true);
            }
            else if (options == 2)
            {
                leftButton.SetActive(true);
                rightButton.SetActive(true);
                middleButton.SetActive(false);
            }
            else if (options == 3)
            {
                leftButton.SetActive(true);
                rightButton.SetActive(true);
                middleButton.SetActive(true);
            }
        }
        //disable player input
        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
        //name is used for the npc
/*        DialougeSystem.*/
    }
    public void DisplayNextSentence()
    {
        if(sentences.Count == 0 && options == 0)
        {
            ExitDialouge();
            return;
        }
        else if(sentences.Count == 1)
        {
            if(options == 0)
            {
                leftButton.SetActive(false);
                rightButton.SetActive(false);
                middleButton.SetActive(false);
            }
            else if(options == 1)
            {
                leftButton.SetActive(false);
                rightButton.SetActive(false);
                middleButton.SetActive(true);
            }
            else if (options == 2)
            {
                leftButton.SetActive(true);
                rightButton.SetActive(true);
                middleButton.SetActive(false);
            }
            else if (options == 3)
            {
                leftButton.SetActive(true);
                rightButton.SetActive(true);
                middleButton.SetActive(true);
            }
        }
        if(sentences.Count != 0)
        {
            string sentence = sentences.Dequeue();
            textbox.transform.Find("Body").gameObject.GetComponent<TextMeshProUGUI>().text = sentence;
        }
        
    }
    public void PressedButton(int button)
    {
        var action = buttonActions[button];
        string[] splitaction = action.Split(':');
        if (splitaction[0] == "END")
            ExitDialouge();
        if (splitaction[0] == "START")
        {
            //create invisible trigger with name from splitaction[1]
            var trigger = GameObject.Instantiate(Resources.Load<GameObject>("Dialouge/" + splitaction[1]));
            trigger.transform.position = GameObject.Find("Player").transform.position;
        }
        if (splitaction[0] == "FACTION")
        {
            var targetFaction = int.Parse(splitaction[1]);
            var reputationMod = int.Parse(splitaction[2]);
            FactionRank.instance.RankUp(targetFaction, reputationMod);
        }

    }
    public void PressedButton2()
    {

    }
}

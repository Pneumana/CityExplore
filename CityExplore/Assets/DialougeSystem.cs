using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
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

    string[] fishman = new string[] { "Hello", "I'm Fishman :D" };
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
        //name is used for the npc
/*        DialougeSystem.*/
    }
    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            ExitDialouge();
            return;
        }
        string sentence = sentences.Dequeue();
        textbox.transform.Find("Body").gameObject.GetComponent<TextMeshProUGUI>().text = sentence;
    }
}

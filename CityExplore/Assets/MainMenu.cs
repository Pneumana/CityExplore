using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Play()
    {
        SceneManager.LoadScene("ThroneRoom", LoadSceneMode.Single);
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits", LoadSceneMode.Single);
    }
    public void BackToTitle()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}

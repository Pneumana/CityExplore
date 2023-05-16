using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string sceneName;
    public int CutScene = 0;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Debug.Log("going to new scene: " + sceneName);
            FactionRank.instance.cameFrom = SceneManager.GetActiveScene().name;
            FactionRank.instance.wait = 0;
            FactionRank.instance.playcutscene = CutScene;
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }
}

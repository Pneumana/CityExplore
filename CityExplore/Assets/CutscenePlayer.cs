using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class CutscenePlayer : MonoBehaviour
{
    public int playingCutscene = 0;

    public GameObject tsunamiWave;
    public GameObject[] sponges;
    public GameObject waterlevel;
    public int playCutsceneOnStart = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCutscene(playCutsceneOnStart);
    }

    // Update is called once per frame
    void Update()
    {
        if(playingCutscene == 1)
        {
            tsunamiWave.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 5);
        }
        if(playingCutscene == 2)
        {
            waterlevel.transform.position += Vector3.down * Time.deltaTime;
            foreach(GameObject sponge in sponges)
            {
                sponge.transform.localScale += Vector3.one * Time.deltaTime;
            }
        }

    }

    public void StartCutscene(int i)
    {
        //need 3 cutscenes.
        playingCutscene = i;
        //activate each object
        if(playingCutscene == 1)
        {
            tsunamiWave.SetActive(true);
            var camerascript = Camera.main.GetComponent<CameraFollowPlayer>();
            camerascript.player = tsunamiWave;
            camerascript.zOffset = -11f;
        }
        if(playingCutscene == 2)
        {
            sponges = GameObject.FindGameObjectsWithTag("Sponge");
            var camerascript = Camera.main.GetComponent<CameraFollowPlayer>();
            camerascript.player = waterlevel;
        }
    }
    public void EndCutscene()
    {
        var camerascript = Camera.main.GetComponent<CameraFollowPlayer>();
        camerascript.player = GameObject.Find("Player");
        camerascript.zOffset = -16f;
    }
}

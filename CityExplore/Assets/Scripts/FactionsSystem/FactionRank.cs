using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactionRank : MonoBehaviour
{
    public int landRank;
    public int seaRank;
    public int fishmanRank;
    public static FactionRank instance;
    public bool hasEnteredTown = false;
    public string cameFrom;
    public GameObject[] factionObjects;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(this.gameObject);
        DontDestroyOnLoad(gameObject);
        if (instance == this)
        {
            var player = GameObject.Find("Player");
            var enterTown = GameObject.Find("FirstTimeEntrance");
            if (!hasEnteredTown)
            {
                if(enterTown != null)
                {
                    Debug.Log("Entered town for the first time");
                    player.transform.position = enterTown.transform.position;
                    hasEnteredTown = true;
                }
            }
            if(cameFrom != "")
            {
                var here = GameObject.Find(cameFrom);
                if (here != null)
                {
                    Debug.Log("player came from " + cameFrom);
                    player.transform.position = here.transform.position;
                }
            }
            if(player != null)
            {
                var playerscript = player.GetComponent<PlayerMovement>();
                if(landRank > 0)
                {
                    playerscript.hasJump = true;
                }
                if(seaRank >= 3)
                {
                    playerscript.hasDash = true;
                }
                if (landRank >= 3)
                {
                    playerscript.hasStairs = true;
                }
            }
        }
    }
    private void Start()
    {
        UpdateFactionObjs();
    }
    public void UpdateFactionObjs()
    {
        factionObjects = GameObject.FindGameObjectsWithTag("UpdateOnFaction");
        foreach (GameObject obj in factionObjects)
        {
            obj.GetComponent<FactionLockedDoor>().UpdateFactions();
        }
    }
    public void RankUp(int targetFaction, int increase)
    {
        UpdateFactionObjs();
        //land
        if(targetFaction == 0)
        {
            landRank += increase;
        }
        //sea
        else if(targetFaction == 1)
        {
            seaRank += increase;
        }
        //fishman
        else
        {
            fishmanRank += increase;
        }
        //underwater dive upgrade

        //if()
        //zipline
        //hit ground
        //dash

        //player gets abilites right before an ending. "Thanks for helping us this much" type thing.
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void UpdateAbilities()
    {

    }
}

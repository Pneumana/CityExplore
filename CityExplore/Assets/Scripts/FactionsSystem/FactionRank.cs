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
    public GameObject[] factionObjects;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
        DontDestroyOnLoad(gameObject);
        if (instance != null)
        {
            var player = GameObject.Find("Player");
            var enterTown = GameObject.Find("FirstTimeEntrance");
            if (!hasEnteredTown)
            {
                if(enterTown != null)
                {
                    player.transform.position = enterTown.transform.position;
                    hasEnteredTown = true;
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
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void UpdateAbilities()
    {

    }
}

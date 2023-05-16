using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class FactionRank : MonoBehaviour
{
    public int landRank;
    public int seaRank;
    public int fishmanRank;
    public static FactionRank instance;
    public bool hasEnteredTown = false;
    public string cameFrom;
    public List<GameObject> factionObjects = new List<GameObject>();
    private GameObject[] factionarray;
    private GameObject here;
    public int wait = 0;
    public bool forceRefresh;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(this.gameObject);
        
    }
    
    private void Start()
    {
        UpdateFactionObjs();
        //LoadPosition();
    }
    public void UpdateFactionObjs()
    {
        //factionarray = GameObject.FindGameObjectsWithTag("UpdateOnFaction");
/*        foreach(GameObject obj in factionarray)
        {
            factionObjects.Add(obj);
        }*/
        foreach (GameObject obj in factionObjects)
        {
            Debug.Log(obj.name + " has been updated");
            obj.GetComponent<FactionLockedDoor>().UpdateFactions();
        }
    }
    private GameObject WhereAmI(string name)
    {
        GameObject output = null;
        output = GameObject.Find(name);
        return output;
    } 
    public void LoadPosition()
    {

            var player = GameObject.Find("Player");
            var enterTown = GameObject.Find("FirstTimeEntrance");
        /*if (!hasEnteredTown)
        {
            if(enterTown != null)
            {
                Debug.Log("Entered town for the first time");
                player.transform.position = enterTown.transform.position;
                hasEnteredTown = true;
            }
        }*/
        //Debug.Log("came from " + cameFrom);
        Debug.Log("player came from " + instance.cameFrom);
        //var here = WhereAmI(instance.cameFrom);
        //Debug.Log(here.name);
         if (here != null)
         {
            Debug.Log(here.name);
            Debug.Log("object is not null");
            player.transform.position = here.transform.position;
         }
            
            if (player != null)
            {
                var playerscript = player.GetComponent<PlayerMovement>();
                if (landRank > 0)
                {
                    playerscript.hasJump = true;
                }
                if (seaRank >= 3)
                {
                    playerscript.hasDash = true;
                }
                if (landRank >= 3)
                {
                    playerscript.hasStairs = true;
                }
            }
        
    }
    public void RankUp(int targetFaction, int increase)
    {
        
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
        UpdateFactionObjs();
    }
    // Update is called once per frame
    void Update()
    {
        if (wait <= 1)
            wait++;
        if(wait == 1)
        {
            
            LoadPosition();
        }
        if(here == null)
        {
            here = GameObject.Find(cameFrom);
            if(here != null)
            {
                LoadPosition();
            }
        }
        if (forceRefresh)
        {
            UpdateFactionObjs();
            forceRefresh = false;
        }
    }
    void UpdateAbilities()
    {

    }
}

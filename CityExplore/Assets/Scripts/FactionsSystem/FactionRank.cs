using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FactionRank : MonoBehaviour
{
    public int landRank;
    public int seaRank;
    public int fishmanRank;
    public static FactionRank instance;
    public bool hasEnteredTown = false;
    public string cameFrom;
    public List<GameObject> factionObjects = new List<GameObject>();
    public GameObject[] factionarray;
    private GameObject here;
    public int wait = 0;
    public bool forceRefresh;
    public int playcutscene;
    GameObject cutsceneobject;
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
        //UpdateFactionObjs();
        if (seaRank == 0)
        {
            seaRank = 1;
            fishmanRank = 1;
        }
        
        //LoadPosition();
    }
    public void UpdateFactionObjs()
    {
        //factionarray = GameObject.FindGameObjectsWithTag("UpdateOnFaction");
        /*        foreach(GameObject obj in factionarray)
                {
                    factionObjects.Add(obj);
                }*/
        factionarray = factionObjects.ToArray();
        var prunedarray = factionarray;
        //list = factionObjects.Count;
        //prune null objects
/*        factionObjects.Clear();
        for(int i = 0; i> factionarray.Length; i++)
        {
            Debug.Log(factionarray[i].name);
            if (factionarray[i] != null)
            {
                prunedarray[i] = factionarray[i];
            }
        }
        foreach (GameObject obj in prunedarray)
        {
            factionObjects.Add(obj);
        }*/
//this is really inefficient, but i can't get my solution to work :(
        foreach (GameObject obj in factionarray)
        {
            if(obj != null)
            {
                Debug.Log(obj.name + " has been updated");
                obj.GetComponent<FactionLockedDoor>().UpdateFactions();
            }
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
        UpdateFactionObjs();
        
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
            if(player != null)
                player.transform.position = here.transform.position;
         }
            
            if (player != null)
            {
                var playerscript = player.GetComponent<PlayerMovement>();
                if (landRank >= 1)
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
    public void Cutscene()
    {
        cutsceneobject = GameObject.Find("CutscenePlayer");
        CutscenePlayer cutscene = null;
        if (cutsceneobject != null)
        {
            cutscene = cutsceneobject.GetComponent<CutscenePlayer>();

        }
        else
        {
            Debug.Log("cutscene player object isnt in this scene");
        }
        if (cutscene != null)
        {
            if (playcutscene != 0)
                cutscene.StartCutscene(playcutscene);
            else
                Debug.Log("no cutscene to play");
        }
        else
        {
            Debug.Log("cutscene player isnt real");
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
        if (cutsceneobject == null)
            Cutscene();
    }
    void UpdateAbilities()
    {

    }
}

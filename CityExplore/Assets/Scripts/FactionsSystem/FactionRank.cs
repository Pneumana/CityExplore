using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactionRank : MonoBehaviour
{
    public int landRank;
    public int seaRank;
    public int fishmanRank;

    // Start is called before the first frame update
    void Start()
    {
        
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
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

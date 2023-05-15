using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactionLockedDoor : MonoBehaviour
{
    public int landLevel;
    public int seaLevel;
    public int fishmanLevel;
    public bool specificStep;
    void Start()
    {
        if (specificStep)
            CanISpawn();
        else
            UpdateFactions();
    }
    public void UpdateFactions()
    {
        var factions = FactionRank.instance;
        if (factions != null)
        {
            if (factions.landRank >= landLevel)
            {
                if (factions.seaRank >= seaLevel)
                {
                    if (factions.fishmanRank >= fishmanLevel)
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
    public void CanISpawn()
    {
        var factions = FactionRank.instance;
        if (factions != null)
        {
            if (factions.landRank == landLevel)
            {
                if (factions.seaRank == seaLevel)
                {
                    if (factions.fishmanRank == fishmanLevel)
                    {
                        return;
                    }
                }
            }
        }
        Destroy(gameObject);
    }
}

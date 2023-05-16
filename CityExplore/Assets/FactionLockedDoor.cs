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
        UpdateFactions();
    }

    public void UpdateFactions()
    {
        if (specificStep)
            CanISpawn();
        else if (!specificStep)
            Kill();
    }
    public void Kill()
    {
        var flip = true;
        var factions = FactionRank.instance;
        if (factions != null)
        {
            if (factions.landRank >= landLevel && landLevel > 0)
            {
                flip = false;
            }
            if (factions.fishmanRank >= fishmanLevel && fishmanLevel > 0)
            {
                flip = false;
            }
            if (factions.seaRank >= seaLevel && seaLevel > 0)
            {
                flip = false;
            }
        }
        gameObject.SetActive(flip);
        if (!factions.factionObjects.Contains(gameObject))
        {
            factions.factionObjects.Add(gameObject);
        }
    }
    public void CanISpawn()
    {
        var flip = false;
        var factions = FactionRank.instance;
        if (factions != null)
        {
            if (factions.landRank == landLevel && landLevel > 0)
            {
                flip = true;
            }
            if (factions.fishmanRank == fishmanLevel && fishmanLevel > 0)
            {
                flip = true;
            }
            if (factions.seaRank == seaLevel && seaLevel > 0)
            {
                flip = true;
            }
        }
        gameObject.SetActive(flip);
        if (!factions.factionObjects.Contains(gameObject))
        {
            factions.factionObjects.Add(gameObject);
        }
        
    }
}

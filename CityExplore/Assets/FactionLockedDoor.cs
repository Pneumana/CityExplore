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
        var factions = FactionRank.instance;
        if (factions != null)
        {
            if (factions.landRank >= landLevel)
            {
                if (factions.seaRank >= seaLevel)
                {
                    if (factions.fishmanRank >= fishmanLevel)
                    {
                        gameObject.SetActive(false);
                    }
                }
            }
        }
    }
    public void CanISpawn()
    {
        var flip = false;
        var factions = FactionRank.instance;
        if (factions != null)
        {
            if (factions.landRank == landLevel)
            {
                flip = true;
            }
            if (factions.fishmanRank == fishmanLevel)
            {
                flip = true;
            }
            if (factions.seaRank == seaLevel)
            {
                flip = true;
            }
        }
        if (!factions.factionObjects.Contains(gameObject))
        {
            factions.factionObjects.Add(gameObject);
        }
        gameObject.SetActive(flip);
    }
}

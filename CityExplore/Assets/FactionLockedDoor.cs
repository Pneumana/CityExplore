using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactionLockedDoor : MonoBehaviour
{
    public int landLevel;
    public int seaLevel;
    public int fishmanLevel;
    void Start()
    {
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
}

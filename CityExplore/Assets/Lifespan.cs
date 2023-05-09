using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifespan : MonoBehaviour
{
    public float lifetime;
    public ParticleSystem spawners;
    void Update()
    {
        if(lifetime > 0)
            lifetime-=Time.deltaTime;
        else
        {
            var emit = spawners.emission;
            emit.rateOverTimeMultiplier = 0;
            if(spawners.particleCount == 0)
            {
                Destroy(gameObject);
            }
        }
    }
    
}

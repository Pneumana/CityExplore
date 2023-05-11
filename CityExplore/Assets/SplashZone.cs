using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var splash = Instantiate(Resources.Load<GameObject>("Prefabs/TsunamiSplash"));
        splash.transform.position = other.transform.position;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillObjectOnPlayerCollide : MonoBehaviour
{
    public GameObject killThis;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //OnTrigge
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            if (killThis != null)
            {
                Destroy(killThis);
            }
            
        }
    }
}

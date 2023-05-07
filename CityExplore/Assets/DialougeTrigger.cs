using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeTrigger : MonoBehaviour
{
    public Dialouge dialouge;
    public bool destroyOnTrigger = false;
    public void SendDialouge()
    {
        FindObjectOfType<DialougeSystem>().EnterDialouge(dialouge);
        if (destroyOnTrigger)
            Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("touched Player");
            SendDialouge();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("touched Player");
            SendDialouge();
        }
    }
}

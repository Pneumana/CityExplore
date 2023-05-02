using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorFinder : MonoBehaviour
{
    public GameObject player;
/*    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("touch");
        if (collision.gameObject.tag == "Floor")
        {
            player.GetComponent<PlayerMovement>().grounded = true;
            Debug.Log("Touched ground");
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            player.GetComponent<PlayerMovement>().grounded = false;
            Debug.Log("Left Gorund");
        }
    }*/

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("touch");
        if (other.gameObject.tag == "Floor")
        {
            player.GetComponent<PlayerMovement>().grounded = false;
            Debug.Log("left ground");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("touch");
        if (other.gameObject.tag == "Floor")
        {
            player.GetComponent<PlayerMovement>().grounded = true;
            Debug.Log("Touched ground");
        }
    }
}

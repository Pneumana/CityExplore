using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public GameObject player;
    public float zOffset = -16;
    public float yOffset = 15;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 modPos = new Vector3(player.transform.position.x, player.transform.position.y + yOffset, player.transform.position.z + zOffset);
        Vector3 lerp = Vector3.Slerp(transform.position, modPos, 0.1f);
        transform.position = lerp;
        //transform.LookAt(player.transform);
    }
}

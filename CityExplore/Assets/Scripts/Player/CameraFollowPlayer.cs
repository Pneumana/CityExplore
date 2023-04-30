using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lerp = Vector3.Lerp(new Vector3(player.transform.position.x, player.transform.position.y + 16, player.transform.position.z - 12), transform.position, 0.1f);
        transform.position = lerp;
        transform.LookAt(player.transform);
    }
}

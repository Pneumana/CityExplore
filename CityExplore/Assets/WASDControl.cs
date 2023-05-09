using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDControl : MonoBehaviour
{
    Rigidbody rb;
    GameObject player;
    public float speed;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        var xInput = 0f;
        var yInput = 0f;
        if (Input.GetKey(KeyCode.W))
        {
            yInput = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            yInput = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            xInput = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            xInput = 1;
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            CastRamp();
        }
        rb.velocity = new Vector3(xInput, 0, yInput) * speed;
    }
    public void CastRamp()
    {
        Destroy(GameObject.Find("TempStairs(Clone)"));
        var ramp = Instantiate(Resources.Load<GameObject>("Prefabs/TempStairs"));
        ramp.transform.position = gameObject.transform.position;

        if(player.transform.position.x > transform.position.x)
        {
            ramp.transform.localScale = new Vector3(-1, 1, 1);
        }


        player.GetComponent<PlayerMovement>().enabled = true;

        Destroy(this.gameObject);
    }
}

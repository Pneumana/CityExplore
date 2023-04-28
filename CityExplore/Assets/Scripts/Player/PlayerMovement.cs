using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput= 0f;
        float yInput = 0f;
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
        rb.velocity = new Vector2(xInput,yInput) * speed;
    }
}

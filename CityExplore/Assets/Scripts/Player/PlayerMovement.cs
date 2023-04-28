using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject shadow;
    public float speed;
    float zAxis;
    float zStart;
    bool isJumping;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        zStart = transform.position.z;
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
        if (Input.GetKey(KeyCode.Space) && zAxis<=0)
        {
            Debug.Log("Jump");
            isJumping = true;
        }
        if (isJumping)
            Jump();
        rb.velocity = new Vector2(xInput,yInput) * speed;
        if(shadow != null)
        {
            shadow.transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, shadow.transform.position.z);
            
            
        }
    }
    void Jump()
    {
        if(zAxis<Mathf.PI)
            zAxis+=3.14f * Time.deltaTime;
        else
        {
            Debug.Log("Landed from Jump");
            zAxis = 0;
            gameObject.layer = 0;
            isJumping = false;
        }
        if(zAxis < Mathf.PI / 2 && zAxis > 0)
        {
            //first part of the jump
            gameObject.layer = 3;
        }
        else
        {
            
            //falling part of the jump
        }
        var sinedZ = Mathf.Sin(zAxis);
        gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, zStart - (sinedZ * 2));
        shadow.transform.localScale = new Vector3(1 - sinedZ, 1 - sinedZ, 1 - sinedZ);
    }
}

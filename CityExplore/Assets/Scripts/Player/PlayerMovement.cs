using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public GameObject shadow;
    public float speed;
    float zAxis;
    float zStart;
    public float jumpStr;
    bool isJumping;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        if (Input.GetKey(KeyCode.Space) && isJumping == false)
        {
            Debug.Log("Jump");
            isJumping = true;
            rb.AddForce(new Vector3(0, jumpStr, 0), ForceMode.Impulse);
        }
        if(isJumping)
            Jump();
        rb.AddForce( new Vector3(xInput,0,yInput) * speed, ForceMode.Impulse);
        if(shadow != null)
        {
            shadow.transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, shadow.transform.position.z);
            
            
        }
    }
    void Jump()
    {
        //fall = rb.velocity.y;
        //gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, zStart - (sinedZ * 2));
        //shadow.transform.localScale = new Vector3(1 - sinedZ, 1 - sinedZ, 1 - sinedZ);
    }
    private void OnCollisionEnter(Collision collision)
    {
        isJumping = false;
    }
}

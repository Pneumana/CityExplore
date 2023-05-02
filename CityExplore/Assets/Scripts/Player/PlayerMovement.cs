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
    Vector3 startedJump;
    public bool grounded = true;
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
        //float jumping = rb.velocity.y;
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
            startedJump = transform.position;
            zAxis = 0;
            rb.AddForce(new Vector3(0, jumpStr, 0), ForceMode.Impulse);
        }
        if(isJumping)
            Jump();
        rb.velocity = new Vector3(xInput, 0, yInput) * speed;
        
        if(!grounded && !isJumping)
        {
            transform.position += (Vector3.down * jumpStr) * Time.deltaTime;
        }
        if(shadow != null)
        {
            shadow.transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, shadow.transform.position.z);
            
            
        }
    }
    void Jump()
    {
        
        if (zAxis <= Mathf.PI)
        {
            zAxis += Time.deltaTime * 5;
        }
        else
        {
            zAxis = 0;
            isJumping = false;
            Debug.Log("jump is done");
        }
        var SinedY = Mathf.Sin(zAxis);
        transform.position = new Vector3(transform.position.x, startedJump.y + SinedY, transform.position.z);
        //fall = rb.velocity.y;
        //gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, zStart - (sinedZ * 2));
        //shadow.transform.localScale = new Vector3(1 - sinedZ, 1 - sinedZ, 1 - sinedZ);
    }
    private void OnCollisionEnter(Collision collision)
    {
        isJumping = false;
        zAxis = 0;
        startedJump = transform.position;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public GameObject shadow;
    public float speed;
    float zAxis;
    float zStart;
    public float jumpStr;
    public bool isJumping;
    Vector3 startedJump;
    public bool grounded = true;
    float dashFrames;
    Vector2 lockedinput;

    public bool hasJump;
    public bool hasDash;
    public bool hasStairs;
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
        if (hasDash)
        {
            if (!isJumping && grounded && Input.GetKeyDown(KeyCode.LeftShift))
            {
                dashFrames = 0.2f;
            }
        }
        if (hasJump)
        {
            if (Input.GetKey(KeyCode.Space) && isJumping == false && dashFrames <= 0 && grounded)
            {
                Debug.Log("Jump");
                isJumping = true;
                startedJump = transform.position;
                zAxis = 0;
                rb.AddForce(new Vector3(0, jumpStr, 0), ForceMode.Impulse);
            }
        }
        if (hasStairs)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                CastRamp();
            }
        }
        if(isJumping)
            Jump();
        if(dashFrames <= 0)
        {
            if (xInput != 0 || yInput != 0)
            {
                lockedinput = new Vector2(xInput, yInput);
            }
        }
        if (dashFrames > 0)
        { 
            var output = Dash(lockedinput.x, lockedinput.y);
            xInput = output.x;
            yInput = output.y;
        }
        rb.velocity = new Vector3(xInput, 0, yInput) * speed;
        //fall
        if(!grounded && !isJumping && dashFrames <= 0)
        {
            Debug.Log("fall");
            transform.position += (Vector3.down * jumpStr * 2) * Time.deltaTime;
        }
        if(shadow != null)
        {
            shadow.transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, shadow.transform.position.z);
            
            
        }
    }
    private Vector2 Dash(float xin, float yin)
    {
        if(dashFrames > 0)
            dashFrames-= Time.deltaTime;
        //dash locks direction
        return new Vector2(xin * 2, yin * 2);
    }
    void Jump()
    {
        
        if (zAxis <= Mathf.PI)
        {
            zAxis += Time.deltaTime * 10;
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
    public void CastRamp()
    {
        var ramp = Instantiate(Resources.Load<GameObject>("Prefabs/Target"));
        ramp.transform.position = gameObject.transform.position;
        this.enabled = false;
    }
}

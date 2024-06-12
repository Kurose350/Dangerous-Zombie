using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runSpeed;
    public float walkSpeed;
    bool running;
    Rigidbody myRB;
    Animator myAnim;
    bool facingRight;
    bool Grounded =false;
    Collider[] groundcollisions;
    float groundCheckradius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpheight;
    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        myAnim = GetComponent<Animator>();
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        running = false;
        if (Grounded && Input.GetAxis("Jump") > 0)
        {
            Grounded = false;
            myAnim.SetBool("Grounded", Grounded);
            myRB.AddForce( new Vector3(0, jumpheight, 0));
        }
        groundcollisions = Physics.OverlapSphere(groundCheck.position, groundCheckradius, groundLayer);
        if (groundcollisions.Length > 0)
        {
            Grounded = true;
        }
        else
        {
            Grounded=false;
        }
        myAnim.SetBool("Grounded", Grounded);
        float move = Input.GetAxis("Horizontal");
        myAnim.SetFloat("speed", Mathf.Abs(move));
        float sneaking = Input.GetAxisRaw("Fire3");
        myAnim.SetFloat("sneaking", sneaking);
        float firing = Input.GetAxis("Fire1");
        myAnim.SetFloat("shooting", firing);
        if ((sneaking > 0 || firing>0)&& Grounded)
        {
            myRB.velocity = new Vector3(move * walkSpeed, myRB.velocity.y, 0);
        }
        else
        {
            myRB.velocity = new Vector3(move * runSpeed, myRB.velocity.y, 0);
            if(Mathf.Abs(move) >0)
                running = true;
        }  
        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if(move < 0 && facingRight) 
        {
            Flip();
        }
    }
    void Flip()
    {
        facingRight =!facingRight;
        Vector3 theScale = transform.localScale;
        theScale.z *= -1;
        transform.localScale = theScale;
    }
    public float GetFacing()
    {
        if (facingRight)
            return 1;
        else
            return -1;
    }
    public bool getRunning()
    {
        return (running);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{


    [Header("Horizontal Movement Settings")]
    [SerializeField] private float walkSpeed = 1;
    
    [Header("Ground Check Settings")]
    [SerializeField] private float jumpForce= 15;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private float GroundCheckY = 0.2f;
    [SerializeField] private float GroundCheckX = 0.5f;
    [SerializeField] private LayerMask whatIsGround;

    private Rigidbody2D rb;
    private float xAxis;
    private float xScale;
    Animator anim;

    public static PlayerController Instance;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        xScale = transform.localScale.x;

        anim = GetComponent<Animator>();
    }

    void Update()
    {
        GetInputs();
        Move(); 
        Jump();
        Flip();
    }

    void GetInputs()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
    }

    void Flip()
    {
        if(xAxis < 0)
        {
            transform.localScale = new Vector2(-xScale, transform.localScale.y);
        }
        else if(xAxis > 0)
        {
            transform.localScale = new Vector2(xScale, transform.localScale.y);
        }
    }


    private void Move()
    {
        rb.velocity = new Vector2(walkSpeed * xAxis, rb.velocity.y);
        anim.SetBool("IsWalking", rb.velocity.x != 0 && Grounded());
    }

    public bool Grounded()
    {
        if (Physics2D.Raycast(GroundCheck.position, Vector2.down * transform.localScale.y, GroundCheckY, whatIsGround)
             || Physics2D.Raycast(GroundCheck.position + new Vector3(GroundCheckX, 0, 0), Vector2.down, GroundCheckY, whatIsGround)
             || Physics2D.Raycast(GroundCheck.position + new Vector3(-GroundCheckX, 0, 0), Vector2.down, GroundCheckY, whatIsGround))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void Jump()
    {
        if(Input.GetButtonUp("Jump") && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
        
        if (Input.GetButtonDown("Jump") && Grounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce * transform.localScale.y);
        }
    }

}

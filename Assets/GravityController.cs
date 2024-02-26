using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GravityController : MonoBehaviour
{

    private Rigidbody2D rb;
    private float xScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            rb.gravityScale *= -1;
        
            transform.localScale = new Vector2 (transform.localScale.x, transform.localScale.y * -1);
        }
    }
}

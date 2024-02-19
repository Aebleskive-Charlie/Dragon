using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour {

  private Rigidbody2D rb;
    
  void Start(){
    rb = GetComponent<Rigidbody2D>();
  }

  void Update()
  {
      if(Input.GetKeyDown(KeyCode.E)){
        rb.gravityScale *= -1;

      }
    
  }
}
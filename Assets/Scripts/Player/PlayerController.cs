using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   [SerializeField] private float jumpForce = 6f;
   public LayerMask groundMask;//quienes son los objetos del suelo| esto se configura en script en unity
   Rigidbody2D rigidBody;
   Animator animator;
   const string STATE_ALIVE = "isAlive";
   const string STATE_ON_THE_GROUND = "isOnTheGround";
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    
    void Start()
    { 
        animator.SetBool(STATE_ALIVE,true);
        animator.SetBool(STATE_ON_THE_GROUND,true);
        
    }

    void Update()
    {
        // GetKey es el turbo del boton
        if ( Input.GetKeyDown(KeyCode.Space)|| Input.GetMouseButtonDown(0))
        {
            Jump();
        }
        animator.SetBool(STATE_ON_THE_GROUND,IsTouchtheGround());
        Debug.DrawRay(this.transform.position,Vector2.down * 1.5f,Color.red);    
    }
    
    void Jump()
    {
        if (IsTouchtheGround())
        {
         rigidBody.AddForce(Vector2.up*jumpForce,ForceMode2D.Impulse);   
        }
    }
    
    //metodo que nos indica si el personaje toca el suelo
    //este metodo desencadena si salta o no
    bool IsTouchtheGround()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, 1.5f, groundMask))
        {
            animator.enabled = true;
            return true; // devuelve la logica del suelo 
        }
        else
        {
            animator.enabled = false;
            return false; // no devuelve la logica del suelo
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.Globalization;

public class Hero : MonoBehaviour
{
    [SerializeField] private float speed;
    //private int lives = 5;
    //private float JumpForce = 0.01f;
    //private bool IsGrounded = false;
    private Rigidbody2D rb;
    private bool grounded;
    private Animator anim;
    public float horizontalInput;
    //public TMP_Text cointer_of_coinField;
    //public float cointer_of_coin = 0;
    //private float GroundRadius=0.3f;
    //public transform GroundChek;
    //public LayerMask groundMask;
    private SpriteRenderer Sprite;

    /*private void FixedUpdate()
    {
        CheckGround();
    }*/
    [SerializeField] private AudioClip jump_Sound;
    [SerializeField] private AudioClip run_Sound;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Sprite = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
         

        if (horizontalInput > 0.01f)
        {
            //SoundManager.instance.PlaySound(run_Sound);
            transform.localScale = new Vector3((float)0.15, (float)0.15, (float)0.15);
          
        }
        else if (horizontalInput < -0.01f)
        {
            //SoundManager.instance.PlaySound(run_Sound);
            transform.localScale = new Vector3((float)-0.15, (float)0.15, (float)0.15);
        }

        

        if (Input.GetKey(KeyCode.Space) && grounded)
        { 
                Jump();
            SoundManager.instance.PlaySound(jump_Sound);
        }
       
        
        anim.SetBool("Run", horizontalInput != 0);
    }
    //private void Run()
    //{
    //    Vector3 dir = transform.right * Input.GetAxis("Horizontal");
    //    transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
    //    Sprite.flipX = dir.x < 0.0f;
    //    //SoundManager.instance.PlaySound(run_Sound);
    //}
    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x,(float)8);
        grounded = false;
        SoundManager.instance.PlaySound(jump_Sound);
        
    }
    //private bool IsGrounded()
        
    //{
    //    RaycastHit2D raycastHit = Physics2D.BoxCast(BoxCollider.bounds.center, BoxCollider.bounds.size,0, Vector2.down,0.1f,groundLayer);
    //    return raycastHit.collider != null;
    //}
    private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag=="Ground")
            {
                grounded = true;
            }
       


    }
    
    public bool canAttack()
    {
        return horizontalInput == 0;
    }
    
}
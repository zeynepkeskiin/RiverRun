using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    [SerializeField ] private float speed = 3f;
    [SerializeField] private float jumpForce = 50f;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;


    private bool grounded;
    private bool started;
    private bool jumping;


    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();   
        grounded = true;
       
        
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if(started && grounded)
            {
                _animator.SetTrigger("Jump");
                grounded = false;
                jumping = true;
            }
            else
            {
                _animator.SetBool("GameStarted",true);
                started = true;
            }
        }
       
            _animator.SetBool("Grounded", grounded);
        
    }
    private void FixedUpdate()
    {
        if(started)
        {

                _rigidbody2D.velocity = new Vector2(speed, _rigidbody2D.velocity.y);
        }


        if (jumping)
        {
            _rigidbody2D.AddForce(new Vector2(0f, jumpForce));
            jumping = false;
        }

 }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;

        }
    }




}

using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    

    public float Jumpforce;
    private bool isJumping;
    private bool IsFighting;

    private Rigidbody2D rig;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Attack();
    }

    private void FixedUpdate()
    {
        move();
    }

    void move()
    {
        float movement = Input.GetAxis("Horizontal");

        rig.velocity = new Vector2(movement * speed, rig.velocity.y);

        if (movement > 0)
        {
            if(!isJumping)
            {
                anim.SetInteger("transition",1);
            }
            
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (movement < 0)
        {
            if (!isJumping)
            {
                anim.SetInteger("transition",1);
            }
            
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (movement == 0 && !isJumping && !IsFighting)
        {
            anim.SetInteger("transition",0);
        }
    }
    

    void Jump()
    {
        if (Input.GetButton("Jump"))
        {
            if (!isJumping)
            {
                anim.SetInteger("transition",2);
                rig.AddForce(new Vector2(0,Jumpforce), ForceMode2D.Impulse);
                isJumping = true;
            }
            
        }
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            IsFighting = true;
            anim.SetInteger("transition",3);
            
        }
    }

    IEnumerator attack()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            IsFighting = true;
            anim.SetInteger("transition",3);
            yield return new WaitForSeconds(0.2f);
            anim.SetInteger("transition",0);
        }
    }

    

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.layer == 8)
        {
            isJumping = false;
        }
    }
}

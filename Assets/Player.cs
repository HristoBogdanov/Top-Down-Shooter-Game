using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveAmount;
    private Animator anim;

    public float health;
    private void Start()
    {
        anim = GetComponent<Animator>();
        // setting the rb to the rigidbody of the current component
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //getting the move input variables
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //calculating how much the player will move
        // .normalized ensures that the player won't move faster diagonally
        moveAmount = moveInput.normalized * speed;

        if (moveInput != Vector2.zero)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }
    
    private void FixedUpdate()
    {
        // this func gets called every single physics frame
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}

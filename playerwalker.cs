using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerwalker : MonoBehaviour
{
    public float RunSpeed = 1f;
    public float JumpSpeed = 1f;
    private Rigidbody2D rb;
    public bool facingRight = true; //Depends on if your animation is by default facing right or left
    public Health healthbar;
    public Animator anim;
    public int maxHealth = 100;
    public int currentHealth;
    public Gradient gradient;

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        healthbar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    private void Update()
    {
        anim.SetFloat("", Input.GetAxis("Horizontal"));
        anim.SetTrigger("Jump");
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * RunSpeed;


        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector3(0, JumpSpeed), ForceMode2D.Impulse);
        }
        if (movement == 0)
        {
            anim.SetBool("isRuning", false);
            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isRuning", true);
            anim.SetBool("isJumping", true);
        }

    }
}

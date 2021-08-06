using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class enemyGFX : MonoBehaviour
{
    public AIPath ai;
    public bool facingRight = true; //Depends on if your animation is by default facing right or left


    // Update is called once per frame
    void Update()
    {
        if(ai.desiredVelocity.x >= 1f)
        {
            
        }else if (ai.desiredVelocity.x <= -1f)
        {
           
        }

    }
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
}

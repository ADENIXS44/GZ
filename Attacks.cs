using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    public Animator anime;
    public Transform attackPiont;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
 
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.C)) {

            StopAttack();
        } 
       
        void StopAttack()
        {
            anime.SetBool("StopAttack", true);
        }
       
    }

    void Attack()
    {
        //Play an attack animation
        anime.SetTrigger("Attack");
        anime.SetBool("StopAttack", false);
        //Detect anemy in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPiont.position, attackRange, enemyLayers);
        //Give Damage
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit" + enemy.name);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPiont == null)
            return;
        Gizmos.DrawWireSphere(attackPiont.position, attackRange);
    }

}

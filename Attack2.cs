using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack2: MonoBehaviour
{

    public float enemyCooldown = 1;
    public float damage = 1;
    public int ControllerForPlayer;
    private bool playerInRange = false;
    private bool canAttack = true;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) ;
        {
            playerInRange = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) ;
        {
            playerInRange = false;
        }
    }
    IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(enemyCooldown);
        canAttack = true;
    }
}
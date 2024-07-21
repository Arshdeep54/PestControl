using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public int maxHealth, currentHealth,prevhealth;
    public int stunTime = 30;
    public Animator aiAnim;

    private void Awake()
    {
        maxHealth = 100;
        currentHealth = maxHealth;
        prevhealth = currentHealth;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Bullet"))
        {
            currentHealth -= 40;
        }
    }

    private void Update()
    {
        if (currentHealth < 0) 
        {
            currentHealth = 100;
            prevhealth = currentHealth;
            StunPose();
        }
        else if (prevhealth != currentHealth)
        {
            prevhealth = currentHealth;
            aiAnim.SetTrigger("stagger");
            aiAnim.ResetTrigger("idle");
            aiAnim.ResetTrigger("sprint");
            aiAnim.ResetTrigger("walk");
        }

    }

    private void StunPose()
    {
        this.GetComponent<EnemyAI>().enabled = false;
        aiAnim.ResetTrigger("idle");
        aiAnim.ResetTrigger("sprint");
        aiAnim.ResetTrigger("walk");
        aiAnim.SetTrigger("stun");
        StartCoroutine("healthReturn");
    }

    IEnumerator healthReturn()
    {
        yield return new WaitForSeconds(stunTime);
        this.GetComponent <EnemyAI>().enabled = true;
        currentHealth = maxHealth;
    }
}

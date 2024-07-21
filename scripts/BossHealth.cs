using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    public int maxHealth, currentHealth, prevhealth;
    public int stunTime ;
    public Animator aiAnim;
    public AudioSource collisionSound;
    string sceneName= "Win";

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
            currentHealth -= 10;
            collisionSound.Play();
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
            aiAnim.ResetTrigger("walk");
        }

    }

    private void StunPose()
    {
        this.GetComponent<BossAI>().enabled = false;
        aiAnim.ResetTrigger("walk");
        aiAnim.SetTrigger("stun");
        StartCoroutine("end");
    }

    IEnumerator end()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(sceneName);

    }
}

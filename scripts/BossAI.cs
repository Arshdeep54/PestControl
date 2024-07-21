using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class BossAI : MonoBehaviour
{
    public NavMeshAgent ai;
    public Animator aiAnim;
    public float walkSpeed, sightDistance, catchDistance, jumpscareTime;
    public Transform player;
    public Vector3 rayCastOffset;
    public string deathScene;
    public playerHealth health;

    private bool punching = true;

    private void Awake()
    {
        health = FindObjectOfType<playerHealth>();
    }

    private void Start()
    {
        ai.speed = walkSpeed;
        SetAnimationState("walk");
    }

    private void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        ai.destination = player.position;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            float distance = Vector3.Distance(player.position, ai.transform.position);
            if (distance <= catchDistance)
            {
                if (punching)
                {
                    aiAnim.SetTrigger("punch");
                    health.TakeDamage(10);
                    punching = false;
                    Invoke(nameof(PunchActivation), 1f);
                }
            }
            else
            {
                SetAnimationState("walk");
            }
        }
    }

    private void PunchActivation()
    {
        punching = true;
        aiAnim.ResetTrigger("punch");
        aiAnim.SetTrigger("walk");
    }

    private void SetAnimationState(string state)
    {
        aiAnim.ResetTrigger("stun");
        aiAnim.ResetTrigger("punch");
        aiAnim.ResetTrigger("walk");
        aiAnim.SetTrigger(state);
    }

    private IEnumerator DeathRoutine()
    {
        yield return new WaitForSeconds(jumpscareTime);
        SceneManager.LoadScene(deathScene);
    }
}

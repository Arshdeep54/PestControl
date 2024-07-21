using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent ai;
    public List<Transform> destinations;
    public Animator aiAnim;
    public float walkSpeed, chaseSpeed, minIdleTime, maxIdleTime, sightDistance, catchDistance, minChaseTime, maxChaseTime, jumpscareTime;
    public bool walking, chasing, punching;
    public Transform player;
    private Transform currentDest;
    private Vector3 dest;
    private int randNum;
    public Vector3 rayCastOffset;
    public string deathScene;
    public playerHealth health;
    public AudioSource footsteps;

    private void Awake()
    {
        health = FindObjectOfType<playerHealth>();
        punching = true;
    }

    private void Start()
    {
        walking = true;
        SetRandomDestination();
    }

    private void Update()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        RaycastHit hit;
        if (Physics.Raycast(transform.position + rayCastOffset, direction, out hit, sightDistance))
        {
            if (hit.collider.CompareTag("Player"))
            {
                StartChasing();
            }
        }

        if (chasing)
        {
            HandleChasing();
        }
        else if (walking)
        {
            HandleWalking();
        }

        // Play or stop footsteps based on movement
        if (ai.velocity.sqrMagnitude > 0 && !footsteps.isPlaying)
        {
            footsteps.Play();
        }
        else if (ai.velocity.sqrMagnitude == 0 && footsteps.isPlaying)
        {
            footsteps.Stop();
        }
    }

    private void SetRandomDestination()
    {
        randNum = Random.Range(0, destinations.Count);
        currentDest = destinations[randNum];
    }

    private void StartChasing()
    {
        walking = false;
        chasing = true;
        StopAllCoroutines();
        StartCoroutine(nameof(ChaseRoutine));
    }

    private void HandleChasing()
    {
        dest = player.position;
        ai.destination = dest;
        ai.speed = chaseSpeed;

        float distance = Vector3.Distance(player.position, ai.transform.position);
        if (distance <= catchDistance)
        {
            if (punching)
            {
                SetAnimationState("punch");
                health.TakeDamage(5);
                punching = false;
                Invoke("PunchActivation", 1f);
            }
        }
        else
        {
            SetAnimationState("sprint");
        }
    }

    private void HandleWalking()
    {
        dest = currentDest.position;
        ai.destination = dest;
        ai.speed = walkSpeed;
        SetAnimationState("walk");

        if (ai.remainingDistance <= ai.stoppingDistance)
        {
            SetAnimationState("idle");
            ai.speed = 0;
            StartCoroutine(nameof(StayIdle));
            walking = false;
        }
    }

    private void PunchActivation()
    {
        punching = true;
    }

    private IEnumerator PunchActivate()
    {
        Debug.Log("before coroutine line");

        yield return new WaitForSeconds(0.5f);
        punching = true;
        Debug.Log("after coroutine line");
    }

    private void SetAnimationState(string state)
    {
        aiAnim.ResetTrigger("stun");
        aiAnim.ResetTrigger("punch");
        aiAnim.ResetTrigger("sprint");
        aiAnim.ResetTrigger("walk");
        aiAnim.ResetTrigger("idle");
        aiAnim.SetTrigger(state);
    }

    private IEnumerator StayIdle()
    {
        float idleTime = Random.Range(minIdleTime, maxIdleTime);
        yield return new WaitForSeconds(idleTime);
        walking = true;
        SetRandomDestination();
    }

    private IEnumerator ChaseRoutine()
    {
        float chaseTime = Random.Range(minChaseTime, maxChaseTime);
        yield return new WaitForSeconds(chaseTime);
        walking = true;
        chasing = false;
        SetRandomDestination();
    }

    private IEnumerator DeathRoutine()
    {
        yield return new WaitForSeconds(jumpscareTime);
        SceneManager.LoadScene(deathScene);
    }
}

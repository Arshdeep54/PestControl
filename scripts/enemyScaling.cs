using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScaling : MonoBehaviour
{
    public Animator enemyScalingAnim;

    private void Awake()
    {
        enemyScalingAnim = GetComponent<Animator>();    
    }

    private void Start()
    {
        enemyScalingAnim.SetTrigger("scale");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float life = 3;
    void Awake()
    {
        Destroy(gameObject, life);
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Obstacle")
        {   
            Destroy(other.gameObject);
        }
        Destroy(gameObject);



    }
}

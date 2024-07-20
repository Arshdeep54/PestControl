using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunSystem : MonoBehaviour
{

    public Transform BulletSpawnPoint;
    public GameObject Bullet;

    public float speed = 1f;
    void Update()   
    {

        if (Input.GetButtonDown("Fire1"))
        {
            var bullet = Instantiate(Bullet, BulletSpawnPoint.position, BulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = BulletSpawnPoint.forward * speed;

        }

    }


}

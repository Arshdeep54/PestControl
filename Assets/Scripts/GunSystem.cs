using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunSystem : MonoBehaviour
{

    public Transform BulletSpawnPoint;
    public GameObject Bullet;
    public Camera cam;

    public float speed = 1f;
    void Update()   
    {

        if (Input.GetButtonDown("Fire1"))
        {
            var bullet = Instantiate(Bullet, BulletSpawnPoint.position, BulletSpawnPoint.rotation);
            

            Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 directionToHit = (hit.point - BulletSpawnPoint.position).normalized;
                bullet.GetComponent<Rigidbody>().velocity = directionToHit * speed;
            }
            else
            {
                bullet.GetComponent<Rigidbody>().velocity = BulletSpawnPoint.forward * speed;
            }
        }

    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSystem : MonoBehaviour
{

    public Transform LaunchPoint;
    public GameObject projectile;
    public Transform cam;

    public float launchSpeed = 10f;
    public int totalThrows; 
    public float throwCoolDown;
    public float throwForce;
    public float throwUpwardForce;
    public bool readyToThrow;
    public AudioSource fireAudio;
    private void Start()
    {
        readyToThrow = true;
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && readyToThrow && totalThrows > 0)
        {

            Throw();
            // Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            // RaycastHit hit;
            // if (Physics.Raycast(ray, out hit))
            // {
            //     Vector3 directionToHit = (hit.point - LaunchPoint.position).normalized;
            //     _projectile.GetComponent<Rigidbody>().velocity = directionToHit * launchSpeed;
            // }
            // else
            // {

            //     _projectile.GetComponent<Rigidbody>().velocity = launchSpeed * LaunchPoint.up;
            // }
        }
    }
    private void Throw()
    {
        readyToThrow = false;
        GameObject _projectile = Instantiate(projectile, LaunchPoint.position, LaunchPoint.rotation);
        Rigidbody projectileRB = _projectile.GetComponent<Rigidbody>();
        Vector3 forceDirection = cam.transform.forward;

        RaycastHit hit;
        if (Physics.Raycast(cam.position, cam.forward, out hit, 500f))
        {
            forceDirection = (hit.point - LaunchPoint.position).normalized;
        }
        fireAudio.Play();
        Vector3 forceToAdd = cam.transform.forward * throwForce + transform.up * throwUpwardForce;
        projectileRB.AddForce(forceToAdd, ForceMode.Impulse);
        totalThrows--;
        Invoke(nameof(ResetThrow), throwCoolDown);
    }
    private void ResetThrow()
    {
        readyToThrow = true;
    }
}

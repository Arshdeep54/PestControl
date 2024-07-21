using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickUp : MonoBehaviour
{
    public GameObject gunOb;
    public GameObject prefab;
    public GameObject pickUpText;
    public PlayerController player;
    public OptionController Player;
    public RocketSystem Rocket;
    public bool inReach;
    bool PickedUp = false;
    void Start()
    {
        inReach = false;
        pickUpText.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Reached");
        if (other.gameObject.tag == "Reach")
        {
            Debug.Log("Reached with Reach");

            inReach = true;
            pickUpText.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            pickUpText.SetActive(false);
        }
    }
    void Update()
    {
        if (inReach && Input.GetKeyDown(KeyCode.E))
        {
            gunOb.SetActive(false);
            pickUpText.SetActive(false);

            if (gunOb.gameObject.tag == "Glock")
            {
                player.playerObjects.Add(Player.weapon1);
            }
            if (gunOb.gameObject.tag == "launcher")
            {
                player.playerObjects.Add(Player.weapon2);
            }
            if (gunOb.gameObject.tag == "Ammo")
            {
                Debug.Log("ammomm");
                Rocket.totalThrows++;
                Invoke(nameof(RespawnItem), 10);
            }
            
            PickedUp = true;
        }
    }
    public void RespawnItem()
    {
        //Instantiate(prefab, transform.position, transform.rotation);
        gunOb.SetActive(true );
        Debug.Log("Spawned!");
        PickedUp = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickUp : MonoBehaviour
{
    public GameObject gunOb;
    public GameObject pickUpText;
    public PlayerController player;
    public OptionController Player;


    public bool inReach;

    void Start()
    {
        inReach = false;
        pickUpText.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            Debug.Log("reached");
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
            if (gunOb.gameObject.tag == "knife")
            {
                player.playerObjects.Add(Player.weapon2);
            }
        }
    }
}
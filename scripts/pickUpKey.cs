using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupKey : MonoBehaviour
{
    public GameObject interactionText, key;
    public AudioSource pickup;
    public bool interactable;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Reach"))
        {
            interactionText.SetActive(true);
            interactable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Reach"))
        {
            interactionText.SetActive(false);
            interactable = false;
        }
    }

    private void Update()
    {
        if (interactable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                interactionText.SetActive(false);
                interactable = false;
                //pickup.Play();
                key.SetActive(false);
            }
        }
    }
}

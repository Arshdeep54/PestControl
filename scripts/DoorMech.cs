using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMech
    : MonoBehaviour
{
    public GameObject interactionText, key, lockedText;
    public bool interactable, toggle;
    public Animator doorAnim;

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
                if (key.active == false)
                {

                    toggle = !toggle;
                    if (toggle)
                    {
                        doorAnim.ResetTrigger("close");
                        doorAnim.SetTrigger("open");
                    }
                    else
                    {
                        doorAnim.ResetTrigger("open");
                        doorAnim.SetTrigger("close");
                    }
                    interactionText.SetActive(false);
                    interactable = false;
                }

                if (key.active == true)
                {
                    lockedText.SetActive(true);
                    StopCoroutine("disableText");
                    StartCoroutine("disableText");
                }
            }
        }
    }

    IEnumerator disableText()
    {
        yield return new WaitForSeconds(2.0f);
        lockedText.SetActive(false);
    }
}

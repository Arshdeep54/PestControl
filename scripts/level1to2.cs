using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class level1to2 : MonoBehaviour
{
    public GameObject interactionText;
    public AudioSource pickup;
    public bool interactable;
    public string sceneName = "Level 2";

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
                SceneManager.LoadScene(sceneName);
               
            }
        }
    }
}

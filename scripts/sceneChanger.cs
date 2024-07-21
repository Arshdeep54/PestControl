using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChanger : MonoBehaviour
{
    public Animator camAnim;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "game over" || SceneManager.GetActiveScene().name == "Win") 
        {
            StartCoroutine(nameof(mainMenuScreen));
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            camAnim.SetTrigger("change");
            StartCoroutine("SceneChange");
        }
    }
    private IEnumerator SceneChange()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Level1");
    }

    private IEnumerator mainMenuScreen()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);

    }
}

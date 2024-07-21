using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject scene1;
    public GameObject scene2;
    public string sceneName;
    public void Start()
    {
        Cursor.lockState=CursorLockMode.None;
        Cursor.visible = true;
    }
    public void StartGame()
    {
        Scene1Enable();
        Invoke("Scene2Enable", 5f);
        Invoke("sceneChange", 10f);


    }
    public void QuitGame()
    {
        Application.Quit();
    }
    
    private void Scene1Enable()
    {
        scene1.SetActive(true);
    }
    private void Scene2Enable()
    {
        scene2.SetActive(true);
    }
    private void sceneChange()
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class OptionController : MonoBehaviour
{
    public GameObject weapon1;
    public GameObject weapon2;
    // public GameObject medikit;
    public PlayerController Player;

    void Start()
    {
        
        // Player.playerObjects.Add(medikit);
        for (int i = 0; i < Player.playerObjects.Count; i++)
        {
            Player.playerObjects[i].SetActive(false);
        }

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            for (int i = 0; i < Player.playerObjects.Count; i++)
            {
                if (i == 0)
                {
                    Player.playerObjects[i].SetActive(true);
                }
                else
                {
                    Player.playerObjects[i].SetActive(false);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            for (int i = 0; i < Player.playerObjects.Count; i++)
            {
                if (i == 1)
                {
                    Player.playerObjects[i].SetActive(true);
                }
                else
                {
                    Player.playerObjects[i].SetActive(false);
                }
            }
        }
        // if (Input.GetKeyDown(KeyCode.Alpha2))
        // {
        //     for (int i = 0; i < Player.playerObjects.Count; i++)
        //     {
        //         if (i == 2)
        //         {
        //             Player.playerObjects[i].SetActive(true);
        //         }
        //         else
        //         {
        //             Player.playerObjects[i].SetActive(false);
        //         }
        //     }
        // }
    }
}
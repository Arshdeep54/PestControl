using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class bulletDisplay : MonoBehaviour
{
    public TMP_Text bulletText;
    public RocketSystem rocketSystem;
    public GameObject rpgInHand;

    private void FixedUpdate()
    {
        if (rpgInHand.activeSelf)
        {
            bulletText.text = rocketSystem.totalThrows.ToString();
        }
        else
        {
            bulletText.text = "";
        }
    }
}

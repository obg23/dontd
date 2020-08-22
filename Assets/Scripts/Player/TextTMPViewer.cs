using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextTMPViewer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textPlayerHP;       // Text - TextMeshPro UI [PlayerHP]

    [SerializeField]
    private TextMeshProUGUI textPlayerGold;     // Text - TextMeshPro UI [PlayerGold]

    [SerializeField]
    private PlayerHP        playerHP;           // Player HP Info.

    [SerializeField]
    private PlayerGold      playerGold;         // Player Gold Info.

    private void Update()
    {
        textPlayerHP.text   = playerHP.CurrentHP + " / " + playerHP.MaxHP;
        textPlayerGold.text = playerGold.CurrentGold.ToString();
    }
}


/*
 * File : TextTMPViewer.cs
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextTMPViewer : MonoBehaviour
{
    // HP
    [SerializeField]
    private TextMeshProUGUI textPlayerHP;       // Text - TextMeshPro UI [PlayerHP]
    [SerializeField]
    private PlayerHP        playerHP;           // Player HP Info.

    // Gold
    [SerializeField]
    private TextMeshProUGUI textPlayerGold;     // Text - TextMeshPro UI [PlayerGold]
    [SerializeField]
    private PlayerGold      playerGold;         // Player Gold Info.

    // Wave
    [SerializeField]
    private TextMeshProUGUI textWave;            // Text - Wave UI [Wave / Max Wave]
    [SerializeField]
    private WaveSystem      waveSystem;         // Wave Info.


    private void Update()
    {
        textPlayerHP.text   = playerHP.CurrentHP + " / " + playerHP.MaxHP;
        textPlayerGold.text = playerGold.CurrentGold.ToString();
        textWave.text       = waveSystem.CurrentWave + " / " + waveSystem.MaxWave;
    }
}


/*
 * File : TextTMPViewer.cs
*/
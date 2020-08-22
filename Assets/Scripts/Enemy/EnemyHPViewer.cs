using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPViewer : MonoBehaviour
{
    private EnemyHP enemyHP;
    private Slider  hpSlider;

    // Start is called before the first frame update
    public void Setup(EnemyHP enemyHP)
    {
        this.enemyHP = enemyHP;
        hpSlider     = GetComponent<Slider>();
    }

    // Update is called once per frame
    private void Update()
    {
        hpSlider.value = enemyHP.CurrentHp / enemyHP.MaxHP;
    }
}


/*
 * File : EnemyHPViewer.cs
*/
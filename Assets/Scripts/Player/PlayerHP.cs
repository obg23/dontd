using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    private float       maxHP = 20;     // 최대 체력
    private float       currentHP;      // 현재 체력

    public float        MaxHP => maxHP;
    public float        CurrentHP => currentHP;

    private void Awake()
    {
        currentHP = maxHP;      // 현재 체력을 최대 체력과 같게 설정
    }

    public void TakeDamage(float damage){

        // 현재 체력을 damage만큼 감소
        currentHP -= damage;

        // 체력이 0이 되면 게임 오버
        if(currentHP <= 0){

        }
    }
}


/*
 * File : PlayerHP.cs
*/
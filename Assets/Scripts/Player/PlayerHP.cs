using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using System.Collections;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    private Image       imageScreen;    // 전체화면을 덮는 빨간색 이미지
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

        StopCoroutine("HitAlphaAnimation");
        StartCoroutine("HitAlphaAnimation");

        // 체력이 0이 되면 게임 오버
        if(currentHP <= 0){
            // Game Over
            Debug.Log("Game Over");
        }
    }

    private IEnumerator HitAlphaAnimation(){

        // 전체화면 크기로 배치된 imageScreen의 색상을 color 변수에 저장
        // imageScreen의 투명도를 40%로 설정
        Color color = imageScreen.color;
        color.a = 0.4f;
        imageScreen.color = color;

        // 투명도가 0%가 될때까지 감소
        while(color.a >= 0.0f){
            color.a -= Time.deltaTime;
            imageScreen.color = color;

            yield return null;
        }

    }
}


/*
 * File : PlayerHP.cs
*/
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // [SerializeField]
    // private GameObject  enemyPrefab;            // 적 Prefab
    [SerializeField]
    private GameObject  enemyHPSliderPrefab;    // 적 체력을 나타내는 Slider UI prefab
    [SerializeField]
    private Transform   canvasTransform;        // UI를 표현하는 Canvas 오브젝트의 Transform
    // [SerializeField]
    // private float       spwanTime;              // 적 생성 주기
    [SerializeField]
    private Transform[] wayPoints;              // 현재 스테이지의 이동 경로
    [SerializeField]
    private PlayerHP    playerHP;
    [SerializeField]
    private PlayerGold  playerGold;             // 플레이어 골드 컴포넌트

    private Wave        currentWave;            // 현재 웨이브 정보

    private List<Enemy> enemyList;              // 현재 맵에 존재하는 모든 적의 정보

    // 적의 생성과 삭제는 EnemySpawner에서 하기 때문에 Set은 필요 없다.
    public List<Enemy> EnemyList => enemyList;

    private void Awake(){

        // 적 리스트 메모리 할당
        enemyList = new List<Enemy>();

        //적 생성 코루틴 함수 호출
        // StartCoroutine("SpawnEnemy");
    }

    public void StartWave(Wave wave)
    {
        // 매개변수로 받아온 웨이브 정보 저장
        currentWave = wave;

        // 현재 웨이브 시작
        StartCoroutine("SpawnEnemy");
    }

    private IEnumerator SpawnEnemy(){

        // 현재 웨이브에서 생성한 적 숫자
        int spawnEnemyCount = 0;

        // while(true){
            
        // 현재 웨이브에서 생성되어야 하는 적의 숫자만큼 적을 생성하고 코루틴 종료
        while(spawnEnemyCount < currentWave.maxEnemyCount){
            // GameObject clone    = Instantiate(enemyPrefab);     // 적 오브젝트 생성
            // Enemy      enemy    = clone.GetComponent<Enemy>();  // 방금 생성된 적의 Enemy 컴포넌트

            // 웨이브에 등장하는 적의 종류가 여러 종류일 때 임의의 적이 등장하도록 설정하고, 적 오브젝트 생성
            int             enemyIdx    = Random.Range(0, currentWave.enemyPrefabs.Length);
            GameObject      clone       = Instantiate(currentWave.enemyPrefabs[enemyIdx]);
            Enemy           enemy       = clone.GetComponent<Enemy>();  // clone Enemy 컴포넌트

            // this 는 나 자신 (자신의 EnemySpawner 정보)
            enemy.Setup(this, wayPoints);                       // wayPoint 정보를 매개변수로 Setup() 호출
            enemyList.Add(enemy);                               // Enemy 리스트에 enemy 정보 저장

            SpawnEnemyHPSlider(clone);

            spawnEnemyCount++;

            // yield return new WaitForSeconds(spwanTime);         // spawnTime 시간 동안 대기

            // 각 웨이브마다 spawnTime이 다를 수 있기 때문에 현재 웨이브(currentWave)의 spawnTime 사용
            yield return new WaitForSeconds(currentWave.spawnTime);

        }

    }

    private void SpawnEnemyHPSlider(GameObject enemy){

        // 적 체력을 나타내는 Slider UI 생성
        GameObject sliderClone = Instantiate(enemyHPSliderPrefab);

        // Slider UI 오브젝트를 parent("Canvas" 오브젝트)의 자식으로 설정
        // Tip. UI는 캔버스의 자식오브젝트로 설정되어 있어야 화면에 보인다
        sliderClone.transform.SetParent(canvasTransform);

        // 계층 설정으로 바뀐 크기를 다시 (1,1,1)로 설정
        sliderClone.transform.localScale = Vector3.one;

        // Slider UI가 쫓아다닐때 대상을 본인으로 설정
        sliderClone.GetComponent<SliderPositionAutoSetter>().Setup(enemy.transform);

        // Slider UI에 자신의 체력 정보를 표시하도록 설정
        sliderClone.GetComponent<EnemyHPViewer>().Setup(enemy.GetComponent<EnemyHP>());


    }


    // 적 삭제 function
    public void DestoryEnemy(EnemyDestroyType type, Enemy enemy, int gold){

        // 적이 목표지점까지 도착했을 때
        if(type == EnemyDestroyType.Arrirve){
            // 플레이어 체력 -1
            playerHP.TakeDamage(1);
        }
        //적을 처치시
        else if(type == EnemyDestroyType.Kill){
            // =========== 골드 획득 ===========

            playerGold.CurrentGold += gold;
            
            // =========== 골드 획득 ===========
        }

        // 사망하는 적 enemyList에서 삭제
        enemyList.Remove(enemy);

        // 사망한 적 obj 삭제
        Destroy(enemy.gameObject);

    }

}

/*
 * File : EnemySpawner.cs
 * Funtion
 *    : 사망하는 적 삭제 function(@param Enemy : 제거할 enemy 정보)
*/
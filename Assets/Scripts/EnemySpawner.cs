using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject  enemyPrefab;    // 적 Prefab
    [SerializeField]
    private float       spwanTime;      // 적 생성 주기
    [SerializeField]
    private Transform[] wayPoints;      // 현재 스테이지의 이동 경로
    private List<Enemy> enemyList;      // 현재 맵에 존재하는 모든 적의 정보

    // 적의 생성과 삭제는 EnemySpawner에서 하기 때문에 Set은 필요 없다.
    private List<Enemy> EnemyList => enemyList;

    private void Awake(){

        // 적 리스트 메모리 할당
        enemyList = new List<Enemy>();

        //적 생성 코루틴 함수 호출
        StartCoroutine("SpawnEnemy");
    }

    private IEnumerator SpawnEnemy(){

        while(true){

            GameObject clone    = Instantiate(enemyPrefab);     // 적 오브젝트 생성
            Enemy      enemy    = clone.GetComponent<Enemy>();  // 방금 생성된 적의 Enemy 컴포넌트

            enemy.Setup(this, wayPoints);                       // wayPoint 정보를 매개변수로 Setup() 호출

            enemyList.Add(enemy);                               // Enemy 리스트에 enemy 정보 저장

            yield return new WaitForSeconds(spwanTime);         // spawnTime 시간 동안 대기
        }

    }

    // 적 삭제 function
    public void DestoryEnemy(Enemy enemy){

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
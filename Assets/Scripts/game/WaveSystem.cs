using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    [SerializeField]
    private Wave[]          waves;                  // 현재 스테이지의 모든 웨이브 정보
    [SerializeField]
    private EnemySpawner    enemySpawner;
    private int             currentWaveIdx = -1;   // 현재 웨이브 인덱스

    // 프로퍼티 셋팅
    public int              CurrentWave => currentWaveIdx+1;    // 시작 : 0
    public int              MaxWave => waves.Length;            // 총 wave

    public void StartWave()
    {

        //현재 맵에 적이 없고, Wave가 남아있으면
        if(enemySpawner.EnemyList.Count == 0 && currentWaveIdx < waves.Length-1)
        {
            // 인덱스의 시작이 -1이기 때문에 웨이브 인덱스 증가를 먼저
            currentWaveIdx++;

            // EnemySpawner의 StartWave() 함수 호출, 현재 웨이브 정보 제공
            enemySpawner.StartWave(waves[currentWaveIdx]);
        }

    }

}

[System.Serializable]
public struct Wave
{
    public float        spawnTime;      // 현재 웨이브 적 생성 주기
    public int          maxEnemyCount;  // 현재 웨이브 적 등자 숫자
    public GameObject[] enemyPrefabs;   // 현재 웨이브 적 등장 종류
}

/*
 * File : WaveSystem.cs
 * Desc
     : Wave 관리
*/

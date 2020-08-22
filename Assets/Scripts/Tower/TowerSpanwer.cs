using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpanwer : MonoBehaviour
{
    [SerializeField]
    private GameObject      towerPrefab;
    [SerializeField]
    private int             towerBuildGold = 50;    // 타워 건설에 사용되는 골드
    [SerializeField]
    private EnemySpawner    enemySpawner;           // 현재 맵에 존재하는 적 리스트 정보를 얻기 위해..
    [SerializeField]
    private PlayerGold      playerGold;             // 타워 건설시 골드 감소를 위해..

    public void SpawnTower(Transform tileTransform){
        
        // 타워 가격 validation
        if(towerBuildGold > playerGold.CurrentGold){ return; }

        Tile tile = tileTransform.GetComponent<Tile>();

        // 타일 선택 여부
        if(tile.IsBuildTower){ return; }

        // 선택한 타일 위치에 타워 생성
        GameObject clone =  Instantiate(towerPrefab, tileTransform.position, Quaternion.identity);

        // 타워 무기에 enemySpawner 정보 전달
        clone.GetComponent<TowerWeapon>().Setup(enemySpawner);

        // 타워 건설 여부 : true
        tile.IsBuildTower = true;
        playerGold.CurrentGold -= towerBuildGold;   // 타워 가격만큼 playerGold 차감

    }

    /* 
     * File : TowerSpawner
     * Desc
     *  : 타워 생성 제어
     * 
     * Functions
     *  : SpawnTower(@param tileTransform : 선택한 위치) - 매개변수의 위치에 타워 생성
    */

}

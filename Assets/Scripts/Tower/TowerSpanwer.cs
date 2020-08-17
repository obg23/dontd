using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpanwer : MonoBehaviour
{
    [SerializeField]
    private GameObject towerPrefab;
    [SerializeField]
    private EnemySpawner enemySpawner; // 현재 맵에 존재하는 적 리스트 정보를 얻기 위해..
    public void SpawnTower(Transform tileTransform){
        
        Tile tile = tileTransform.GetComponent<Tile>();

        // 타일 선택 여부
        if(tile.IsBuildTower){ return; }


        // 선택한 타일 위치에 타워 생성
        GameObject clone =  Instantiate(towerPrefab, tileTransform.position, Quaternion.identity);

        // 타워 무기에 enemySpawner 정보 전달
        clone.GetComponent<TowerWeapon>().Setup(enemySpawner);

        // 타워 건설 여부 : true
        tile.IsBuildTower = true;
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

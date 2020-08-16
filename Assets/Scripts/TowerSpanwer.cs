using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpanwer : MonoBehaviour
{
    [SerializeField]
    private GameObject towerPrefab;

    public void SpawnTower(Transform tileTransform){
        
        Tile tile = tileTransform.GetComponent<Tile>();

        // 타일 선택 여부
        if(!tile.IsBuildTower){
            // 선택한 타일 위치에 타워 생성
            Instantiate(towerPrefab, tileTransform.position, Quaternion.identity);

            tile.IsBuildTower = true; // 타워 건설 여부 : true
        }
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

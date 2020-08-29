using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetector : MonoBehaviour
{
    [SerializeField]
    private TowerSpanwer    towerSpanwer;
    [SerializeField]
    private TowerDataViewer towerDataViewer;

    private Camera          mainCamera;
    private Ray             ray;
    private RaycastHit      hit;

    private void Awake()
    {
        // "MainCamera" 태그를 가지고 있는 오브젝트 탐색 후 Camera 컴포넌트 정보 전달
        // GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Cameara>(); 와 동일
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            
            // 카메라 위치에서 화면의 마우스 위치를 관통하는 광선 생선
            // ray.origin    : 광선의 시작위치(=카메라위치)
            // ray.direction : 광선의 진행방향
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            // 2D 모니터를 통해 3D 월드의 오브젝트를 마우스로 선택하는 방법
            // 광선에 부딪히는 오브젝트를 검출해서 hit에 저장
            if(Physics.Raycast(ray, out hit, Mathf.Infinity)){

                // 광선에 부딪힌 오브젝트의 태그가 "Tile" 일 경우
                if(hit.transform.CompareTag("Tile")){

                    // 타워 생성 : SpawnTower() 호출
                    towerSpanwer.SpawnTower(hit.transform);
                }
                // 타워를 선택하면 해당 타워 정보를 출력하는 함수 호출
                else if(hit.transform.CompareTag("Tower")){
                    towerDataViewer.OnPanel();
                }
            }

        }
    }
}


/*
 * File : ObjectDetector.cs
*/
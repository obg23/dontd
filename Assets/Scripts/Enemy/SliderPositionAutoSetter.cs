using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderPositionAutoSetter : MonoBehaviour
{
    [SerializeField]
    private Vector3         distance = Vector3.down * 20.0f;
    private Transform       targetTransform;
    private RectTransform   rectTransform;

    public void Setup(Transform target){

        // Slider UI가 쫓아다닐 target 설정
        targetTransform = target;

        // RectTransform 컴포넌트 정보 얻기
        rectTransform = GetComponent<RectTransform>();

    }

    private void LateUpdate(){

        if(targetTransform == null){
            Destroy(gameObject);
            return;
        }

        // 오브젝트의 위치가 갱신된 이후에 Slider UI도 함께 위치를 설정하도록 하기 위해
        // LateUpdate()에서 호출
        
        // 오브젝트의 월드 좌표를 기준으로 화면에서의 좌표값을 구함
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(targetTransform.position);

        // 화면내에서 좌표 + distance만큼 떨어진 위치를 Slider UI의 위치로 설정
        rectTransform.position = screenPosition + distance;

    }

}

/*
 * File : SliderPositionAutoSetter.cs
*/
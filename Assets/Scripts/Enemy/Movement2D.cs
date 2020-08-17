using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    [SerializeField]
    private float   moveSpeed = 0.0f;
    [SerializeField]
    private Vector3 moveDirection = Vector3.zero;

    public float    MoveSpeed => moveSpeed;         // moveSpeed 변수의 프로퍼티 (get 가능)

    void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;   // 적 이동
    }

    public void MoveTo(Vector3 direction)
    {
        moveDirection = direction;  // 해당 Vector3 위치로 이동
    }
}


/*
 * File : Movement2D.cs
*/

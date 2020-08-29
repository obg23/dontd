using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDataViewer : MonoBehaviour
{
    private void Awake()
    {
        OffPanel();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            OffPanel();
        }
    }

    public void OnPanel()
    {
        // 타워 정보 Panel On
        gameObject.SetActive(true);
    }

    public void OffPanel()
    {
        gameObject.SetActive(false);
    }
}

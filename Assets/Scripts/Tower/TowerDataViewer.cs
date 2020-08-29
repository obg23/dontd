using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TowerDataViewer : MonoBehaviour
{
    [SerializeField]
    private Image               imageTower;
    [SerializeField]
    private TextMeshProUGUI     textDamage;

    [SerializeField]
    private TextMeshProUGUI     textRate;

    [SerializeField]
    private TextMeshProUGUI     textRange;

    [SerializeField]
    private TextMeshProUGUI     textLevel;

    private TowerWeapon         currentTower;

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

    public void OnPanel(Transform towerWeapon)
    {
        // 출력해야하는 타워 정보를 받아와서 저장
        currentTower = towerWeapon.GetComponent<TowerWeapon>();

        // 타워 정보 Panel On
        gameObject.SetActive(true);

        // 타워 정보를 갱신
        UpdateTowerData();

    }

    public void OffPanel()
    {
        gameObject.SetActive(false);
    }

    private void UpdateTowerData(){

        textDamage.text = "Damage : " + currentTower.Damage;
        textRange.text  = "Rate : " + currentTower.Rate;
        textRange.text  = "Range : " + currentTower.Range;
        textRange.text  = "Level : " + currentTower.Level;

    }
}

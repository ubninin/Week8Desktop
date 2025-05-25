using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    [SerializeField] private Button button;
    private TowerSpawner towerSpawner;
    private ShovelController shovelController;  // 추가

    public void Init(TowerSpawner spawner, ShovelController shovel)
    {
        towerSpawner = spawner;
        shovelController = shovel;  // 할당
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() =>
        {
            towerSpawner.ReadyToSpawnTower();

            // 삽 장착 상태 켜기
            shovelController.EquipShovel();
        });
    }
}
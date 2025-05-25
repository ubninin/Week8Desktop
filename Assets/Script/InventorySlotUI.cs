using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    [SerializeField] private Button button;
    private TowerSpawner towerSpawner;
    private ShovelController shovelController;  // �߰�

    public void Init(TowerSpawner spawner, ShovelController shovel)
    {
        towerSpawner = spawner;
        shovelController = shovel;  // �Ҵ�
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() =>
        {
            towerSpawner.ReadyToSpawnTower();

            // �� ���� ���� �ѱ�
            shovelController.EquipShovel();
        });
    }
}
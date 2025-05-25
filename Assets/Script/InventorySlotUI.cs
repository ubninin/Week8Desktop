using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    [SerializeField] private Button button;
    private TowerSpawner towerSpawner;

    public void Init(TowerSpawner spawner)
    {
        towerSpawner = spawner;
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => towerSpawner.ReadyToSpawnTower());
    }
}

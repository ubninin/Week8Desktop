using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    [SerializeField] private Button button;
    private TowerSpawner towerSpawner;
    private ShovelController shovelController;
    private PlayerHP playerHP;  // 추가

    public void Init(TowerSpawner spawner, ShovelController shovel, PlayerHP hp)
    {
        towerSpawner = spawner;
        shovelController = shovel;
        playerHP = hp;  // 할당

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() =>
        {
            towerSpawner.ReadyToSpawnTower();

            // 삽 장착
            shovelController.EquipShovel();

            // 체력 1 회복
            playerHP.Heal(1f);
        });
    }
}

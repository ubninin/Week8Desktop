using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    [SerializeField] private Button button;
    private TowerSpawner towerSpawner;
    private ShovelController shovelController;
    private PlayerHP playerHP;  // �߰�

    public void Init(TowerSpawner spawner, ShovelController shovel, PlayerHP hp)
    {
        towerSpawner = spawner;
        shovelController = shovel;
        playerHP = hp;  // �Ҵ�

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() =>
        {
            towerSpawner.ReadyToSpawnTower();

            // �� ����
            shovelController.EquipShovel();

            // ü�� 1 ȸ��
            playerHP.Heal(1f);
        });
    }
}

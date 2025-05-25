using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    [SerializeField] private Button button;
    private TowerSpawner towerSpawner;
    private ShovelAttack shovelAttack;
    private PlayerHP playerHP;  // �߰�

    public void Init(TowerSpawner spawner, ShovelAttack shovel, PlayerHP hp)
    {
        towerSpawner = spawner;
        shovelAttack = shovel;
        playerHP = hp;  // �Ҵ�

        button.onClick.RemoveAllListeners();
        //��ư ������ �� ���۵�
        button.onClick.AddListener(() =>
        {
            towerSpawner.ReadyToSpawnTower();

            // �� ����
            shovelAttack.EquipShovel(true);

            // ü�� 1 ȸ��
            playerHP.Heal(1f);
        });
    }
}

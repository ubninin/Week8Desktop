using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    [SerializeField] private Button button;
    private TowerSpawner towerSpawner;
    private ShovelAttack shovelAttack;
    private PlayerHP playerHP;  // 추가

    public void Init(TowerSpawner spawner, ShovelAttack shovel, PlayerHP hp)
    {
        towerSpawner = spawner;
        shovelAttack = shovel;
        playerHP = hp;  // 할당

        button.onClick.RemoveAllListeners();
        //버튼 눌렀을 때 동작들
        button.onClick.AddListener(() =>
        {
            towerSpawner.ReadyToSpawnTower();

            // 삽 장착
            shovelAttack.EquipShovel(true);

            // 체력 1 회복
            playerHP.Heal(1f);
        });
    }
}

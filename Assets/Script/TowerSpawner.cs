//using Mono.Cecil;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject towerPrefab;
    [SerializeField] private int towerBuildPlanks = 1;
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private PlayerPlanks playerPlanks;
    [SerializeField] private InventoryUI inventoryUI;
    private bool isOnTowerButton = false;

    // �÷��̾�� �浹 üũ�� Layer ���� (�÷��̾� ���̾� ����)
    [SerializeField] private LayerMask playerLayerMask;
    public void ReadyToSpawnTower()
    {

        if (towerBuildPlanks > playerPlanks.CurrentPlanks)
        {
       

            return;
        }
        isOnTowerButton = true;
        
        //followTowerClone = Instantiate(towerTemplate[towerType].followTowerPrefab);
        //StartCoroutine("OnTowerCancelSystem");
    }
    public void SpawnTower(Transform tileTransform)
    {
        if (isOnTowerButton == false)
        {
            return;
        }
        Tile tile = tileTransform.GetComponent<Tile>();

        if (tile.IsBuildTower == true)
            return;

        // **�÷��̾ �ִ��� �˻�**
        float checkRadius = 0.4f; // Ÿ�� ũ�⳪ Ÿ�� ũ�⿡ �°� ����
        Collider2D playerCheck = Physics2D.OverlapCircle(tileTransform.position, checkRadius, playerLayerMask);

        if (playerCheck != null)
        {
            Debug.Log("�÷��̾ �־ Ÿ���� ��ġ�� �� �����ϴ�!");
            return; // �÷��̾ ������ ��ġ �� ��
        }
        isOnTowerButton = false;
        tile.IsBuildTower = true;
        playerPlanks.CurrentPlanks -= towerBuildPlanks;

        if (inventoryUI != null)
        {
            inventoryUI.RemoveItem(InventoryItemType.Planks);
        }
        else
        {
            Debug.LogWarning("inventoryUI�� �Ҵ���� �ʾҽ��ϴ�.");
        }
        GameObject newTower = Instantiate(towerPrefab, tileTransform.position, Quaternion.identity);

        Collision tower = newTower.GetComponent<Collision>();
        if (tower != null)
        {
            tower.SetTile(tile);
        }
        Obstacle obstacle = newTower.GetComponent<Obstacle>();
        if (obstacle != null)
        {
            obstacle.SetTile(tile);
        }
    }

    // ����׿����� �� �信�� �˻� ���� �׷��ֱ�
    private void OnDrawGizmosSelected()
    {
        if (towerPrefab != null)
        {
            Gizmos.color = Color.red;
            // Ÿ���� ��ġ�� ��ġ�� �������� �ݰ� ǥ�� (���� �ʿ�)
            // ���� Ÿ�� ��ġ�� ���� �� �� ������ �� �κ��� ���� ����
        }
    }
}

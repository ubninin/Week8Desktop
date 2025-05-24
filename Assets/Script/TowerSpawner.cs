using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject towerPrefab;

    public void SpawnTower(Transform tileTransform)
    {
        Tile tile = tileTransform.GetComponent<Tile>();

        // �̹� Ÿ���� ������ �Ǽ� �� ��
        if (tile.IsBuildTower)
        {
            return;
        }

        // Ÿ�� �Ǽ� ǥ��
        tile.IsBuildTower = true;

        // Ÿ�� ����
        GameObject newTower = Instantiate(towerPrefab, tileTransform.position, Quaternion.identity);

        // ?? �� �κ��� �ٽ�
        Collision tower = newTower.GetComponent<Collision>();
        if (tower != null)
        {
            tower.SetTile(tile); // ������ Ÿ������ Ÿ�� ���� ����
        }
    }
}

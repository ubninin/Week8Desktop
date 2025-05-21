using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject towerPrefab;

    public void SpawnTower(Transform tileTransform)
    {
        Tile tile = tileTransform.GetComponent<Tile>();

        // Ÿ�� �Ǽ� ���� ���� Ȯ��
        // 1. ���� Ÿ���� ��ġ�� �̹� Ÿ���� �Ǽ��Ǿ� ������ Ÿ�� �Ǽ� X
        if (tile.IsBuildTower == true)
        {
            return;
        }

        // Ÿ���� �Ǽ��Ǿ� �������� ����
        tile.IsBuildTower = true;

        // ������ Ÿ���� ��ġ�� Ÿ�� �Ǽ� (�θ� �������� ����)
        GameObject newTower = Instantiate(towerPrefab, tileTransform.position, Quaternion.identity);
        // newTower.transform.SetParent(gridTransform); // �� ���� �����߽��ϴ�.
    }
}

using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject towerPrefab;

    // �÷��̾�� �浹 üũ�� Layer ���� (�÷��̾� ���̾� ����)
    [SerializeField] private LayerMask playerLayerMask;

    public void SpawnTower(Transform tileTransform)
    {
        Tile tile = tileTransform.GetComponent<Tile>();

        if (tile.IsBuildTower)
            return;

        // **�÷��̾ �ִ��� �˻�**
        float checkRadius = 0.4f; // Ÿ�� ũ�⳪ Ÿ�� ũ�⿡ �°� ����
        Collider2D playerCheck = Physics2D.OverlapCircle(tileTransform.position, checkRadius, playerLayerMask);

        if (playerCheck != null)
        {
            Debug.Log("�÷��̾ �־ Ÿ���� ��ġ�� �� �����ϴ�!");
            return; // �÷��̾ ������ ��ġ �� ��
        }

        tile.IsBuildTower = true;

        GameObject newTower = Instantiate(towerPrefab, tileTransform.position, Quaternion.identity);

        Collision tower = newTower.GetComponent<Collision>();
        if (tower != null)
        {
            tower.SetTile(tile);
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

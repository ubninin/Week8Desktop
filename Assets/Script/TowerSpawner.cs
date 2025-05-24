using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject towerPrefab;

    public void SpawnTower(Transform tileTransform)
    {
        Tile tile = tileTransform.GetComponent<Tile>();

        // 이미 타워가 있으면 건설 안 함
        if (tile.IsBuildTower)
        {
            return;
        }

        // 타워 건설 표시
        tile.IsBuildTower = true;

        // 타워 생성
        GameObject newTower = Instantiate(towerPrefab, tileTransform.position, Quaternion.identity);

        // ?? 이 부분이 핵심
        Collision tower = newTower.GetComponent<Collision>();
        if (tower != null)
        {
            tower.SetTile(tile); // 생성된 타워에게 타일 정보 전달
        }
    }
}

using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject towerPrefab;

    // 플레이어와 충돌 체크할 Layer 설정 (플레이어 레이어 포함)
    [SerializeField] private LayerMask playerLayerMask;

    public void SpawnTower(Transform tileTransform)
    {
        Tile tile = tileTransform.GetComponent<Tile>();

        if (tile.IsBuildTower)
            return;

        // **플레이어가 있는지 검사**
        float checkRadius = 0.4f; // 타워 크기나 타일 크기에 맞게 조절
        Collider2D playerCheck = Physics2D.OverlapCircle(tileTransform.position, checkRadius, playerLayerMask);

        if (playerCheck != null)
        {
            Debug.Log("플레이어가 있어서 타워를 설치할 수 없습니다!");
            return; // 플레이어가 있으면 설치 안 함
        }

        tile.IsBuildTower = true;

        GameObject newTower = Instantiate(towerPrefab, tileTransform.position, Quaternion.identity);

        Collision tower = newTower.GetComponent<Collision>();
        if (tower != null)
        {
            tower.SetTile(tile);
        }
    }

    // 디버그용으로 씬 뷰에서 검사 범위 그려주기
    private void OnDrawGizmosSelected()
    {
        if (towerPrefab != null)
        {
            Gizmos.color = Color.red;
            // 타워가 설치될 위치를 기준으로 반경 표시 (조절 필요)
            // 만약 타워 위치를 직접 알 수 없으면 이 부분은 생략 가능
        }
    }
}

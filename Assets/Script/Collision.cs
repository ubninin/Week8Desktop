using UnityEngine;

public class Collision : MonoBehaviour
{
    private Tile tile; // 타워가 위치한 타일 참조

    // 타워 생성 시 호출하여 타일 정보 저장
    public void SetTile(Tile tile)
    {
        this.tile = tile;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("monster die");

            if (tile != null)
            {
                tile.IsBuildTower = false; // 타일에 타워 없음 표시
            }

            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.OnDie();
            }

            Destroy(gameObject); // 타워 제거
        }
    }
}

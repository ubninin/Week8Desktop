using UnityEngine;

public class Collision : MonoBehaviour
{
    private Tile tile; // 타워가 위치한 타일 참조

    // 타워 생성 시 호출하여 타일 정보 저장
    public void SetTile(Tile tile)
    {
        this.tile = tile;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("monster die");

            if (tile != null)
            {
                tile.IsBuildTower = false; // 타일에 타워 없음 표시
            }

            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.OnDie();
            }

            Destroy(gameObject); // 타워 제거
        }
    }
}

using UnityEngine;

public class Collision : MonoBehaviour
{
    private Tile tile; // Ÿ���� ��ġ�� Ÿ�� ����

    // Ÿ�� ���� �� ȣ���Ͽ� Ÿ�� ���� ����
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
                tile.IsBuildTower = false; // Ÿ�Ͽ� Ÿ�� ���� ǥ��
            }

            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.OnDie();
            }

            Destroy(gameObject); // Ÿ�� ����
        }
    }
}

using UnityEngine;

public class Collision : MonoBehaviour
{
    private Tile tile; // Ÿ���� ��ġ�� Ÿ�� ����

    // Ÿ�� ���� �� ȣ���Ͽ� Ÿ�� ���� ����
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
                tile.IsBuildTower = false; // Ÿ�Ͽ� Ÿ�� ���� ǥ��
            }

            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.OnDie();
            }

            Destroy(gameObject); // Ÿ�� ����
        }
    }
}

using UnityEngine;

public class Collision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("monster die");
            // �� ������Ʈ�� �浹�� ���
            collision.gameObject.GetComponent<Enemy>().OnDie();
            Destroy(gameObject); // �ڽ��� ������Ʈ ����
        }
    }
}

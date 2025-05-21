using UnityEngine;

public class Collision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("monster die");
            // 적 오브젝트와 충돌한 경우
            collision.gameObject.GetComponent<Enemy>().OnDie();
            Destroy(gameObject); // 자신의 오브젝트 삭제
        }
    }
}

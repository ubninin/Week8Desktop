using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    private Image imageScreen;

    [SerializeField]
    private float maxHP = 20;  // 최대 체력

    private float currentHP;  // 현재 체력

    public float MaxHP => maxHP;
    public float CurrentHP => currentHP;

    // 하트 UI 이미지들 배열 (인스펙터에서 연결)
    [SerializeField]
    private Image[] heartImages;

    private void Awake()
    {
        currentHP = maxHP;
        //UpdateHeartUI();
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        Debug.Log("한방맞음");

        // 체력 최소값 제한
        if (currentHP < 0)
            currentHP = 0;

        //UpdateHeartUI();

        if (currentHP <= 0)
        {
            Debug.Log("game over(hp)");
            // 게임오버 처리 코드 작성
        }
    }

    // 하트 UI 갱신
    //private void UpdateHeartUI()
    //{
    //    int heartsToShow = Mathf.CeilToInt(currentHP); // 남은 하트 수 (정수로 변환)

    //    for (int i = 0; i < heartImages.Length; i++)
    //    {
    //        if (i < heartsToShow)
    //        {
    //            heartImages[i].enabled = true;  // 하트 보임
    //        }
    //        else
    //        {
    //            heartImages[i].enabled = false; // 하트 숨김
    //        }
    //    }
    //}

    private IEnumerator HitAlphaAnimation()
    {
        Color color = imageScreen.color;
        color.a = 0.4f;
        imageScreen.color = color;

        while (color.a >= 0.0f)
        {
            color.a -= Time.deltaTime;
            imageScreen.color = color;
            yield return null;
        }
    }
}

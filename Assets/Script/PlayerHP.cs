using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    private Image imageScreen;

    [SerializeField]
    private float maxHP = 20;  // �ִ� ü��

    private float currentHP;  // ���� ü��

    public float MaxHP => maxHP;
    public float CurrentHP => currentHP;

    // ��Ʈ UI �̹����� �迭 (�ν����Ϳ��� ����)
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
        Debug.Log("�ѹ����");

        // ü�� �ּҰ� ����
        if (currentHP < 0)
            currentHP = 0;

        //UpdateHeartUI();

        if (currentHP <= 0)
        {
            Debug.Log("game over(hp)");
            // ���ӿ��� ó�� �ڵ� �ۼ�
        }
    }

    // ��Ʈ UI ����
    //private void UpdateHeartUI()
    //{
    //    int heartsToShow = Mathf.CeilToInt(currentHP); // ���� ��Ʈ �� (������ ��ȯ)

    //    for (int i = 0; i < heartImages.Length; i++)
    //    {
    //        if (i < heartsToShow)
    //        {
    //            heartImages[i].enabled = true;  // ��Ʈ ����
    //        }
    //        else
    //        {
    //            heartImages[i].enabled = false; // ��Ʈ ����
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

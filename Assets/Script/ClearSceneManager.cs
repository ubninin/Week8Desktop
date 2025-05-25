using UnityEngine;
using UnityEngine.UI;

public class ClearSceneManager : MonoBehaviour
{
    [SerializeField] private Text recordText;

    void Start()
    {
        string allRecords = PlayerPrefs.GetString("ClearRecords", "�ֱ� ��� ����");
        recordText.text = $"�ֱ� ���\n{allRecords}";
    }
}

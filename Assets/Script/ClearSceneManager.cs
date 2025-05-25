using UnityEngine;
using UnityEngine.UI;

public class ClearSceneManager : MonoBehaviour
{
    [SerializeField] private Text recordText;

    void Start()
    {
        string allRecords = PlayerPrefs.GetString("ClearRecords", "최근 기록 없음");
        recordText.text = $"최근 기록\n{allRecords}";
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI progressText;
    [SerializeField] private Slider progressSlider;
    [SerializeField] private TextMeshProUGUI endingText;
    [SerializeField] private GameTimer gameTimer; // ? Ÿ�̸� ���� �߰�

    public static bool isGameCleared = false;

    void Update()
    {
        int count = 0;

        if (InventorySlot.PbCount > 0) count++;
        if (InventorySlot.BatteryCount > 0) count++;
        if (InventorySlot.TapeCount > 0) count++;
        if (InventorySlot.MtCount > 0) count++;
        if (InventorySlot.PlanksCount > 0) count++;

        float progress = (1 + count) / 6f;
        progressSlider.value = progress;

        progressText.text = $"{count + 1} / 6 collected";

        if (!isGameCleared && count == 5)
        {
            isGameCleared = true;
            endingText.gameObject.SetActive(true);

            gameTimer.StopTimer();  // Ÿ�̸� ����

            if (gameTimer != null)
            {
                string clearTime = gameTimer.GetFormattedTime();

                // ���� ��� �ҷ�����
                string existingRecords = PlayerPrefs.GetString("ClearRecords", "");

                // �� ��� �߰� (�ٹٲ����� ����)
                string updatedRecords = string.IsNullOrEmpty(existingRecords)
                    ? clearTime
                    : existingRecords + "\n" + clearTime;

                // ����
                PlayerPrefs.SetString("ClearRecords", updatedRecords);
                PlayerPrefs.SetString("LastClearTime", clearTime); // �ֽ� ��ϵ� �����ϰ� �ʹٸ� �� �� ����
                PlayerPrefs.Save();
            }

            Time.timeScale = 0f;
            StartCoroutine(DelayToClearScene());
        }

    }
    IEnumerator DelayToClearScene()
    {
        yield return new WaitForSecondsRealtime(2f); // Time.timeScale ������ ���� �ʵ���
        SceneManager.LoadScene("GameClear");
    }


}

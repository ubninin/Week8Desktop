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
    [SerializeField] private GameTimer gameTimer; // ? 타이머 참조 추가

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

            gameTimer.StopTimer();  // 타이머 정지

            if (gameTimer != null)
            {
                string clearTime = gameTimer.GetFormattedTime();

                // 기존 기록 불러오기
                string existingRecords = PlayerPrefs.GetString("ClearRecords", "");

                // 새 기록 추가 (줄바꿈으로 구분)
                string updatedRecords = string.IsNullOrEmpty(existingRecords)
                    ? clearTime
                    : existingRecords + "\n" + clearTime;

                // 저장
                PlayerPrefs.SetString("ClearRecords", updatedRecords);
                PlayerPrefs.SetString("LastClearTime", clearTime); // 최신 기록도 유지하고 싶다면 이 줄 유지
                PlayerPrefs.Save();
            }

            Time.timeScale = 0f;
            StartCoroutine(DelayToClearScene());
        }

    }
    IEnumerator DelayToClearScene()
    {
        yield return new WaitForSecondsRealtime(2f); // Time.timeScale 영향을 받지 않도록
        SceneManager.LoadScene("GameClear");
    }


}

using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private float startTimeInSeconds = 120f;           // 시작 시간 (초)
    [SerializeField] private TextMeshProUGUI timerText;                 // 텍스트로 표시할 타이머
    [SerializeField] private GameObject gameOverPanel;                  // 게임 오버 UI

    private float currentTime;
    private bool isRunning = true;

    void Start()
    {
        currentTime = startTimeInSeconds;

        UpdateTimerText();

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        // 게임 시작 시 시간 흐름 보장
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (!isRunning) return;

        currentTime -= Time.deltaTime;
        currentTime = Mathf.Max(currentTime, 0f);

        UpdateTimerText();

        if (currentTime <= 0f)
        {
            isRunning = false;
            Debug.Log("게임 오버!");

            // 게임 일시정지
            Time.timeScale = 0f;

            // 게임 오버 UI 활성화
            if (gameOverPanel != null)
            {
                gameOverPanel.SetActive(true);
            }
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // 외부 조작 함수
    public void StopTimer() => isRunning = false;
    public void StartTimer() => isRunning = true;
    public void ResetTimer() => currentTime = startTimeInSeconds;
}

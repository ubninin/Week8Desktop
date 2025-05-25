using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private float startTimeInSeconds = 120f;           // ���� �ð� (��)
    [SerializeField] private TextMeshProUGUI timerText;                 // �ؽ�Ʈ�� ǥ���� Ÿ�̸�
    [SerializeField] private GameObject gameOverPanel;                  // ���� ���� UI

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

        // ���� ���� �� �ð� �帧 ����
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
            Debug.Log("���� ����!");

            // ���� �Ͻ�����
            Time.timeScale = 0f;

            // ���� ���� UI Ȱ��ȭ
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

    // �ܺ� ���� �Լ�
    public void StopTimer() => isRunning = false;
    public void StartTimer() => isRunning = true;
    public void ResetTimer() => currentTime = startTimeInSeconds;
}

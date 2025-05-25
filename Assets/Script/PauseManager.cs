using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // 맨 위에 이미 있음
public class PauseManager : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private GameObject pausePanel;               // 일시정지 UI 패널
    [SerializeField] private GameObject exitConfirmPanel;         // 종료 확인 패널
    [SerializeField] private TextMeshProUGUI pauseButtonText;     // 버튼 텍스트
    [SerializeField] private Button exitButton;                   // "Exit" 버튼
    [SerializeField] private Button exitYesButton;                // "Yes" 버튼
    [SerializeField] private Button exitNoButton;                 // "No" 버튼

    private bool isPaused = false;

    private void Start()
    {
        pausePanel.SetActive(false);
        exitConfirmPanel.SetActive(false);

        // 종료 관련 버튼 리스너 연결
        if (exitButton != null) exitButton.onClick.AddListener(OnExitClicked);
        if (exitYesButton != null) exitYesButton.onClick.AddListener(OnExitYesClicked);
        if (exitNoButton != null) exitNoButton.onClick.AddListener(OnExitNoClicked);

        UpdateButtonText();
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
            exitConfirmPanel.SetActive(false); // 종료창도 같이 닫음
        }

        UpdateButtonText();
    }

    private void OnExitClicked()
    {
        // 종료 확인 패널 활성화
        exitConfirmPanel.SetActive(true);
    }

    private void OnExitYesClicked()
    {
        // "예"를 누르면 메인 메뉴 씬으로 이동
        Time.timeScale = 1f; // 씬 전환 전에 Time.timeScale 복구
        SceneManager.LoadScene("MainMenu"); // 씬 이름은 실제 프로젝트에 맞게 수정
    }

    private void OnExitNoClicked()
    {
        // "아니오"를 누르면 일시정지 해제
        TogglePause();
    }


    private void UpdateButtonText()
    {
        if (pauseButtonText != null)
            pauseButtonText.text = isPaused ? "►" : "| |";
    }

    public bool IsPaused() => isPaused;
}

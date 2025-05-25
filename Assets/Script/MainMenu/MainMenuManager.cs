using UnityEngine;
using UnityEngine.SceneManagement; // 씬 전환용
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject tutorialPanel;
    public GameObject exitConfirmPanel;

    [Header("Buttons")]
    public Button startButton;
    public Button tutorialButton;
    public Button tutorialCloseButton;
    public Button exitButton;
    public Button exitYesButton;
    public Button exitNoButton;

    void Start()
    {
        // 초기 UI 세팅
        tutorialPanel.SetActive(false);
        exitConfirmPanel.SetActive(false);

        // 버튼 리스너 등록
        startButton.onClick.AddListener(OnStartClicked);
        tutorialButton.onClick.AddListener(OnTutorialClicked);
        tutorialCloseButton.onClick.AddListener(OnTutorialCloseClicked);
        exitButton.onClick.AddListener(OnExitClicked);
        exitYesButton.onClick.AddListener(OnExitYesClicked);
        exitNoButton.onClick.AddListener(OnExitNoClicked);
    }

    void OnStartClicked()
    {
        // 게임 시작 씬으로 전환 (씬 이름은 프로젝트에 맞게 수정)
        SceneManager.LoadScene("GameScene");
    }

    void OnTutorialClicked()
    {
        tutorialPanel.SetActive(true);
        exitConfirmPanel.SetActive(false);
    }

    void OnTutorialCloseClicked()
    {
        tutorialPanel.SetActive(false);
    }

    void OnExitClicked()
    {
        // 종료 확인 팝업 띄우기
        exitConfirmPanel.SetActive(true);
        tutorialPanel.SetActive(false);
    }

    void OnExitYesClicked()
    {
        // 게임 종료
        Application.Quit();

        // 에디터에서는 종료가 안되니 아래 로그로 확인 가능
        Debug.Log("게임 종료");
    }

    void OnExitNoClicked()
    {
        // 종료 확인 창 닫기
        exitConfirmPanel.SetActive(false);
    }
}

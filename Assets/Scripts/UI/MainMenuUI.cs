using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [Header("Panels")]
    public GameObject minigamePanel;

    void Start()
    {
        minigamePanel.SetActive(false);
    }

    // =========================
    // MAIN BUTTONS
    // =========================

    public void PlayButton()
    {
        minigamePanel.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();

        // Untuk testing di editor
        Debug.Log("Game Closed");
    }

    // =========================
    // CLOSE PANELS
    // =========================

    public void CloseMinigamePanel()
    {
        minigamePanel.SetActive(false);
    }

    // =========================
    // LOAD MINIGAMES
    // =========================

    public void LoadShellJump()
    {
        SceneManager.LoadScene("ShellJump");
    }

    public void LoadEggBeat()
    {
        SceneManager.LoadScene("EggBeat");
    }

    public void LoadFeatherFlap()
    {
        SceneManager.LoadScene("FeatherFlap");
    }

    // =========================
    // LOAD MINIGAMES Tutorial
    // =========================

    public void LoadShellJumpTutorial()
    {
        SceneManager.LoadScene("TutorialShellJump");
    }

    public void LoadEggBeatTutorial()
    {
        SceneManager.LoadScene("TutorialEggBeat");
    }

    public void LoadFeatherFlapTutorial()
    {
        SceneManager.LoadScene("TutorialFeatherFlap");
    }

    public void MainStory()
    {
        SceneManager.LoadScene("MainStory");
    }
}
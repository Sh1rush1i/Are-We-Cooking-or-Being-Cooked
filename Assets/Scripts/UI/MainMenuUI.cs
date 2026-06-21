using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [Header("Panels")]
    public GameObject minigamePanel;
    [SerializeField] private Image overlay; 
    [SerializeField] private float duration = 1f;

    void Start()
    {
        minigamePanel.SetActive(false);
    }

    private void SceneLoadAnim(string sceneName)
    {
        if (overlay == null) return;

       
        overlay.gameObject.SetActive(true);
        overlay.color = new Color(0, 0, 0, 0);

  
        LeanTween.value(gameObject, 0f, 1f, duration)
                 .setEase(LeanTweenType.easeInOutQuad)
                 .setOnUpdate((float val) =>
                 {
                     Color c = overlay.color;
                     c.a = val;
                     overlay.color = c;
                 })
                 .setOnComplete(() =>
                 {

                     SceneManager.LoadScene(sceneName);
                 });
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
        SceneLoadAnim("ShellJump");

    }

    public void LoadEggBeat()
    {
        SceneLoadAnim("EggBeat");
    
    }

    public void LoadFeatherFlap()
    {
        SceneLoadAnim("FeatherFlap");
    }

    // =========================
    // LOAD MINIGAMES Tutorial
    // =========================

    public void LoadShellJumpTutorial()
    {
        SceneLoadAnim("TutorialShellJump");
    }
    public void LoadEggBeatTutorial()
    {
        SceneLoadAnim("TutorialEggBeat");

    }

    public void LoadFeatherFlapTutorial()
    {
        SceneLoadAnim("TutorialFeatherFlap");

    }

    public void MainStory()
    {
        SceneManager.LoadScene("MainStory");
    }
}
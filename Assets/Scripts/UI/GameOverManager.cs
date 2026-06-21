using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject finishPanel;

    [SerializeField] private Image overlay; 
    [SerializeField] private float duration = 1f;

    public GameObject gameObstacle;




    void Start()
    {
        finishPanel.SetActive(false);
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

    public void GameFinished()
    {
        finishPanel.SetActive(true);

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;

        Scene currentScene = SceneManager.GetActiveScene();
        SceneLoadAnim(currentScene.name);

    }

    // Kembali ke Main Menu
    public void ExitToMainMenu()
    {
        Time.timeScale = 1f;

        SceneLoadAnim("MainMenu");

    }

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

    public void LoadScoreScene()
    {
       if (gameObstacle != null)
            gameObstacle.SetActive(true);

        Time.timeScale = 1f;

        // SceneManager.LoadScene("ScoreScreen");
        SceneLoadAnim("ScoreScreen");

    }
}
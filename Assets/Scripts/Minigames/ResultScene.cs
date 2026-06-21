using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ResultScene : MonoBehaviour
{
    [Header("Optional UI Texts")]
    public TMP_Text shellScoreText;
    public TMP_Text eggScoreText;
    public TMP_Text featherScoreText;

    [SerializeField] private Image overlay; 
    [SerializeField] private float duration = 1f;
    //public TMP_Text totalScoreText;

    void Start()
    {
        shellScoreText.text = GameData.ShellJumpScore.ToString();
        eggScoreText.text = GameData.EggBeatsScore.ToString();
        featherScoreText.text = GameData.FeatherFlapsScore.ToString();
        //totalScoreText.text = GameData.TotalScore.ToString();

        Debug.Log("Shell Jump Score: " + GameData.ShellJumpScore);
        Debug.Log("Egg Beats Score: " + GameData.EggBeatsScore);
        Debug.Log("Feather Flaps Score: " + GameData.FeatherFlapsScore);
        Debug.Log("Total Score: " + GameData.TotalScore);
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

    public void backToMenu()
    {
        GameData.ResetSession();
        SceneLoadAnim("MainMenu");
        // Destroy(GameObject.Find("PoseManager"));
        // Destroy(GameObject.Find("Bootstrap"));

    }
}

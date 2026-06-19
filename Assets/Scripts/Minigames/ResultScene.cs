using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ResultScene : MonoBehaviour
{
    [Header("Optional UI Texts")]
    public TMP_Text shellScoreText;
    public TMP_Text eggScoreText;
    public TMP_Text featherScoreText;
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

    public void backToMenu()
    {
        GameData.ResetSession();
        SceneManager.LoadScene("MainMenu");
        Destroy(GameObject.Find("PoseManager"));
        Destroy(GameObject.Find("Bootstrap"));



    }
}

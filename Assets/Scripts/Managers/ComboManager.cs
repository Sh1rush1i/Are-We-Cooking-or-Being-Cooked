using UnityEngine;

public class ComboManager : MonoBehaviour
{
    public static ComboManager Instance;

    [SerializeField] private GameObject comboPrefab;
    [SerializeField] private Transform canvasParent; // existing scene Canvas (Screen Space - Overlay)
    [SerializeField] private float comboResetTime = 2f; // seconds before combo resets to 0

    private int comboCount;
    private float lastScoreTime;
    private ComboEffect activeComboEffect;

    void Awake()
    {
        Instance = this;
    }

    public void OnScore()
    {
        // reset combo if too much time passed since last score
        if (Time.time - lastScoreTime > comboResetTime)
        {
            comboCount = 0;
        }

        comboCount++;
        lastScoreTime = Time.time;

        ShowCombo();
    }

    public void ResetCombo()
    {
        comboCount = 0;
    }

    private void ShowCombo()
    {
        if (activeComboEffect == null)
        {
            GameObject go = Instantiate(comboPrefab, canvasParent);
            activeComboEffect = go.GetComponentInChildren<ComboEffect>();
        }

        activeComboEffect.Show(comboCount);
    }
}
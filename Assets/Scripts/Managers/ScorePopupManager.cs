using UnityEngine;

public class ScorePopupManager : MonoBehaviour
{
    public static ScorePopupManager Instance;

    [SerializeField] private GameObject scorePopupPrefab; 
    [SerializeField] private Transform canvasParent;       
    [SerializeField] private Camera worldCamera;            

    void Awake()
    {
        Instance = this;
    }

    public void Spawn(Vector3 worldPosition)
    {
        Camera cam = worldCamera != null ? worldCamera : Camera.main;

        GameObject go = Instantiate(scorePopupPrefab, canvasParent);
        ScorePopupEffect effect = go.GetComponentInChildren<ScorePopupEffect>();

        if (effect != null)
        {
            effect.Play(worldPosition, cam);
        }
        else
        {
            Debug.LogWarning("ScorePopupManager: prefab has no ScorePopupEffect component.");
        }
    }
}
using UnityEngine;

public class SceneMusicTrigger : MonoBehaviour
{
    [SerializeField] private AudioClip sceneMusic;
    [SerializeField] private bool loop = true;
    [SerializeField] private float fadeDuration = 1f;

    private void Start()
    {
        if (SettingsManager.Instance != null)
        {
            SettingsManager.Instance.PlayMusic(sceneMusic, loop, fadeDuration);
        }
    }
}
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance;

    [Header("Audio")]
    public AudioSource musicSource;

    [Header("Fonts")]
    public TMP_FontAsset normalFont;
    public TMP_FontAsset dyslexiaFont;

    [Header("Dyslexia Toggle")]
    public Toggle dyslexiaToggle;

    // Daun yang digeser
    public RectTransform toggleHandle;

    [SerializeField] private float handleOffX = -130f;
    [SerializeField] private float handleOnX = 15f;

    [SerializeField] private float toggleAnimationDuration = 0.15f;

    private Coroutine toggleAnimation;

    private float musicVolume = 1f;
    private float sfxVolume = 1f;

    private bool dyslexiaEnabled = false;

    [Header("Music Track")]
    private AudioClip currentClip;
    private Coroutine fadeCoroutine;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        LoadSettings();
    }

    private void Start()
    {
        ApplySettings();

        if (dyslexiaToggle != null)
        {
            dyslexiaToggle.SetIsOnWithoutNotify(dyslexiaEnabled);

            dyslexiaToggle.onValueChanged.RemoveListener(ToggleDyslexia);
            dyslexiaToggle.onValueChanged.AddListener(ToggleDyslexia);
        }
    }

    public void PlayMusic(AudioClip newClip, bool loop = true, float fadeDuration = 1f)
{
    if (musicSource == null || newClip == null) return;

    // kalau musiknya sama, gak usah diulang dari awal
    if (currentClip == newClip && musicSource.isPlaying) return;

    currentClip = newClip;

    if (fadeCoroutine != null)
        StopCoroutine(fadeCoroutine);

    fadeCoroutine = StartCoroutine(FadeToNewClip(newClip, loop, fadeDuration));
}

    private IEnumerator FadeToNewClip(AudioClip newClip, bool loop, float duration)
    {
        float startVolume = musicSource.volume;

        // fade out musik lama
        float t = 0f;
        while (t < duration / 2f)
        {
            t += Time.deltaTime;
            musicSource.volume = Mathf.Lerp(startVolume, 0f, t / (duration / 2f));
            yield return null;
        }

        // ganti clip
        musicSource.clip = newClip;
        musicSource.loop = loop;
        musicSource.Play();

        // fade in musik baru, balik ke volume sesuai setting
        t = 0f;
        while (t < duration / 2f)
        {
            t += Time.deltaTime;
            musicSource.volume = Mathf.Lerp(0f, musicVolume, t / (duration / 2f));
            yield return null;
        }

        musicSource.volume = musicVolume;
    }

    // =========================
    // MUSIC
    // =========================

    public void SetMusicVolume(float volume)
    {
        musicVolume = volume;

        if (musicSource != null)
            musicSource.volume = volume;

        PlayerPrefs.SetFloat("MusicVolume", volume);
        PlayerPrefs.Save();
    }

    public float GetMusicVolume()
    {
        return musicVolume;
    }

    // =========================
    // SFX
    // =========================

    public void SetSFXVolume(float volume)
    {
        sfxVolume = volume;

        PlayerPrefs.SetFloat("SFXVolume", volume);
        PlayerPrefs.Save();
    }

    public float GetSFXVolume()
    {
        return sfxVolume;
    }

    // =========================
    // DYSLEXIA
    // =========================

    public void ToggleDyslexia(bool enabled)
    {
        Debug.Log("TOGGLE DIKLIK! Value = " + enabled);

        dyslexiaEnabled = enabled;

        PlayerPrefs.SetInt("DyslexiaMode", enabled ? 1 : 0);
        PlayerPrefs.Save();

        ApplyFontToAllText();
        UpdateToggleVisual();
    }

    public bool IsDyslexiaEnabled()
    {
        return dyslexiaEnabled;
    }

    // =========================
    // APPLY SETTINGS
    // =========================

    private void ApplySettings()
    {
        if (musicSource != null)
            musicSource.volume = musicVolume;

        ApplyFontToAllText();

        if (dyslexiaToggle != null)
            dyslexiaToggle.SetIsOnWithoutNotify(dyslexiaEnabled);

        UpdateToggleVisual();
    }

    private void ApplyFontToAllText()
    {
        TMP_Text[] allTexts = FindObjectsOfType<TMP_Text>(true);

        foreach (TMP_Text text in allTexts)
        {
            text.font = dyslexiaEnabled
                ? dyslexiaFont
                : normalFont;
        }
    }

    private void UpdateToggleVisual()
    {
        Debug.Log("UpdateToggleVisual dipanggil");

        if (toggleHandle == null)
        {
            Debug.Log("toggleHandle NULL");
            return;
        }

        float targetX = dyslexiaEnabled ? handleOnX : handleOffX;

        Debug.Log("Target X = " + targetX);

        Vector2 pos = toggleHandle.anchoredPosition;
        pos.x = targetX;
        toggleHandle.anchoredPosition = pos;
    }

    private IEnumerator AnimateToggle(float targetX)
    {
        Vector2 start = toggleHandle.anchoredPosition;
        Vector2 target = new Vector2(targetX, start.y);

        float time = 0f;

        while (time < toggleAnimationDuration)
        {
            time += Time.deltaTime;

            toggleHandle.anchoredPosition =
                Vector2.Lerp(
                    start,
                    target,
                    time / toggleAnimationDuration
                );

            yield return null;
        }

        toggleHandle.anchoredPosition = target;
    }

    // =========================
    // LOAD SAVE
    // =========================

    private void LoadSettings()
    {
        musicVolume =
            PlayerPrefs.GetFloat("MusicVolume", 1f);

        sfxVolume =
            PlayerPrefs.GetFloat("SFXVolume", 1f);

        dyslexiaEnabled =
            PlayerPrefs.GetInt("DyslexiaMode", 0) == 1;
    }
}
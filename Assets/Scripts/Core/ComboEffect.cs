using UnityEngine;
using TMPro;

public class ComboEffect : MonoBehaviour
{
    [SerializeField] private TMP_Text comboText;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private RectTransform rectTransform;

    [Header("Animation Settings")]
    [SerializeField] private float moveDownDistance = 30f;
    [SerializeField] private float fadeInDuration = 0.15f;
    [SerializeField] private float holdDuration = 0.5f;
    [SerializeField] private float fadeOutDuration = 0.25f;

    private Vector2 startPos;
    private bool initialized;

    void Awake()
    {
        if (!initialized)
        {
            startPos = rectTransform.anchoredPosition;
            initialized = true;
        }
    }

    public void Show(int comboCount)
    {
        if (!initialized) Awake();

        comboText.text = comboCount.ToString();

        // stop any animation currently running on this object
        LeanTween.cancel(gameObject);

        // reset to starting state
        rectTransform.anchoredPosition = startPos;
        canvasGroup.alpha = 0f;

        // fade in while moving down
        LeanTween.alphaCanvas(canvasGroup, 1f, fadeInDuration)
            .setEase(LeanTweenType.easeOutQuad);

        LeanTween.moveY(rectTransform, startPos.y - moveDownDistance, fadeInDuration)
            .setEase(LeanTweenType.easeOutQuad)
            .setOnComplete(() =>
            {
                // hold, then fade out while moving down further
                LeanTween.delayedCall(gameObject, holdDuration, () =>
                {
                    LeanTween.alphaCanvas(canvasGroup, 0f, fadeOutDuration)
                        .setEase(LeanTweenType.easeInQuad);

                    LeanTween.moveY(
                        rectTransform,
                        rectTransform.anchoredPosition.y - moveDownDistance,
                        fadeOutDuration
                    ).setEase(LeanTweenType.easeInQuad);
                });
            });
    }
}
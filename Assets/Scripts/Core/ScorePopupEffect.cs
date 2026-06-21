using UnityEngine;

/// <summary>
/// Attach this to a popup prefab (Image + CanvasGroup + RectTransform).
/// Plays a fade-in-down then fade-out-down animation at a given world position, then destroys itself.
/// Completely independent from the Combo counter system.
/// </summary>
public class ScorePopupEffect : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private RectTransform rectTransform;

    [Header("Animation Settings")]
    [SerializeField] private float moveDownDistance = 30f;
    [SerializeField] private float fadeInDuration = 0.15f;
    [SerializeField] private float holdDuration = 0.4f;
    [SerializeField] private float fadeOutDuration = 0.25f;

    /// <summary>
    /// Plays the popup at the screen position corresponding to a world position
    /// (e.g. the shell that was just scored on), then destroys this GameObject when finished.
    /// </summary>
    public void Play(Vector3 worldPosition, Camera worldCamera)
    {
        RectTransform canvasRect = canvasGroup.GetComponentInParent<Canvas>()?.transform as RectTransform;

        Vector2 startPos = rectTransform.anchoredPosition;

        if (canvasRect != null && worldCamera != null)
        {
            Vector2 screenPoint = worldCamera.WorldToScreenPoint(worldPosition);

            // Use null camera param here since this assumes a Screen Space - Overlay canvas.
            // If your canvas is Screen Space - Camera, pass that canvas's camera instead of null.
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvasRect,
                screenPoint,
                null,
                out startPos
            );
        }

        rectTransform.anchoredPosition = startPos;
        canvasGroup.alpha = 0f;

        LeanTween.alphaCanvas(canvasGroup, 1f, fadeInDuration)
            .setEase(LeanTweenType.easeOutQuad);

        LeanTween.moveY(rectTransform, startPos.y - moveDownDistance, fadeInDuration)
            .setEase(LeanTweenType.easeOutQuad)
            .setOnComplete(() =>
            {
                LeanTween.delayedCall(gameObject, holdDuration, () =>
                {
                    LeanTween.alphaCanvas(canvasGroup, 0f, fadeOutDuration)
                        .setEase(LeanTweenType.easeInQuad);

                    LeanTween.moveY(
                        rectTransform,
                        rectTransform.anchoredPosition.y - moveDownDistance,
                        fadeOutDuration
                    ).setEase(LeanTweenType.easeInQuad)
                    .setOnComplete(() => Destroy(gameObject));
                });
            });
    }
}

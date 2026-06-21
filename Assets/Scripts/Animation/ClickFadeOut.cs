using UnityEngine;
using UnityEngine.UI;

public class ClickFadeOut : MonoBehaviour
{
    [SerializeField] private Image overlay; // UI overlay hitam/transparan
    [SerializeField] private float duration = 1f;

    // Fungsi umum buat fade out overlay
    public void FadeOut()
    {
        if (overlay == null) return;

        overlay.gameObject.SetActive(true);

        LeanTween.value(gameObject, overlay.color.a, 0f, duration)
                 .setEase(LeanTweenType.easeInOutQuad)
                 .setOnUpdate((float val) =>
                 {
                     Color c = overlay.color;
                     c.a = val;
                     overlay.color = c;
                 })
                 .setOnComplete(() =>
                 {
                     overlay.gameObject.SetActive(false); // matikan setelah fade
                 });
    }

    // Kalau object ini diklik (non-UI)
    private void OnMouseDown()
    {
        FadeOut();
    }
}

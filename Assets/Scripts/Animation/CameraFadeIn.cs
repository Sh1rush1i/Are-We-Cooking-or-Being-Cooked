using UnityEngine;
using UnityEngine.UI;

public class CameraFadeIn : MonoBehaviour
{
    public Image fadeOverlay; 
    public float duration = 1.5f;

    void Start()
    {
       
        fadeOverlay.color = new Color(0, 0, 0, 1);

     
        LeanTween.value(gameObject, 1f, 0f, duration)
                 .setEase(LeanTweenType.easeInOutQuad)
                 .setOnUpdate((float val) =>
                 {
                     fadeOverlay.color = new Color(0, 0, 0, val);
                 })
                 .setOnComplete(() =>
                 {
                    
                     fadeOverlay.gameObject.SetActive(false);
                 });
    }
}

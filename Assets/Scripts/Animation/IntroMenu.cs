using UnityEngine;

public class IntroMenu : MonoBehaviour
{
    void Start()
    
   {
        
        transform.localScale = Vector3.zero;

     
        LeanTween.scale(gameObject, Vector3.one * 1.15f, 0.8f)
                 .setEase(LeanTweenType.easeInOutQuad)
                 .setOnComplete(() =>
                 {
                     
                     LeanTween.scale(gameObject, Vector3.one, 0.5f)
                              .setEase(LeanTweenType.easeInOutQuad);
                 });
    }
}

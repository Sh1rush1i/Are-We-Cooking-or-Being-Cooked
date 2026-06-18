using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Events;

public class VideoEndEvents : MonoBehaviour
{
    [SerializeField] private UnityEvent onVideoEnd;

    private VideoPlayer videoPlayer;

    private void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached += HandleVideoEnd;
        }
    }

    private void HandleVideoEnd(VideoPlayer vp)
    {
   
        onVideoEnd?.Invoke();
        Debug.Log("Video selesai Å® semua event dijalankan!");
    }
}

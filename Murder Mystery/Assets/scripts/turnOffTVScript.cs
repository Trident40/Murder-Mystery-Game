using UnityEngine;
using UnityEngine.Video;

public class turnOffTVScript : MonoBehaviour
{
    public GameObject screen;
    public VideoPlayer videoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        screen.SetActive(false);
        videoPlayer.Pause();
    }
    void OnMouseDown() {
        screen.SetActive(!screen.activeSelf);
        if (videoPlayer.isPlaying)
            videoPlayer.Pause();
        else
            videoPlayer.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

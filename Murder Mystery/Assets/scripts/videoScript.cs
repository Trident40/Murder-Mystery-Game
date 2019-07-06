using UnityEngine;
using UnityEngine.Video;

public class videoScript : MonoBehaviour
{
    public VideoPlayer video;
    public VideoClip[] videos;

    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        video.clip = videos[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown() {
        if (++index >= videos.Length)
            index = 0;
        video.clip = videos[index];
    }
}

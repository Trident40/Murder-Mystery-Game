using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyScript : MonoBehaviour
{
    public Color onClick;
    private Color normal;
    void OnMouseDown() {
        GetComponent<AudioSource>().Play();
        pianoScript.played += (GetComponent<AudioSource>().clip.name);
    }
    void Start() {
        normal = GetComponent<MeshRenderer>().materials[0].color;
    }
    // Update is called once per frame
    void Update()
    {
        GetComponent<MeshRenderer>().materials[0].color = (GetComponent<AudioSource>().isPlaying) ? onClick: normal;
    }
}

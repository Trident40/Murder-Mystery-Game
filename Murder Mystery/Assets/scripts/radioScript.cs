using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Audio;

public class radioScript : MonoBehaviour {
    public float [] stationNums;
    public AudioClip[] stationClips;
    public Text stationEntry;
    private int index;
    private AudioSource audioSource;
    // Use this for initialization
    void Start() {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        index = 0;
        stationEntry.text = "";
    }
    void OnMouseDown() {
        if (++index >= stationNums.Length)
            index = 0;
        stationEntry.text = System.Math.Round(stationNums[index], 1).ToString();
        audioSource.clip = stationClips[index];
        audioSource.Play();
    }
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class pianoScript : MonoBehaviour
{
    public GameObject keyParent;
    public bool inverse;
    public string combo;
    public static string played;
    public GameObject unveil;
    public List<AudioClip> sounds;
    public List<GameObject> keys;
    public AudioMixerGroup mainMixer;
    private SortedList<float, GameObject> keyDict;
    private Vector3 unveilOriginalPosition;
    //private float rainbowTestB;
    //public Color rainbowTest;
    void Start()
    {
        unveilOriginalPosition = unveil.transform.position;
        played = "";
        //rainbowTestB = rainbowTest.b;
        keys = new List<GameObject>();
        int children = keyParent.transform.childCount;

        for (int i = 0; i < children; i++) { 
            keys.Add(keyParent.transform.GetChild(i).gameObject);
        }
        keyDict = new SortedList<float, GameObject>();
        int index = 0;
        float pitchLevel = 1.25f;
        foreach(GameObject key in keys) {
            keyDict.Add(inverse ? -key.transform.position.x*10 : key.transform.position.x*10, key);
        }
        foreach (GameObject key in keyDict.Values) {

            //Debug.Log(rainbowTestB);
            //key.GetComponent<MeshRenderer>().materials[0].color = new Color(rainbowTest.r, rainbowTest.g, rainbowTestB-=0.016f);
            AudioSource source = key.AddComponent<AudioSource>();
            source.clip = sounds[index++];
            source.outputAudioMixerGroup = mainMixer;
            source.pitch = pitchLevel;
            if (index >= sounds.Count) {
                pitchLevel += 0.25f;
                index = 0;
            }
        }
    }
    void Update()
    {
        if (played.Length >= combo.Length) {
            if (played.Substring(played.Length - combo.Length) == combo) {
                unveil.transform.position = transform.position;
                Destroy(gameObject,1.8f);
                unveil.SetActive(true);
            }
        }
    }
}

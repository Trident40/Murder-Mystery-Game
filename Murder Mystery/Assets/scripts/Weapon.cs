using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
[System.Serializable]
public class Weapon : MonoBehaviour
{
    private AudioSource source;
    private float startShot;
    public GameObject muzzle;
    public float shootOffset;

    void Start()
    {
        source = GetComponent<AudioSource>();
        startShot = Time.time;
    }
    public bool fire()
    {
        if (Time.time - startShot >= shootOffset) {
            //muzzle.SetActive(true);
            source.Play();
            startShot = Time.time;
            return true;
        }
        return false;
    }
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class pauseMenu : MonoBehaviour
{
    public cameraScript mainCam;
    public GameObject minimap;
    public Slider minimapSizeSlider;
    public AudioMixer mainMixer;
    public Text elapsedTimeText;
    void Start() {
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(false);
    }
    void Update() {
        if ( Input.GetKeyDown("p") ) {
            if (transform.GetChild(0).gameObject.activeSelf) {
                Cursor.lockState = CursorLockMode.Locked;
                GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>().enabled = true;
                mainCam.enabled = true;
                for (int i = 0; i < transform.childCount; i++)
                    transform.GetChild(i).gameObject.SetActive(false);
            }
            else {
                Cursor.lockState = CursorLockMode.None;
                GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>().enabled = false;
                mainCam.enabled = false;
                for (int i = 0; i < transform.childCount; i++)
                    transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
    public void ToggleMinimap() {
        minimap.SetActive(!minimap.activeSelf);
        minimapSizeSlider.gameObject.SetActive(!minimapSizeSlider.gameObject.activeSelf);
    }
    public void changeElapsedTimeTextSize(float value) {
        elapsedTimeText.fontSize = (int) value;
    }
    public void changeMinimapSize(float value) {
        minimap.GetComponent<RectTransform>().localScale = new Vector3(value, value, 1f);
    }
    public void changeSensitivity(float value) {
        mainCam.sensitivity = value;
    }
    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void changeVolume(float value) {
        if (value <= 0) {
            mainMixer.SetFloat("volume", value);
        }
    }
}

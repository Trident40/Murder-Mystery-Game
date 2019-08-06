using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
    private Slider slider;
    private Text text;

    public SceneController(Slider slider, Text text) {
        this.slider = slider;
        this.text = text;
    }

    public void LoadLevel(int n) {
        SceneManager.LoadScene(n);
    }
    IEnumerator LoadAsynchronously(int n) {
        AsyncOperation operation = SceneManager.LoadSceneAsync(n);
        while (!operation.isDone) {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;
            text.text = progress * 100f + "%";
            yield return null;
        }
    }
    public void goToNextScene() {
        int current = SceneManager.GetActiveScene().buildIndex;
        if (current + 1 < SceneManager.sceneCountInBuildSettings)
            LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void goToPreviousScene() {
        int current = SceneManager.GetActiveScene().buildIndex;
        if (current > 0)
            LoadLevel(SceneManager.GetActiveScene().buildIndex - 1);
    }
}

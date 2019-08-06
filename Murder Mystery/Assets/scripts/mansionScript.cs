using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class mansionScript : MonoBehaviour
{
    public Text progressText;
    public Slider progressSlider;
    public GameObject player;
    public RawImage whiteBG;

    void Start() {
        whiteBG.gameObject.SetActive(false);
        progressText.gameObject.SetActive(false);
        progressSlider.gameObject.SetActive(false);
    }
    void OnCollisionEnter(Collision collision) {
        if (collision.collider.gameObject.Equals(player.gameObject)) {
            progressText.gameObject.SetActive(true);
            progressSlider.gameObject.SetActive(true);
            goToNextScene();
        }
    }
    public void LoadLevel(int n) {
        StartCoroutine(LoadAsynchronously(n));
    }
    public IEnumerator LoadAsynchronously(int n) {
        whiteBG.gameObject.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(n);
        while (!operation.isDone) {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            progressSlider.value = progress;
            progressText.text = progress * 100f + "%";
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

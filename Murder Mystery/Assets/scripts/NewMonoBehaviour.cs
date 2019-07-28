using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour {
    public static void changeSceneTo(int n) {
        SceneManager.LoadScene(n);
    }
    public static void goToNextScene() {
        int current = SceneManager.GetActiveScene().buildIndex;
        if (current + 1 < SceneManager.sceneCount)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public static void goToPreviousScene() {
        int current = SceneManager.GetActiveScene().buildIndex;
        if (current > 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class PageRoute : MonoBehaviour {
    // Menu Route
    public void Menu() {
        SceneManager.LoadScene("Menu");
    }

    // Exit Route
    public void Exit() {
        Application.Quit();
    }

    // Newton 1 Route
    public void Newton1(string Newton1) {
        SceneManager.LoadScene("Newton 1");
    }

    // Newton 2 Route
    public void Newton2(string Newton2) {
        SceneManager.LoadScene("Newton 2");
    }

    // Newton 3 Route
    public void Newton3(string Newton3) {
        SceneManager.LoadScene("Newton 3");
    }
}

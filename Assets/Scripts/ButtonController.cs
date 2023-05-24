using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour {
    public Button button; // Button yang ingin diklik setelah 3 detik
    private bool pointerOnButton = false;
    private float pointerTimer = 0.0f;

    private void Update() {
        if (pointerOnButton) {
            pointerTimer += Time.deltaTime;

            if (pointerTimer >= 3.0f) {
                ClickButton();
                pointerOnButton = false;
                pointerTimer = 0.0f;
            }
        }
    }

    public void OnPointerEnter() {
        pointerOnButton = true;
    }

    public void OnPointerExit() {
        pointerOnButton = false;
        pointerTimer = 0.0f;
    }

    private void ClickButton() {
        button.onClick.Invoke();
    }
}

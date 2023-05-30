using UnityEngine;

public class RocketStartController : MonoBehaviour {
    public GameObject RocketPrefab;
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
        RocketController rocketController = RocketPrefab.GetComponent<RocketController>();
        if (rocketController != null) {
            rocketController.RocketClicked();
        }
    }
}

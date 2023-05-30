using UnityEngine;

public class BoxCarStartController : MonoBehaviour {
    public GameObject boxCarPrefab;
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
        BoxCarController boxCarController = boxCarPrefab.GetComponent<BoxCarController>();
        if (boxCarController != null) {
            boxCarController.MoveBoxCar();
        }
    }
}

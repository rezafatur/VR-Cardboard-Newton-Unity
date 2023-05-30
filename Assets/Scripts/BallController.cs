using UnityEngine;

public class BallController : MonoBehaviour {
    public GameObject ball;
    public Rigidbody rb;
    public GameObject canvas1;
    public GameObject canvas2;
    public float moveSpeed = 10f;
    private bool clicked = false;
    private bool pointerOnBall = false;
    private float pointerTimer = 0.0f;

    void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        if (pointerOnBall) {
            pointerTimer += Time.deltaTime;

            if (pointerTimer >= 3.0f) {
                MoveBall();
                pointerOnBall = false;
                pointerTimer = 0.0f;
            }
        }
    }

    public void OnPointerEnter() {
        pointerOnBall = true;
    }

    public void OnPointerExit() {
        pointerOnBall = false;
        pointerTimer = 0.0f;
    }

    public void MoveBall() {
        if (!clicked) {
            clicked = true;
            rb.AddForce(new Vector3(1f, 0f, 0f) * moveSpeed, ForceMode.Impulse);
            OnBallClick();
        }
    }

    public void OnBallClick() {
        canvas1.SetActive(false);
        canvas2.SetActive(true);
    }
}

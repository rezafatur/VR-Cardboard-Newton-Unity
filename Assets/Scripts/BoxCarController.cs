using System.Collections;
using UnityEngine;

public class BoxCarController : MonoBehaviour {
    public GameObject boxcar;
    public Rigidbody rb;
    public GameObject canvas1;
    public GameObject canvas2;
    public float force = 10f;
    private float currentSpeed = 0f;
    private float acceleration = 0f;
    private bool clicked = false;
    private bool pointerOnBoxCar = false;
    private float pointerTimer = 0.0f;

    void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        if (pointerOnBoxCar) {
            pointerTimer += Time.deltaTime;

            if (pointerTimer >= 3.0f) {
                MoveBoxCar();
                pointerOnBoxCar = false;
                pointerTimer = 0.0f;
            }
        }
    }

    public void OnPointerEnter() {
        pointerOnBoxCar = true;
    }

    public void OnPointerExit() {
        pointerOnBoxCar = false;
        pointerTimer = 0.0f;
    }

    public void MoveBoxCar() {
        if (!clicked) {
            clicked = true;
            float mass = rb.mass;
            acceleration = force / mass;
            currentSpeed = 0f;
            StartCoroutine(IncreaseSpeed());
            OnBoxCarClick();
        }
    }

    private IEnumerator IncreaseSpeed() {
        while (true) {
            currentSpeed += acceleration * Time.deltaTime;

            if (currentSpeed >= acceleration) {
                currentSpeed = acceleration;
            }
            float movement = -currentSpeed * Time.deltaTime;
            transform.Translate(new Vector3(0f, 0f, -movement));

            if (transform.position.x <= -25f) {
                StopBoxCar();
                break;
            }
            yield return null;
        }
    }

    public void StopBoxCar() {
        StopAllCoroutines();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    public void OnBoxCarClick() {
        canvas1.SetActive(false);
        canvas2.SetActive(true);
    }
}

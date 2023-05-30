using System.Collections;
using UnityEngine;

public class RocketController : MonoBehaviour {
    public GameObject boxcar;
    public Rigidbody rb;
    private bool activate;
    private bool pointerOnRocket = false;
    private float pointerTimer = 0.0f;
    public int force = 100;
    public ParticleSystem fireParticleSystem;
    public ParticleSystem smokeParticleSystem;
    public GameObject canvas1;
    public GameObject canvas2;
    public GameObject canvas3;
    public GameObject canvas4;
    public GameObject canvas5;
    public GameObject canvas6;
    public GameObject canvas7;

    void Awake() {
        rb = GetComponent<Rigidbody>();
        StopParticleSystems();
    }

    private void Update() {
        if (pointerOnRocket) {
            pointerTimer += Time.deltaTime;

            if (pointerTimer >= 3.0f) {
                RocketClicked();
                pointerOnRocket = false;
                pointerTimer = 0.0f;
            }
        }
    }

    public void OnPointerEnter() {
        pointerOnRocket = true;
    }

    public void OnPointerExit() {
        pointerOnRocket = false;
        pointerTimer = 0.0f;
    }

    public void RocketClicked() {
        OnRocketClick();
        ActivateCanvas2();
        LaunchRocket();
        PlayParticleSystems();
        StartCoroutine(ActivateCanvas3());
    }

    private void LaunchRocket() {
        StartCoroutine(ActivateRocket());
    }

    private IEnumerator ActivateRocket() {
        yield return new WaitForSeconds(3f);
        activate = true;
    }

    private void FixedUpdate() {
        if (activate) {
            rb.AddForce(Vector3.up * Time.deltaTime * force, ForceMode.Acceleration);
        }
    }

    private void StopParticleSystems() {
        fireParticleSystem.Stop();
        smokeParticleSystem.Stop();
    }

    private void PlayParticleSystems() {
        fireParticleSystem.Play();
        smokeParticleSystem.Play();
    }

    public void OnRocketClick() {
        canvas6.SetActive(false);
        canvas7.SetActive(true);
    }

    public void ActivateCanvas2() {
        canvas1.SetActive(false);
        canvas2.SetActive(true);
    }

    private IEnumerator ActivateCanvas3() {
        yield return new WaitForSeconds(1f);
        canvas2.SetActive(false);
        canvas3.SetActive(true);
        StartCoroutine(ActivateCanvas4());
    }

    private IEnumerator ActivateCanvas4() {
        yield return new WaitForSeconds(1f);
        canvas3.SetActive(false);
        canvas4.SetActive(true);
        StartCoroutine(ActivateCanvas5());
    }

    private IEnumerator ActivateCanvas5() {
        yield return new WaitForSeconds(1f);
        canvas4.SetActive(false);
        canvas5.SetActive(true);
        StartCoroutine(ActivateCanvas1());
    }

    private IEnumerator ActivateCanvas1() {
        yield return new WaitForSeconds(10f);
        canvas5.SetActive(false);
        canvas1.SetActive(true);
    }
}

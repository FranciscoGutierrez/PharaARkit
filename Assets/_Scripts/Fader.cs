using UnityEngine;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fader : MonoBehaviour {
    public CanvasGroup csGrp;
    public float time = 1.0f;

    void Awake() {
        csGrp = GetComponent<CanvasGroup>();
    }

    void Start() {
        StartCoroutine("FadeIn");
    }
    /*
    void OnDisable()
    {
        StartCoroutine("FadeIn");
    }
    */
    void OnEnable()
    {
        StartCoroutine("FadeIn");
    }


    IEnumerator FadeIn() {
        csGrp.alpha = 0;
        while (csGrp.alpha < 1) {
            csGrp.alpha += Time.deltaTime / this.time;
            yield return null;
        }
    }
}
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TargetManager : MonoBehaviour {

    private int recInput = 0;
    private int detInput = 0;
	// Use this for initialization
	void Start () {
		
	}
    // Update is called once per frame
    void Update() {
        if (Input.GetKeyUp(KeyCode.JoystickButton0) == true) {
            StateManager sm = TrackerManager.Instance.GetStateManager();
            IEnumerable<TrackableBehaviour> activeTrackables = sm.GetActiveTrackableBehaviours();
            foreach (TrackableBehaviour tb in activeTrackables) {
                RectTransform calorie = tb.gameObject.transform.Find("CalorieIntake").GetComponent<RectTransform>();
                Animator anim = tb.gameObject.transform.Find("CalorieIntake").GetComponent<Animator>();
                if (this.detInput == 0) {
                    //calorie.localPosition = new Vector3(0.85f, 0.15f, 0.5f);
                    this.transform.GetComponent<AudioSource>().Play();
                    anim.SetTrigger("GoFront");
                }

                if (this.detInput == 1) {
                    //calorie.localPosition = new Vector3(0.85f, -0.15f, 0.5f);
                    this.transform.GetComponent<AudioSource>().Play();
                    anim.SetTrigger("GoBack");
                    this.detInput = -1;
                }
            }
            this.detInput += 1;
        }
        if (Input.GetKeyUp(KeyCode.JoystickButton3) == true) {
            StateManager sm = TrackerManager.Instance.GetStateManager();
            IEnumerable<TrackableBehaviour> activeTrackables = sm.GetActiveTrackableBehaviours();
            foreach (TrackableBehaviour tb in activeTrackables) {
                RectTransform calorie = tb.gameObject.transform.Find("Alternatives").GetComponent<RectTransform>();
                Animator anim = tb.gameObject.transform.Find("Alternatives").GetComponent<Animator>();
                Animator maylike = tb.gameObject.transform.Find("YouMayLike").GetComponent<Animator>();
                //if (this.recInput == 0) {
                    //tb.gameObject.transform.Find("Recommendations").gameObject.SetActive(true);
                    //tb.gameObject.transform.Find("Alternatives").gameObject.SetActive(true);
                    //tb.gameObject.transform.Find("YouMayLike").gameObject.SetActive(true);
               // }

                if (this.recInput == 0) {
                    //calorie.localPosition = new Vector3(-0.85f, 0.15f, 0.5f); 
                    this.transform.GetComponent<AudioSource>().Play();
                    anim.SetTrigger("ShowAlternatives");
                }

                if (this.recInput == 1) {
                    //calorie.localPosition = new Vector3(-0.85f, -0.15f, 0.5f);
                    this.transform.GetComponent<AudioSource>().Play();
                    anim.SetTrigger("HideAlternatives");
                    maylike.SetTrigger("MayLikeFront");
                }

                if (this.recInput == 2)
                {
                    this.transform.GetComponent<AudioSource>().Play();
                    maylike.SetTrigger("MayLikeBack");
                    this.recInput = -1;
                }

                //if (this.recInput == 3)
                //{
                 //   tb.gameObject.transform.Find("Recommendations").gameObject.SetActive(false);
                  //  tb.gameObject.transform.Find("Alternatives").gameObject.SetActive(false);
                   // tb.gameObject.transform.Find("YouMayLike").gameObject.SetActive(false);
                //}
            }
            this.recInput += 1;
        }

    }

    public void showDetails() {
        StateManager sm = TrackerManager.Instance.GetStateManager();
        IEnumerable<TrackableBehaviour> activeTrackables = sm.GetActiveTrackableBehaviours();
        foreach (TrackableBehaviour tb in activeTrackables) {
            Debug.Log("The Trackable is: " + tb.TrackableName);
            RectTransform calorie = tb.gameObject.transform.Find("CalorieIntake").GetComponent<RectTransform>();
            Animator anim = tb.gameObject.transform.Find("CalorieIntake").GetComponent<Animator>();
            anim.SetTrigger("GoFront");
            //calorie.localPosition = new Vector3(0.85f, 0.15f, 0.5f);
            //calorie.Translate(Vector3.back * Time.deltaTime);
        }
    }

    public void showOverview() {
        StateManager sm = TrackerManager.Instance.GetStateManager();
        IEnumerable<TrackableBehaviour> activeTrackables = sm.GetActiveTrackableBehaviours();
        foreach (TrackableBehaviour tb in activeTrackables)
        {
            Debug.Log("The Trackable is: " + tb.TrackableName);
            RectTransform calorie = tb.gameObject.transform.Find("CalorieIntake").GetComponent<RectTransform>();
            Animator anim = tb.gameObject.transform.Find("CalorieIntake").GetComponent<Animator>();
            anim.SetTrigger("GoBack");
            //calorie.localPosition = new Vector3(0.85f, -0.15f, 0.5f);
            //calorie.Translate(Vector3.back * Time.deltaTime);
        }
    }

    public void showAlternatives()
    {
        StateManager sm = TrackerManager.Instance.GetStateManager();
        IEnumerable<TrackableBehaviour> activeTrackables = sm.GetActiveTrackableBehaviours();
        foreach (TrackableBehaviour tb in activeTrackables)
        {
            Debug.Log("The Trackable is: " + tb.TrackableName);
            RectTransform calorie = tb.gameObject.transform.Find("Alternatives").GetComponent<RectTransform>();
            Animator anim = tb.gameObject.transform.Find("Alternatives").GetComponent<Animator>();
            Animator maylike = tb.gameObject.transform.Find("YouMayLike").GetComponent<Animator>();
            maylike.SetTrigger("MayLikeBack");
            anim.SetTrigger("ShowAlternatives");
            //calorie.localPosition = new Vector3(-0.85f, 0.15f, 0.5f);
            //calorie.Translate(Vector3.back * Time.deltaTime);
        }
    }

    public void showSimilar()
    {
        StateManager sm = TrackerManager.Instance.GetStateManager();
        IEnumerable<TrackableBehaviour> activeTrackables = sm.GetActiveTrackableBehaviours();
        foreach (TrackableBehaviour tb in activeTrackables)
        {
            Debug.Log("The Trackable is: " + tb.TrackableName);
            RectTransform calorie = tb.gameObject.transform.Find("Alternatives").GetComponent<RectTransform>();
            Animator anim = tb.gameObject.transform.Find("Alternatives").GetComponent<Animator>();
            Animator maylike = tb.gameObject.transform.Find("YouMayLike").GetComponent<Animator>();
            maylike.SetTrigger("MayLikeBack");
            anim.SetTrigger("HideAlternatives");
            //calorie.localPosition = new Vector3(-0.85f, -0.15f, 0.5f);
            //calorie.Translate(Vector3.back * Time.deltaTime);
        }
    }

    public void mayLike()
    {
        StateManager sm = TrackerManager.Instance.GetStateManager();
        IEnumerable<TrackableBehaviour> activeTrackables = sm.GetActiveTrackableBehaviours();
        foreach (TrackableBehaviour tb in activeTrackables)
        {
            Debug.Log("The Trackable is: " + tb.TrackableName);
            RectTransform calorie = tb.gameObject.transform.Find("Alternatives").GetComponent<RectTransform>();
            Animator anim = tb.gameObject.transform.Find("Alternatives").GetComponent<Animator>();
            Animator maylike = tb.gameObject.transform.Find("YouMayLike").GetComponent<Animator>();
            anim.SetTrigger("HideAlternatives");
            maylike.SetTrigger("MayLikeFront");
            //calorie.localPosition = new Vector3(-0.85f, -0.15f, 0.5f);
            //calorie.Translate(Vector3.back * Time.deltaTime);
        }
    }

    public void showRecommendations()
    {
        StateManager sm = TrackerManager.Instance.GetStateManager();
        IEnumerable<TrackableBehaviour> activeTrackables = sm.GetActiveTrackableBehaviours();
        foreach (TrackableBehaviour tb in activeTrackables){
            tb.gameObject.transform.Find("Recommendations").gameObject.SetActive(true);
            tb.gameObject.transform.Find("Alternatives").gameObject.SetActive(true);
            tb.gameObject.transform.Find("YouMayLike").gameObject.SetActive(true);
            //calorie.Translate(Vector3.back * Time.deltaTime);
        }
    }
}
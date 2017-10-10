using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using Vuforia;

public class InitAugmentation : MonoBehaviour, ITrackableEventHandler
{
    public GameObject CalorieIntake;
    public GameObject MayLike;
    public GameObject Alternatives;
    public GameObject Breakdown;
    public GameObject MyPlate;
    private bool expanded_grid = false;
    private bool expanded_list = false;
    private bool expanded_pie = false;
    private bool show = false;
    private TrackableBehaviour mTrackableBehaviour;

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            this.show = true;
            string log = "{\"name\" : \"" + this.name + "\",\"time\": \"" + DateTime.Now.ToString("hh:mm:ss:ffffff") + "\"}";
            StartCoroutine(Post("https://api.mlab.com/api/1/databases/pharalens/collections/logs?apiKey=XKRgrZ9vfWYBXQWnmFTpKJXlWE9ffN3m", log));
        }
        else
        {
            this.show = false;
        }
    }

    IEnumerator Post(string url, string bodyJsonString)
    {
        var request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(bodyJsonString);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.Send();
    }

    // Use this for initialization
    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (this.show)
        {
            if (Input.GetKeyUp(KeyCode.JoystickButton0))
            {
                this.CalorieIntake.GetComponent<AudioSource>().Play();
                this.CalorieIntake.GetComponent<Animator>().SetTrigger("GoFront");
                this.Breakdown.GetComponent<Animator>().SetTrigger("GoFront");
                this.MyPlate.GetComponent<Animator>().SetTrigger("GoFront");
                string layout = "stackfront";
                string log = "{\"name\" : \"" + layout + "\",\"time\": \"" + DateTime.Now.ToString("hh:mm:ss:ffffff") + "\"}";
                StartCoroutine(Post("https://api.mlab.com/api/1/databases/pharalens/collections/logs?apiKey=XKRgrZ9vfWYBXQWnmFTpKJXlWE9ffN3m", log));
            }

            if (Input.GetKeyUp(KeyCode.JoystickButton1))
            {
                if (!this.expanded_list)
                {
                    this.CalorieIntake.GetComponent<AudioSource>().Play();
                    this.CalorieIntake.GetComponent<Animator>().SetTrigger("List");
                    this.MayLike.GetComponent<Animator>().SetTrigger("List");
                    this.Alternatives.GetComponent<Animator>().SetTrigger("List");
                    this.Breakdown.GetComponent<Animator>().SetTrigger("List");
                    this.MyPlate.GetComponent<Animator>().SetTrigger("List");
                    this.expanded_list = true;
                    string layout = "list";
                    string log = "{\"name\" : \"" + layout + "\",\"time\": \"" + DateTime.Now.ToString("hh:mm:ss:ffffff") + "\"}";
                    StartCoroutine(Post("https://api.mlab.com/api/1/databases/pharalens/collections/logs?apiKey=XKRgrZ9vfWYBXQWnmFTpKJXlWE9ffN3m", log));
                }
                else
                {
                    this.CalorieIntake.GetComponent<AudioSource>().Play();
                    this.CalorieIntake.GetComponent<Animator>().SetTrigger("Unlist");
                    this.MayLike.GetComponent<Animator>().SetTrigger("Unlist");
                    this.Alternatives.GetComponent<Animator>().SetTrigger("Unlist");
                    this.Breakdown.GetComponent<Animator>().SetTrigger("Unlist");
                    this.MyPlate.GetComponent<Animator>().SetTrigger("Unlist");
                    this.expanded_list = false;
                    this.expanded_grid = false;
                    this.expanded_pie = false;
                    string layout = "unlist";
                    string log = "{\"name\" : \"" + layout + "\",\"time\": \"" + DateTime.Now.ToString("hh:mm:ss:ffffff") + "\"}";
                    StartCoroutine(Post("https://api.mlab.com/api/1/databases/pharalens/collections/logs?apiKey=XKRgrZ9vfWYBXQWnmFTpKJXlWE9ffN3m", log));

                }
            }

            if (Input.GetKeyUp(KeyCode.JoystickButton3))
            {
                this.MayLike.GetComponent<Animator>().SetTrigger("GoFront");
                this.Alternatives.GetComponent<Animator>().SetTrigger("GoFront");
                this.CalorieIntake.GetComponent<AudioSource>().Play();
                string layout = "frontstack";
                string log = "{\"name\" : \"" + layout + "\",\"time\": \"" + DateTime.Now.ToString("hh:mm:ss:ffffff") + "\"}";
                StartCoroutine(Post("https://api.mlab.com/api/1/databases/pharalens/collections/logs?apiKey=XKRgrZ9vfWYBXQWnmFTpKJXlWE9ffN3m", log));
            }

            if (Input.GetKeyUp(KeyCode.JoystickButton14)) // Expand!
            {
                if (!this.expanded_grid)
                {
                    this.CalorieIntake.GetComponent<Animator>().SetTrigger("Expand");
                    this.MayLike.GetComponent<Animator>().SetTrigger("Expand");
                    this.Alternatives.GetComponent<Animator>().SetTrigger("Expand");
                    this.Breakdown.GetComponent<Animator>().SetTrigger("Expand");
                    this.MyPlate.GetComponent<Animator>().SetTrigger("Expand");
                    this.CalorieIntake.GetComponent<AudioSource>().Play();
                    this.expanded_grid = true;
                    string layout = "expandgrid";
                    string log = "{\"name\" : \"" + layout + "\",\"time\": \"" + DateTime.Now.ToString("hh:mm:ss:ffffff") + "\"}";
                    StartCoroutine(Post("https://api.mlab.com/api/1/databases/pharalens/collections/logs?apiKey=XKRgrZ9vfWYBXQWnmFTpKJXlWE9ffN3m", log));
                }
                else
                {
                    this.CalorieIntake.GetComponent<Animator>().SetTrigger("Compress");
                    this.MayLike.GetComponent<Animator>().SetTrigger("Compress");
                    this.Alternatives.GetComponent<Animator>().SetTrigger("Compress");
                    this.Breakdown.GetComponent<Animator>().SetTrigger("Compress");
                    this.MyPlate.GetComponent<Animator>().SetTrigger("Compress");
                    this.CalorieIntake.GetComponent<AudioSource>().Play();
                    this.expanded_grid = false;
                    this.expanded_list = false;
                    this.expanded_pie = false;
                    string layout = "compressgrid";
                    string log = "{\"name\" : \"" + layout + "\",\"time\": \"" + DateTime.Now.ToString("hh:mm:ss:ffffff") + "\"}";
                    StartCoroutine(Post("https://api.mlab.com/api/1/databases/pharalens/collections/logs?apiKey=XKRgrZ9vfWYBXQWnmFTpKJXlWE9ffN3m", log));
                }
            }

            if (Input.GetKeyUp(KeyCode.JoystickButton15)) // Expand!
            {
                if (!this.expanded_pie)
                {
                    this.CalorieIntake.GetComponent<Animator>().SetTrigger("Pie");
                    this.MayLike.GetComponent<Animator>().SetTrigger("Pie");
                    this.Alternatives.GetComponent<Animator>().SetTrigger("Pie");
                    this.Breakdown.GetComponent<Animator>().SetTrigger("Pie");
                    this.MyPlate.GetComponent<Animator>().SetTrigger("Pie");
                    this.CalorieIntake.GetComponent<AudioSource>().Play();
                    this.expanded_pie = true;
                    string layout = "pie";
                    string log = "{\"name\" : \"" + layout + "\",\"time\": \"" + DateTime.Now.ToString("hh:mm:ss:ffffff") + "\"}";
                    StartCoroutine(Post("https://api.mlab.com/api/1/databases/pharalens/collections/logs?apiKey=XKRgrZ9vfWYBXQWnmFTpKJXlWE9ffN3m", log));
                }
                else
                {
                    this.CalorieIntake.GetComponent<Animator>().SetTrigger("Unpie");
                    this.MayLike.GetComponent<Animator>().SetTrigger("Unpie");
                    this.Alternatives.GetComponent<Animator>().SetTrigger("Unpie");
                    this.Breakdown.GetComponent<Animator>().SetTrigger("Unpie");
                    this.MyPlate.GetComponent<Animator>().SetTrigger("Unpie");
                    this.CalorieIntake.GetComponent<AudioSource>().Play();
                    this.expanded_grid = false;
                    this.expanded_list = false;
                    this.expanded_pie = false;
                    string layout = "unpie";
                    string log = "{\"name\" : \"" + layout + "\",\"time\": \"" + DateTime.Now.ToString("hh:mm:ss:ffffff") + "\"}";
                    StartCoroutine(Post("https://api.mlab.com/api/1/databases/pharalens/collections/logs?apiKey=XKRgrZ9vfWYBXQWnmFTpKJXlWE9ffN3m", log));
                }
            }

        }

    }
}

public class LogMongo
{
    public string logName;
    public string logTime;

    public LogMongo(string name, string time)
    {
        this.logName = name;
        this.logTime = time;
    }

    public string SaveToString()
    {
        return JsonUtility.ToJson(this);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Vuforia;
using System;
using System.Text;

public class AndroidGUI : MonoBehaviour
{

    private bool expand = false;
    private bool list = false;
    private bool pie = false;

    public void suggestions()
    {
        StateManager sm = TrackerManager.Instance.GetStateManager();
        IEnumerable<TrackableBehaviour> activeTrackables = sm.GetActiveTrackableBehaviours();
        foreach (TrackableBehaviour tb in activeTrackables)
        {
            Animator MayLike = tb.gameObject.transform.Find("YouMayLike").GetComponent<Animator>();
            Animator Alternatives = tb.gameObject.transform.Find("Alternatives").GetComponent<Animator>();
            MayLike.SetTrigger("GoFront");
            Alternatives.SetTrigger("GoFront");
            string layout = "stackfront";
            string log = "{\"name\" : \"" + layout + "\",\"time\": \"" + DateTime.Now.ToString("hh:mm:ss:ffffff") + "\"}";
            StartCoroutine(Post("https://api.mlab.com/api/1/databases/pharalens/collections/logs?apiKey=XKRgrZ9vfWYBXQWnmFTpKJXlWE9ffN3m", log));
        }
    }

    public void productInfo()
    {
        StateManager sm = TrackerManager.Instance.GetStateManager();
        IEnumerable<TrackableBehaviour> activeTrackables = sm.GetActiveTrackableBehaviours();
        foreach (TrackableBehaviour tb in activeTrackables)
        {
            Animator Intake = tb.gameObject.transform.Find("CalorieIntake").GetComponent<Animator>();
            Animator BreakDown = tb.gameObject.transform.Find("CalorieBreakdown").GetComponent<Animator>();
            Animator MyPlate = tb.gameObject.transform.Find("MyPlate").GetComponent<Animator>();
            Intake.SetTrigger("GoFront");
            BreakDown.SetTrigger("GoFront");
            MyPlate.SetTrigger("GoFront");
            string layout = "stackfront";
            string log = "{\"name\" : \"" + layout + "\",\"time\": \"" + DateTime.Now.ToString("hh:mm:ss:ffffff") + "\"}";
            StartCoroutine(Post("https://api.mlab.com/api/1/databases/pharalens/collections/logs?apiKey=XKRgrZ9vfWYBXQWnmFTpKJXlWE9ffN3m", log));
        }
    }

    public void showList()
    {
        StateManager sm = TrackerManager.Instance.GetStateManager();
        IEnumerable<TrackableBehaviour> activeTrackables = sm.GetActiveTrackableBehaviours();
        foreach (TrackableBehaviour tb in activeTrackables)
        {
            Animator MayLike = tb.gameObject.transform.Find("YouMayLike").GetComponent<Animator>();
            Animator Alternatives = tb.gameObject.transform.Find("Alternatives").GetComponent<Animator>();
            Animator Intake = tb.gameObject.transform.Find("CalorieIntake").GetComponent<Animator>();
            Animator BreakDown = tb.gameObject.transform.Find("CalorieBreakdown").GetComponent<Animator>();
            Animator MyPlate = tb.gameObject.transform.Find("MyPlate").GetComponent<Animator>();
            if (!this.list)
            {
                MayLike.SetTrigger("List");
                Alternatives.SetTrigger("List");
                Intake.SetTrigger("List");
                BreakDown.SetTrigger("List");
                MyPlate.SetTrigger("List");
                this.list = true;
                string layout = "list";
                string log = "{\"name\" : \"" + layout + "\",\"time\": \"" + DateTime.Now.ToString("hh:mm:ss:ffffff") + "\"}";
                StartCoroutine(Post("https://api.mlab.com/api/1/databases/pharalens/collections/logs?apiKey=XKRgrZ9vfWYBXQWnmFTpKJXlWE9ffN3m", log));
            }
            else
            {
                MayLike.SetTrigger("Unlist");
                Alternatives.SetTrigger("Unlist");
                Intake.SetTrigger("Unlist");
                BreakDown.SetTrigger("Unlist");
                MyPlate.SetTrigger("Unlist");
                this.expand = false;
                this.list = false;
                this.pie = false;
                string layout = "unlist";
                string log = "{\"name\" : \"" + layout + "\",\"time\": \"" + DateTime.Now.ToString("hh:mm:ss:ffffff") + "\"}";
                StartCoroutine(Post("https://api.mlab.com/api/1/databases/pharalens/collections/logs?apiKey=XKRgrZ9vfWYBXQWnmFTpKJXlWE9ffN3m", log));
            }
        }
    }

    public void showGrid()
    {
        StateManager sm = TrackerManager.Instance.GetStateManager();
        IEnumerable<TrackableBehaviour> activeTrackables = sm.GetActiveTrackableBehaviours();
        foreach (TrackableBehaviour tb in activeTrackables)
        {
            Animator MayLike = tb.gameObject.transform.Find("YouMayLike").GetComponent<Animator>();
            Animator Alternatives = tb.gameObject.transform.Find("Alternatives").GetComponent<Animator>();
            Animator Intake = tb.gameObject.transform.Find("CalorieIntake").GetComponent<Animator>();
            Animator BreakDown = tb.gameObject.transform.Find("CalorieBreakdown").GetComponent<Animator>();
            Animator MyPlate = tb.gameObject.transform.Find("MyPlate").GetComponent<Animator>();
            if (!this.expand)
            {
                MayLike.SetTrigger("Expand");
                Alternatives.SetTrigger("Expand");
                Intake.SetTrigger("Expand");
                BreakDown.SetTrigger("Expand");
                MyPlate.SetTrigger("Expand");
                this.expand = true;
                string layout = "expandgrid";
                string log = "{\"name\" : \"" + layout + "\",\"time\": \"" + DateTime.Now.ToString("hh:mm:ss:ffffff") + "\"}";
                StartCoroutine(Post("https://api.mlab.com/api/1/databases/pharalens/collections/logs?apiKey=XKRgrZ9vfWYBXQWnmFTpKJXlWE9ffN3m", log));
            }
            else
            {
                MayLike.SetTrigger("Compress");
                Alternatives.SetTrigger("Compress");
                Intake.SetTrigger("Compress");
                BreakDown.SetTrigger("Compress");
                MyPlate.SetTrigger("Compress");
                this.expand = false;
                this.list = false;
                this.pie = false;
                string layout = "compressgrid";
                string log = "{\"name\" : \"" + layout + "\",\"time\": \"" + DateTime.Now.ToString("hh:mm:ss:ffffff") + "\"}";
                StartCoroutine(Post("https://api.mlab.com/api/1/databases/pharalens/collections/logs?apiKey=XKRgrZ9vfWYBXQWnmFTpKJXlWE9ffN3m", log));
            }
        }
    }

    public void showPie()
    {
        StateManager sm = TrackerManager.Instance.GetStateManager();
        IEnumerable<TrackableBehaviour> activeTrackables = sm.GetActiveTrackableBehaviours();
        foreach (TrackableBehaviour tb in activeTrackables)
        {
            Animator MayLike = tb.gameObject.transform.Find("YouMayLike").GetComponent<Animator>();
            Animator Alternatives = tb.gameObject.transform.Find("Alternatives").GetComponent<Animator>();
            Animator Intake = tb.gameObject.transform.Find("CalorieIntake").GetComponent<Animator>();
            Animator BreakDown = tb.gameObject.transform.Find("CalorieBreakdown").GetComponent<Animator>();
            Animator MyPlate = tb.gameObject.transform.Find("MyPlate").GetComponent<Animator>();
            if (!this.pie)
            {
                MayLike.SetTrigger("Pie");
                Alternatives.SetTrigger("Pie");
                Intake.SetTrigger("Pie");
                BreakDown.SetTrigger("Pie");
                MyPlate.SetTrigger("Pie");
                this.pie = true;
                string layout = "pie";
                string log = "{\"name\" : \"" + layout + "\",\"time\": \"" + DateTime.Now.ToString("hh:mm:ss:ffffff") + "\"}";
                StartCoroutine(Post("https://api.mlab.com/api/1/databases/pharalens/collections/logs?apiKey=XKRgrZ9vfWYBXQWnmFTpKJXlWE9ffN3m", log));
            }
            else
            {
                MayLike.SetTrigger("Unpie");
                Alternatives.SetTrigger("Unpie");
                Intake.SetTrigger("Unpie");
                BreakDown.SetTrigger("Unpie");
                MyPlate.SetTrigger("Unpie");
                this.pie = false;
                this.expand = false;
                this.list = false;
                string layout = "unpie";
                string log = "{\"name\" : \"" + layout + "\",\"time\": \"" + DateTime.Now.ToString("hh:mm:ss:ffffff") + "\"}";
                StartCoroutine(Post("https://api.mlab.com/api/1/databases/pharalens/collections/logs?apiKey=XKRgrZ9vfWYBXQWnmFTpKJXlWE9ffN3m", log));
            }
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
}
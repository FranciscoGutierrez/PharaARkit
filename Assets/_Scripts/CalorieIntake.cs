using System.IO;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

using System;

public class CalorieIntake : MonoBehaviour
{
    public Text calories;
    public Text topWeight;
    public Text midWeight;
    public Text botWeight;

    void Start()
    {
        InvokeRepeating("checkProfile", 5.0f, 5.0f);
    }

    void checkProfile()
    {
        double bmr = GetUserProfile.profile.bmr;
        double weight = GetUserProfile.profile.weight;
        this.calories.text  = "Currently you consume " + bmr + "kcal/day";
        this.topWeight.text = (weight + 12d) + " kg";
        this.midWeight.text = weight + " kg";
        this.botWeight.text = (weight - 12d) + " kg";
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using System.Text.RegularExpressions;

public class GetUserProfile : MonoBehaviour {

    public static UserInfo profile; 

	void Start () {
        StartCoroutine(GetRequest());
    }

    IEnumerator GetRequest()
    {

        using (UnityWebRequest request = UnityWebRequest.Get("https://api.mlab.com/api/1/databases/pharalens/collections/users?apiKey=XKRgrZ9vfWYBXQWnmFTpKJXlWE9ffN3m&l=1&s={$natural:-1}"))
        {
            yield return request.Send();
            if (request.isError) // Error
            {
                Debug.Log(request.error);
            }
            else // Success
            {
                string pattern = @"^(\[){1}(.*?)(\]){1}$";
                string json = Regex.Replace(request.downloadHandler.text, pattern, "$2");
                GetUserProfile.profile = JsonUtility.FromJson<UserInfo>(json);
            }
        }
    }
}

[System.Serializable]
public class UserInfo
{
    public string gender;
    public double weight;
    public double bmr;
    public string[] favorites;

    public static UserInfo CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<UserInfo>(jsonString);
    }
}
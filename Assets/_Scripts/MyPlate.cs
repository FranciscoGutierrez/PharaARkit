using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MyPlate : MonoBehaviour
{
    public GameObject veggies;
    public GameObject protein;
    public GameObject fruits;
    public GameObject grains;
    public GameObject water;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("checkBasket", 1.0f, 3.0f);
    }

    void checkBasket()
    {
        StartCoroutine(GetRequest());
    }

    IEnumerator GetRequest()
    {
        using (UnityWebRequest request = UnityWebRequest.Get("https://api.mlab.com/api/1/databases/pharalens/collections/basket?apiKey=XKRgrZ9vfWYBXQWnmFTpKJXlWE9ffN3m&fo=true"))
        {
            yield return request.Send();
            if (request.isError) // Error
            {
                Debug.Log(request.error);
            }
            else // Success
            {
                Basket B = JsonUtility.FromJson<Basket>(request.downloadHandler.text);
                RectTransform veggies = this.veggies.GetComponent<RectTransform>();
                RectTransform fruits  = this.fruits.GetComponent<RectTransform>();
                RectTransform grains  = this.grains.GetComponent<RectTransform>();
                RectTransform protein = this.protein.GetComponent<RectTransform>();
                RectTransform water   = this.water.GetComponent<RectTransform>();

                veggies.offsetMax = new Vector2(veggies.offsetMax.x, B.veggies-100);
                fruits.offsetMax  = new Vector2(fruits.offsetMax.x,  B.fruits-100);
                grains.offsetMax  = new Vector2(grains.offsetMax.x,  B.grains-100);
                protein.offsetMax = new Vector2(protein.offsetMax.x, B.protein-100);
                water.offsetMax   = new Vector2(water.offsetMax.x,   B.water-100);
            }   
        }
    }
}

[System.Serializable]
public class Basket
{
    public int veggies;
    public int protein;
    public int fruits;
    public int grains;
    public int water;

    public static Basket CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<Basket>(jsonString);
    }
}
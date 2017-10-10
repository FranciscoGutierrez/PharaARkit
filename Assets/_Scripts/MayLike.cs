using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

public class MayLike : MonoBehaviour
{

    public GameObject itemPrefab;
    public int itemCount = 3;
    public string productID = "6756733a";
    public string APIkey = "XKRgrZ9vfWYBXQWnmFTpKJXlWE9ffN3m";
    public string query;
    private float duration = 1.0f;
    private System.Random rnd = new System.Random();

    void Start()
    {
        this.productID = this.transform.parent.name;
        //this.productID = "product"; // Temp thing.

        string filePath = "_YouMayLike/" + this.productID;
        string text = Resources.Load<TextAsset>(filePath.Replace(".json", "")).text;
        SimilarProduct SP = JsonUtility.FromJson<SimilarProduct>(text);

        for (int index = 0; index < itemCount; index++)
        {
            SimilarItem item = SP.rs[index];

            GameObject product = Instantiate(itemPrefab) as GameObject;
            product.name = itemPrefab.name + index;
            product.transform.SetParent(gameObject.transform, false);

            RectTransform rectTransform = product.GetComponent<RectTransform>();
            rectTransform.offsetMin = new Vector2(0, 0);
            rectTransform.offsetMax = new Vector2(160, 80);
            rectTransform.localScale = new Vector3(1, 1, 1);
            //rectTransform.rotation = Quaternion.Euler(90, 0, 0);
            if (index == 0) rectTransform.localPosition = new Vector3(0, 12, 0);
            if (index == 1) rectTransform.localPosition = new Vector3(0, 72, 0);
            if (index == 2) rectTransform.localPosition = new Vector3(0, -48, 0);

            Transform image = product.transform.Find("Image");
            Transform name = product.transform.Find("ProductName");

            Sprite sprite = Resources.Load<Sprite>("Images/" + item.id);
            image.GetComponent<Image>().sprite = sprite;

            name.GetComponent<Text>().text = item.name;
        }
    }
}
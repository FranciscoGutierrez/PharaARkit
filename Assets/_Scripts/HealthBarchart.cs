using System.IO;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using UnityEngine.Networking;
using System;
using HoloToolkit.Unity.InputModule;

public class HealthBarchart : MonoBehaviour {

    public Text productTitle;
    public Text productSubtitle;
    public int itemCount = 3;
    public Image fat;
    public Image salt;
    public Image satFat;
    public Image sugars;
    public Image nutriscore;

    private string productID;

    void Start()
    {
        this.productID = this.transform.parent.name;
        string filePath = "ProductJson/" + this.productID;
        string text = Resources.Load<TextAsset>(filePath.Replace(".json", "")).text;
      
        ProductInfo PI = JsonUtility.FromJson<ProductInfo>(String.Join("", text.Split('-')));

        string productName = PI.product.product_name;
        string productSub = PI.product.generic_name;
        string fat = PI.product.nutrient_levels.fat;
        string salt = PI.product.nutrient_levels.salt;
        string satFat = PI.product.nutrient_levels.saturatedfat;
        string sugars = PI.product.nutrient_levels.sugars;
        string n_label = "Nutriscore/nutri_" + PI.product.nutrition_grades_tags[0];

        this.nutriscore.GetComponent<Image>().sprite = Resources.Load<Sprite>(n_label);

        string low = "low";
        string mod = "moderate";
        string hig = "high";

        if (String.Equals(fat, low)) this.fat.rectTransform.sizeDelta = new Vector2(20, 20);
        if (String.Equals(fat, mod)) this.fat.rectTransform.sizeDelta = new Vector2(20, 50);
        if (String.Equals(fat, hig)) this.fat.rectTransform.sizeDelta = new Vector2(20, 80);

        if (String.Equals(salt, low)) this.salt.rectTransform.sizeDelta = new Vector2(20, 20);
        if (String.Equals(salt, mod)) this.salt.rectTransform.sizeDelta = new Vector2(20, 50);
        if (String.Equals(salt, hig)) this.salt.rectTransform.sizeDelta = new Vector2(20, 80);

        if (String.Equals(satFat, low)) this.satFat.rectTransform.sizeDelta = new Vector2(20, 20);
        if (String.Equals(satFat, mod)) this.satFat.rectTransform.sizeDelta = new Vector2(20, 50);
        if (String.Equals(satFat, hig)) this.satFat.rectTransform.sizeDelta = new Vector2(20, 80);

        if (String.Equals(sugars, low)) this.sugars.rectTransform.sizeDelta = new Vector2(20, 20);
        if (String.Equals(sugars, mod)) this.sugars.rectTransform.sizeDelta = new Vector2(20, 50);
        if (String.Equals(sugars, hig)) this.sugars.rectTransform.sizeDelta = new Vector2(20, 80);

        this.productTitle.text = productName;
        this.productSubtitle.text = productSub;

    }

}

[System.Serializable]
public class ProductInfo
{
    public string status;
    public string status_verbose;
    public Product product;

    public static ProductInfo CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<ProductInfo>(jsonString);
    }
}

[System.Serializable]
public class Product
{
    public string product_name;
    public string generic_name;
    public Nutrients nutrient_levels;
    public string[] nutrition_grades_tags;
    public Nutriments nutriments;

    public static Product CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<Product>(jsonString);
    }
}

[System.Serializable]
public class Nutrients
{
    public string saturatedfat;
    public string sugars;
    public string fat;
    public string salt;

    public static Nutrients CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<Nutrients>(jsonString);
    }
}

[System.Serializable]
public class Nutriments
{
    public float carbohydrates_100g;
    public float fat_100g;
    public float proteins_100g;
    public float energy_100g; // Kj convert to KCalories

    public static Nutrients CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<Nutrients>(jsonString);
    }
}


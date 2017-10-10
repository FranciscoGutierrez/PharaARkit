using System.IO;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using UnityEngine.Networking;
using System;

public class CalorieBreakdown : MonoBehaviour
{

    private double calories = 0d;
    public Image carboBar;
    public Image fatBar;
    public Image proteinBar;

    public Text calorieAmount;
    public Text calorieLegend;
    public Text carboText;
    public Text fatText;
    public Text proteinText;
    public Text carboLegend;
    public Text fatLegend;
    public Text proteinLegend;

    public GameObject calorieSquare;

    private string productID;
    private bool ready = false;

    void Start()
    {
        InvokeRepeating("renderCard", 3.0f, 2500.0f);
    }

    void renderCard()
    {
        this.calories = GetUserProfile.profile.bmr;
        this.productID = this.transform.parent.name;
        string filePath = "ProductJson/" + this.productID;
        string text = Resources.Load<TextAsset>(filePath.Replace(".json", "")).text;
        ProductInfo PI = JsonUtility.FromJson<ProductInfo>(String.Join("", text.Split('-')));

        float carbs = PI.product.nutriments.carbohydrates_100g;
        float prots = PI.product.nutriments.proteins_100g;
        float fats = PI.product.nutriments.fat_100g;
        float energy = PI.product.nutriments.energy_100g / 4.184f; // Convert from Kj to Kcal
        string enery_format = ((int)(Math.Round(energy))).ToString();

        int energyPercent = (int)(Math.Round((energy / this.calories) * 100));
        this.calorieAmount.text = enery_format + " cal. (" + energyPercent + "%)";

        // Mid section of the card (Calorie bar).
        this.carboText.text = Decimal.Parse(carbs.ToString("0.00")).ToString() + "g";
        this.fatText.text = Decimal.Parse(fats.ToString("0.00")).ToString() + "g";
        this.proteinText.text = Decimal.Parse(prots.ToString("0.00")).ToString() + "g";

        float total = prots + carbs + fats;
        int carbPercent = (int)(Math.Round((carbs / total) * 100));
        int fatPercent = (int)(Math.Round((fats / total) * 100));
        int protPercent = (int)(Math.Round((prots / total) * 100));

        // Bottom section of the card.
        this.calorieLegend.text = "*Based on a " + this.calories + "\nCalorie Diet";
        this.carboLegend.text = "Carbohydrate (" + carbPercent + "%)";
        this.fatLegend.text = "Fat (" + fatPercent + "%)";
        this.proteinLegend.text = "Protein (" + protPercent + "%)";

        // Adjust the bars!
        this.proteinBar.rectTransform.sizeDelta = new Vector2(20, protPercent);
        this.proteinBar.rectTransform.anchoredPosition = new Vector2(0, 0);

        this.fatBar.rectTransform.sizeDelta = new Vector2(20, fatPercent);
        this.fatBar.rectTransform.anchoredPosition = new Vector2(0, protPercent);

        this.carboBar.rectTransform.sizeDelta = new Vector2(20, carbPercent);
        this.carboBar.rectTransform.anchoredPosition = new Vector2(0, protPercent + fatPercent);

        // Generate calorie squares!
        string grey_sq = "Squares/greysquare";
        string carb_sq = "Squares/carb";
        string fats_sq = "Squares/fat";
        string prot_sq = "Squares/prot";

        int row = 0;
        int col = 0;
        int carbSquare = (int)Math.Round(carbPercent / 10.0);
        int fatSquare = (int)Math.Round(fatPercent / 10.0);
        int protSquare = (int)Math.Round(protPercent / 10.0);

        // Fill the view with squares.

        if (!(calorieSquare.transform.Find("square100") != null))
        {
            for (int index = 1; index <= 100; index++)
            {
                GameObject square = Instantiate(Resources.Load(grey_sq)) as GameObject;
                square.name = "square" + index;
                square.transform.SetParent(calorieSquare.transform, false);
                square.GetComponent<RectTransform>().anchoredPosition = new Vector2(col / 1.2f, row / 1.2f);
                if ((index % 10) == 0)
                {
                    row = row + 10;
                    col = 0;
                }
                else
                {
                    col = col + 10;
                }
            }
        }
        // Change the colors of the squares.

        int total_energy = energyPercent;
        int fat_energy = (int)Math.Round(energyPercent * (fatPercent / 100.0));
        int carb_energy = (int)Math.Round(energyPercent * (carbPercent / 100.0));
        int prot_energy = (int)Math.Round(energyPercent * (protPercent / 100.0));

        for (int index = 1; index <= carb_energy; index++)
        {
            string square1 = "square" + index;
            Sprite sprite = Resources.Load<Sprite>(carb_sq);
            Transform selected = calorieSquare.transform.Find(square1);
            selected.GetComponent<Image>().sprite = sprite;
        }

        for (int index = carb_energy; index <= fat_energy + carb_energy; index++)
        {
            string square1 = "square" + index;
            Sprite sprite = Resources.Load<Sprite>(fats_sq);
            Transform selected = calorieSquare.transform.Find(square1);
            selected.GetComponent<Image>().sprite = sprite;
        }

        for (int index = fat_energy + carb_energy; index <= total_energy; index++)
        {
            string square1 = "square" + index;
            Sprite sprite = Resources.Load<Sprite>(prot_sq);
            Transform selected = calorieSquare.transform.Find(square1);
            selected.GetComponent<Image>().sprite = sprite;
        }
    }

}
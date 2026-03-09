using UnityEngine;
using TMPro;

public class FishInventory : MonoBehaviour
{
    public static FishInventory instance;

    public int fishCount = 0;
    public TextMeshProUGUI fishText;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateUI();
    }

    public void AddFish(int amount)
    {
        fishCount += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (fishText != null)
        {
            fishText.text = "Fish: " + fishCount;
        }
    }
}
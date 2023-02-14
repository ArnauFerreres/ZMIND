using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [Header("HUD Panel Settings")]
    [SerializeField] private TextMeshProUGUI coinsTextCounter;

    int totalCoins = 0;

    public void UpdateTotalCoins()
    {
        totalCoins++;
        coinsTextCounter.text = totalCoins.ToString();
    }
}

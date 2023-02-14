using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ZombieController : MonoBehaviour
{
    [Header("HUD Panel Settings")]
    [SerializeField] private TextMeshProUGUI coinsTextCounter;

    int totalCoins = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateTotalCoins()
    {
        totalCoins++;
        coinsTextCounter.text = totalCoins.ToString();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
            UpdateTotalCoins();
            Destroy(gameObject);
    }

}

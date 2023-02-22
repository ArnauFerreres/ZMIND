using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ZombieController : MonoBehaviour
{
    [Header("HUD Panel Settings")]
    [SerializeField] private TextMeshProUGUI coinsTextCounter;

    [Header("Lifes Settings")]
    public int lifes;
    [HideInInspector] public EnemyManager manager;

    private float speed;

    int totalCoins = 0;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(2f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    public void UpdateTotalCoins()
    {
        totalCoins++;
        coinsTextCounter.text = totalCoins.ToString();
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Projectile")
    //        UpdateTotalCoins();
    //        Destroy(gameObject);
    //}

    private void OnCollisionEnter2D(Collider2D other)
    {
        if (other.tag == "Projectile")
        {
            UpdateTotalCoins();
            //Destroy(other.gameObject);
            GetDamage();
        }
    }

    void GetDamage()
    {
        lifes--;

        if (lifes <= 0)
        {
            Destroy(gameObject);
            manager.CheckEnemies();
        }
    }

}

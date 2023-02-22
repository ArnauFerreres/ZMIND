using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<WaveProperties> waves;
    private int currentEnemy;
    private float rateEnemy;

    public bool randomWaves;

    void Start()
    {
        
    }

    public void CheckEnemies()
    {
        StartCoroutine(CheckEnemiesDelay());
    }

    IEnumerator CheckEnemiesDelay()
    {
        yield return new WaitForSeconds(0.2f);
        bool nextWave = true;
        for (int i = 0; i < waves[0].Enemies.Count; i++)
        {
            if (waves[0].Enemies[i].enemy != null)
            {
                nextWave = false;
                break;
            }
        }

        if (nextWave == true)
        {
            waves.RemoveAt(0);
            rateEnemy = 0;
            currentEnemy = 0;
        }
    }

    void Update()
    {
        if (waves.Count > 0)
        {
            if (currentEnemy < waves[0].Enemies.Count)
            {
                rateEnemy += Time.deltaTime;
                if (rateEnemy > waves[0].Enemies[currentEnemy].spawn)
                {
                    GameObject newEnemy = Instantiate(waves[0].Enemies[currentEnemy].enemy, new Vector2(Random.Range(-2f, 2f), -4.0f), Quaternion.identity);

                    waves[0].Enemies[currentEnemy].enemy = newEnemy;

                    if (newEnemy.GetComponent<ZombieController>() != null)
                    {
                        newEnemy.GetComponent<ZombieController>().manager = this;
                    }
                    //else if (newEnemy.GetComponent<Enemy2>() != null)
                    //{
                    //    newEnemy.GetComponent<Enemy2>().manager = this;
                    //}
                    //else if (newEnemy.GetComponent<Enemy3>() != null)
                    //{
                    //    newEnemy.GetComponent<Enemy3>().manager = this;
                    //}

                    rateEnemy = 0;
                    currentEnemy++;
                }
            }
        }
        else 
        {
            if(randomWaves == true)
            {
                CreateWave();
            }
            else
            {
                print("Fin de partida");
            } 
        }
    }
    private void CreateWave()
    {
        int totalEnemies = Random.Range(10, 20);
        WaveProperties newWaves = new WaveProperties();
        newWaves.Enemies = new List<WaveProperties.EnemyProperties>();
        for (int i = 0; i < totalEnemies; i++)
        {
            //Creo un nuevo enemigo
            WaveProperties.EnemyProperties newEnemy = new WaveProperties.EnemyProperties();

            //genero un spawnTime aleatorio
            float spawnTime = Random.Range(0.5f, 2f);
            if(i == 0) spawnTime = 1;

            //Cojo un enemigo aleatorio
            int randomEnemy = Random.Range(0, 3);
            GameObject getEnemy = Resources.Load<GameObject>("Enemy_" + randomEnemy);

            //Asigno los valores al nuevo enemigo
            newEnemy.spawn = spawnTime;
            newEnemy.enemy = getEnemy;

            //Guardo el enemigo
            newWaves.Enemies.Add(newEnemy);
        }
        //Guardo la oleada
        waves.Add(newWaves);
    }
}

[System.Serializable]
public class WaveProperties
{
    [System.Serializable]
    public class EnemyProperties
    {
        public float spawn;
        public GameObject enemy;

    }

    public List<EnemyProperties> Enemies;
}
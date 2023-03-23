using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance = null;

    [SerializeField] GameObject spawnPoint;
    [SerializeField] GameObject[] enemies;

    [SerializeField] int maxEnemiesOnscreen;
    [SerializeField] int totalEnemies;
    [SerializeField] int enemiesPerSpawn;

    int enemiesOnScreen = 0;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }


    void Spawn()
    {
        if (totalEnemies > 0 && enemiesOnScreen < totalEnemies)
        {
            for (int i = 0; i < totalEnemies; i++)
            {
                if (enemiesOnScreen < maxEnemiesOnscreen)
                {
                    var newEnemy = Instantiate(enemies[0]) as GameObject;
                    newEnemy.transform.position = spawnPoint.transform.position;
                    ++enemiesOnScreen;
                }
            }
        }
    }

    public void RemoveEnemyFromScreen()
    {
        if (enemiesOnScreen > 0) --enemiesOnScreen;
    }
}
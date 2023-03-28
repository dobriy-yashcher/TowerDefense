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

    int enemiesOnScreen;
    int totalEnemiesOnScreen;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        enemiesOnScreen = 0;

        StartCoroutine(Spawn());
    }

    public IEnumerator Spawn()
    {
        if (totalEnemies > 0 && totalEnemies > totalEnemiesOnScreen)
        {    
            if (enemiesOnScreen < maxEnemiesOnscreen)
            {              
                var enemyPrefab = enemies[Random.Range(0, enemies.Length)];

                var instantiatePosition = spawnPoint.transform.position;
                instantiatePosition.z = 90;

                var newEnemy = Instantiate(enemyPrefab);
                newEnemy.transform.position = instantiatePosition;
                DontDestroyOnLoad(newEnemy);

                ++enemiesOnScreen;   
                ++totalEnemiesOnScreen;   
            }           
        }

        yield return new WaitForSeconds(2);
        yield return StartCoroutine(Spawn());
    }

    public void RemoveEnemyFromScreen()
    {
        if (enemiesOnScreen > 0) --enemiesOnScreen;
    }
}

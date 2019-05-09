using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    #region Singleton

    public static EnemyManager instance;
    

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public GameObject[] enemies;
    public bool respawned;
    public enemy Enemy;
    private enemy newEnemy;

    public GameObject spawnPoints;
    private Transform[] arrayOfspawnPoints;
    private int enemyCount = 4;

    private void Start()
    {
        arrayOfspawnPoints = spawnPoints.GetComponentsInChildren<Transform>();
        
    }
    // Update is called once per frame
    void Update()
    {
        if (respawned)
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            
            respawned = false;
        }
        if(enemies.Length < 4)
        {
            enemyCount++;
            System.Random rand = new System.Random();
            int point = rand.Next(0, arrayOfspawnPoints.Length);
            newEnemy = Instantiate(Enemy, arrayOfspawnPoints[point].position, Quaternion.identity);
            newEnemy.name = "Enemy " + enemyCount;            
            
        }
    }

    public void doDamage(GameObject obj)
    {
        Debug.Log(obj.name);
        foreach (var item in enemies)
        {
            if(item.name == obj.name)
            {              
                item.GetComponent<enemy>().Damage(5f);
            }
        }
    }
}

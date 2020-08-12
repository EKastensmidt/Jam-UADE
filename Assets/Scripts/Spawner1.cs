using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner1 : MonoBehaviour
{
    public Object enemy1;

    public bool start = false;
    public float variation = 3;
    float timer = 0;
    float shityCount = 0;

    Score score;

    void Start()
    {
        score = FindObjectOfType<Score>();
    }

    void Update()
    {
        if (!start)
            return;

        timer += Time.deltaTime;

        if (Mathf.FloorToInt(timer) - shityCount*variation > variation)
        {
            shityCount++;
            for (int i = 0; i < Mathf.Sqrt(Mathf.Max(1,Mathf.FloorToInt(timer)/variation))-1; i++)
            {
                InstantiateEnemy(enemy1);
            }
        }
    }

    void InstantiateEnemy(Object enemy)
    {
        GameObject enemyObj = Instantiate(enemy, new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * Random.Range(11, 14), Quaternion.identity) as GameObject;
    }

    public void StartGame()
    {
        start = true;
    }
}

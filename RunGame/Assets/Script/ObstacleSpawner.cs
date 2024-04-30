using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject icerookPrefab, IcespaikesPrefab;

    [SerializeField]
    private float icerockYPos = -3.5f, IcespaikesYPos = -3.5f;

    [SerializeField]
    private float minSpawnWaitTime = 2f, maxSpawnWaitTime = 3.5f;

    private float spawnWaitTime;
    private float startTime; // ゲームの開始時間を保持するための変数

    private int obstacleTypesCount = 3;
    private int obstacleToSpawn;

    private Camera mainCamera;

    private Vector3 obstacleSpawnePos = Vector3.zero;

    private GameObject newObstacle;

    [SerializeField]
    private List<GameObject> icerookPool, IcespaikesPool;

    [SerializeField]
    private int initialObstacleToSpawn = 5;

    private bool increasedSpawnRate = false;

    private void Awake()
    {
        mainCamera = Camera.main;
        startTime = Time.time; // ゲーム開始時刻を記録

        // 障害物のプールを生成する関数の呼び出し
        GenerateObstacles();
    }

    // Update is called once per frame
    void Update()
    {
        ObstacleSpawning();

        // 40秒を過ぎたら生成オブジェクトの数を増やす
        if (!increasedSpawnRate && Time.time - startTime > 40f)
        {
            increasedSpawnRate = true;
            minSpawnWaitTime = 1.5f;
            maxSpawnWaitTime = 2.5f;
        }
    }

    // 障害物のプールを生成する関数
    void GenerateObstacles()
    {
        for (int i = 0; i < 3; i++)
        {
            // 障害物の種類ごとにプールを生成する関数を呼び出す
            SpawneObstacles(i);
        }
    }

    // 障害物の種類ごとにプールを生成する関数
    void SpawneObstacles(int obstacleType)
    {
        switch (obstacleType)
        {
            case 0:
                for (int i = 0; i < initialObstacleToSpawn; i++)
                {
                    // アイスロックのプールを生成
                    newObstacle = Instantiate(icerookPrefab);
                    newObstacle.transform.SetParent(transform);
                    icerookPool.Add(newObstacle);
                    newObstacle.SetActive(false);
                }
                break;

            case 1:
                for (int i = 0; i < initialObstacleToSpawn; i++)
                {
                    // アイススパイクのプールを生成
                    newObstacle = Instantiate(IcespaikesPrefab);
                    newObstacle.transform.SetParent(transform);
                    IcespaikesPool.Add(newObstacle);
                    newObstacle.SetActive(false);
                }
                break;
        }
    }

    // 障害物の生成を行う関数
    void ObstacleSpawning()
    {
        if (Time.time > spawnWaitTime)
        {
            SpawnObstacleGame();
            spawnWaitTime = Time.time + Random.Range(minSpawnWaitTime, maxSpawnWaitTime);
        }
    }

    // ランダムな位置に障害物を生成する関数
    void SpawnObstacleGame()
    {
        obstacleToSpawn = Random.Range(0, obstacleTypesCount);

        obstacleSpawnePos.x = mainCamera.transform.position.x + 20f;

        switch (obstacleToSpawn)
        {
            case 0:
                for (int i = 0; i < icerookPool.Count; i++)
                {
                    if (!icerookPool[i].activeInHierarchy)
                    {
                        // アクティブでないプール内のアイスロックを取得し、位置を設定してアクティブにする
                        icerookPool[i].SetActive(true);
                        obstacleSpawnePos.y = icerockYPos;
                        newObstacle = icerookPool[i];
                        break;
                    }
                }
                break;

            case 1:
                for (int i = 0; i < IcespaikesPool.Count; i++)
                {
                    if (!IcespaikesPool[i].activeInHierarchy)
                    {
                        // アクティブでないプール内のアイススパイクを取得し、位置を設定してアクティブにする
                        IcespaikesPool[i].SetActive(true);
                        obstacleSpawnePos.y = IcespaikesYPos;
                        newObstacle = IcespaikesPool[i];
                        break;
                    }
                }
                break;
        }

        newObstacle.transform.position = obstacleSpawnePos;
    }
}

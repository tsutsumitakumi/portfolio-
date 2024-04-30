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
    private float startTime; // �Q�[���̊J�n���Ԃ�ێ����邽�߂̕ϐ�

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
        startTime = Time.time; // �Q�[���J�n�������L�^

        // ��Q���̃v�[���𐶐�����֐��̌Ăяo��
        GenerateObstacles();
    }

    // Update is called once per frame
    void Update()
    {
        ObstacleSpawning();

        // 40�b���߂����琶���I�u�W�F�N�g�̐��𑝂₷
        if (!increasedSpawnRate && Time.time - startTime > 40f)
        {
            increasedSpawnRate = true;
            minSpawnWaitTime = 1.5f;
            maxSpawnWaitTime = 2.5f;
        }
    }

    // ��Q���̃v�[���𐶐�����֐�
    void GenerateObstacles()
    {
        for (int i = 0; i < 3; i++)
        {
            // ��Q���̎�ނ��ƂɃv�[���𐶐�����֐����Ăяo��
            SpawneObstacles(i);
        }
    }

    // ��Q���̎�ނ��ƂɃv�[���𐶐�����֐�
    void SpawneObstacles(int obstacleType)
    {
        switch (obstacleType)
        {
            case 0:
                for (int i = 0; i < initialObstacleToSpawn; i++)
                {
                    // �A�C�X���b�N�̃v�[���𐶐�
                    newObstacle = Instantiate(icerookPrefab);
                    newObstacle.transform.SetParent(transform);
                    icerookPool.Add(newObstacle);
                    newObstacle.SetActive(false);
                }
                break;

            case 1:
                for (int i = 0; i < initialObstacleToSpawn; i++)
                {
                    // �A�C�X�X�p�C�N�̃v�[���𐶐�
                    newObstacle = Instantiate(IcespaikesPrefab);
                    newObstacle.transform.SetParent(transform);
                    IcespaikesPool.Add(newObstacle);
                    newObstacle.SetActive(false);
                }
                break;
        }
    }

    // ��Q���̐������s���֐�
    void ObstacleSpawning()
    {
        if (Time.time > spawnWaitTime)
        {
            SpawnObstacleGame();
            spawnWaitTime = Time.time + Random.Range(minSpawnWaitTime, maxSpawnWaitTime);
        }
    }

    // �����_���Ȉʒu�ɏ�Q���𐶐�����֐�
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
                        // �A�N�e�B�u�łȂ��v�[�����̃A�C�X���b�N���擾���A�ʒu��ݒ肵�ăA�N�e�B�u�ɂ���
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
                        // �A�N�e�B�u�łȂ��v�[�����̃A�C�X�X�p�C�N���擾���A�ʒu��ݒ肵�ăA�N�e�B�u�ɂ���
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

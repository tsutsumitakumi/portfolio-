using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField]
    private GameObject grondPlefab;

    [SerializeField]
    private float groundToSpawn = 10;

    private List<GameObject> groundPool = new List<GameObject>();

    [SerializeField]
    private float ground_Y_Pos = 0f;

    [SerializeField]
    private float ground_X_Distance = 24f;

    private float nextGroundXPos;

    [SerializeField]
    private float generateLevelWaitTime = 7f;

    private float waitTime;
    // Start is called before the first frame update
    void Start()
    {
        Genetate();
        waitTime = Time.time + generateLevelWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        CheckForGround();
    }

    void Genetate()
    {
        Vector3 groundPosition = Vector3.zero;

        GameObject newGround;

        for(int i = 0; i < groundToSpawn; i++)
        {
            groundPosition = new Vector3(nextGroundXPos, ground_Y_Pos, 0f);

            newGround = Instantiate(grondPlefab, groundPosition, Quaternion.identity);

            newGround.transform.SetParent(transform);

            groundPool.Add(newGround);

            nextGroundXPos += ground_X_Distance;
        }
    }

    void CheckForGround()
    {
        if(Time.time > waitTime)
        {
            SetNewGround();

            waitTime = Time.time + generateLevelWaitTime;
        }
    }

    void SetNewGround()
    {
        Vector3 groundPosition = Vector3.zero;

        foreach(GameObject obj in groundPool)
        {
            if(!obj.activeInHierarchy)
            {
                groundPosition = new Vector3(nextGroundXPos, ground_Y_Pos, 0f);
                obj.transform.position = groundPosition;
                obj.SetActive(true);

                nextGroundXPos += ground_X_Distance;
            }
        }
    }
}

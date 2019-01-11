using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    public GameObject platformPrefab;
    public GameObject speedPlatformPrefab;
    public GameObject slowPlatformPrefab;
    public GameObject finishLinePrefab;

    public int numberOfPlatforms = 200;
    public float levelWidth = 3f;
    public float minY = .2f;
    public float maxY = 1.5f;
    public int specialChance = 20;
    public int speedGen = 5;
    public int slowGen = 3;

    // Start is called before the first frame update
    void Start()
    {

        Vector3 spawnPosition = new Vector3();

        for(int i = 0; i < numberOfPlatforms; i++)
        {
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            int special = Random.Range(1, 20);
            if (special == speedGen)
            {
                Instantiate(speedPlatformPrefab, spawnPosition, Quaternion.identity);
            }
            else if (special == slowGen)
            {
                Instantiate(slowPlatformPrefab, spawnPosition, Quaternion.identity);
            }
            else
            {
                Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
            }
        }

        spawnPosition.x = 0;
        spawnPosition.y += maxY;
        Instantiate(finishLinePrefab, spawnPosition, Quaternion.identity);
    }
}

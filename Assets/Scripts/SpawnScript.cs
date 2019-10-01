using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject[] obj;

    public int levelSize = 100;
    public List<GameObject> enemies;

    private int[,] platformDictionary;

    private int spawningOffset;
    private bool endFound = false;

    // Start is called before the first frame update
    void Start()
    {
        platformDictionary = new int[levelSize, 5];

        platformDictionary[0, 0] = 1;
        spawningOffset = 3;
    }

    private void Update()
    {
        GameObject[] platforms = GameObject.FindGameObjectsWithTag("Platform");

        int visiblePlatforms = 0;

        for(int i = 0; i < platforms.Length; i++)
        {
            if (platforms[i].GetComponentInChildren<SpriteRenderer>().isVisible)
            {
                visiblePlatforms++;
            }
        }

        if (!endFound)
        {
            if (spawningOffset >= platformDictionary.GetLength(0) - 5)
            {
                Instantiate(obj[1], new Vector3(platformDictionary.GetLength(0), 1, 0), Quaternion.identity);
                endFound = true;
            }
            else
            {
                if (visiblePlatforms < 50)
                {
                    Spawn(10 - visiblePlatforms);
                }
            }
        }
    }

    void Spawn(int spawnNumber)
    {
        for(int i = 0; i < spawnNumber; i++)
        {
            int xCoord = Random.Range(spawningOffset, (spawningOffset + 5) % platformDictionary.GetLength(0));
            int yCoord = Random.Range(1, 5);

            if (platformDictionary[xCoord, yCoord] == 0) {
                GameObject newPlatform = Instantiate(obj[0], new Vector3(xCoord, yCoord, 0), Quaternion.identity);
                spawningOffset = xCoord;

                platformDictionary[xCoord, yCoord] = 1;

                if(enemies.Count > 0)
                {
                    if(Random.Range(0, 100) > 60)
                    {
                        Vector3 spawnPosition = new Vector3(newPlatform.transform.position.x + 1.5f, newPlatform.transform.position.y + 1, 0);
                        Instantiate(enemies[Random.Range(0, enemies.Count)], spawnPosition, Quaternion.identity);
                    }
                }
            }
        }
    }
}

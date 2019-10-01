using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject[] obj;
    public float spawnMin = 1f;
    public float spawnMax = 2f;

    public int levelSize = 100;

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

        Debug.Log(">> " + spawningOffset + " " + (platformDictionary.GetLength(0) - 5));

        if (!endFound)
        {
            if (spawningOffset >= platformDictionary.GetLength(0) - 10)
            {
                Instantiate(obj[1], new Vector3(platformDictionary.GetLength(0), 1, 0), Quaternion.identity);
                endFound = true;
            }
            else
            {
                if (visiblePlatforms < 10)
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
                Instantiate(obj[0], new Vector3(xCoord, yCoord, 0), Quaternion.identity);
                spawningOffset = xCoord;

                platformDictionary[xCoord, yCoord] = 1;
            }
        }
        //Invoke("Spawn", Random.Range(spawnMin, spawnMax));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{

    [SerializeField] int columnPoolSize = 5;
    [SerializeField] GameObject columnPrefabNormal;
    [SerializeField] GameObject columnPrefabEasy;
    

    [SerializeField] float spawnRate = 4f;
    [SerializeField] float columnMin = -3.5f;
    [SerializeField] float columnMax = 1.5f;

    private GameObject columnPrefab;
    private GameObject[] columns;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    private float timeSinceLastSpawned;
    private float spawnXPosition = 12f;
    private int currentColumn = 0;

    // Start is called before the first frame update
    void Start()
    {
        
        if (PlayerPrefsController.GetEasyToggle() == 1)
        {
            columnPrefab = columnPrefabEasy;
        } else
        {
            columnPrefab = columnPrefabNormal;
        }

        columns = new GameObject[columnPoolSize];
        for (int i = 0; i < columnPoolSize; i++)
        {
            columns[i] = GameObject.Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if(GameController.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0;
            float spawnYPosition = Random.Range(columnMin, columnMax);
            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentColumn++;
            if(currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }
        }
    }
}

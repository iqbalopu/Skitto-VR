using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_4_BatSpawnController : MonoBehaviour {

    public Transform batSpawnTransformHolder;
    public List<Transform> batSpawnPositions;
    public GameObject[] BatPrefabs;
    public int CurrentBatCount;
    public int MaxbatCount;
    int batIndex;
    int batSpawnIndex;
    private void Start()
    {
        CurrentBatCount = 0;
        MaxbatCount = 5;
        batSpawnPositions = new List<Transform>();
        foreach(Transform t in batSpawnTransformHolder)
        {
            batSpawnPositions.Add(t);
        }
    }
    private void Update()
    {
        if(Level_4_GameTimeController.instance.gameTimeOn)
        {
            if (CurrentBatCount < MaxbatCount)
            {
                int tempBatCount = MaxbatCount - CurrentBatCount;
                for (int i = 0; i < tempBatCount; i++)
                {
                    InstantiatebatPrefab();
                    CurrentBatCount++;
                }
            }
        }
    }
    void InstantiatebatPrefab()
    {
        batIndex = Random.Range(0, BatPrefabs.Length);
        batSpawnIndex = Random.Range(0, batSpawnPositions.Count);
        Instantiate(BatPrefabs[batIndex], batSpawnPositions[batSpawnIndex].position, Quaternion.identity);
    }
}

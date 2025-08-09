using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public Transform player;
    public float spawnInterval = 5f;
    public float despawnDistance = 20f; // distância atrás do jogador para destruir

    private float timer;
    private float[] laneX = new float[] { 4.9f, 8.5f, 12f };

    // Lista para armazenar obstáculos ativos
    private List<GameObject> activeObstacles = new List<GameObject>();

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObstacle();
            timer = 0f;
        }

        // Verifica obstáculos para remoção
        DespawnObstacles();
    }

    void SpawnObstacle()
    {
        int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
        int laneIndex = Random.Range(0, laneX.Length);

        float forwardOffset = Random.Range(50f, 70f);

        Vector3 spawnPosition = new Vector3(
            laneX[laneIndex],
            0.65f,
            player.position.z + forwardOffset
        );

        Quaternion rotation = Quaternion.Euler(0f, 90f, 0f);

        GameObject obstacle = Instantiate(obstaclePrefabs[obstacleIndex], spawnPosition, rotation);
        activeObstacles.Add(obstacle); // Adiciona à lista
    }

    void DespawnObstacles()
    {
        // Lista temporária para guardar os obstáculos a remover
        List<GameObject> obstaclesToRemove = new List<GameObject>();

        foreach (GameObject obstacle in activeObstacles)
        {
            if (obstacle != null && obstacle.transform.position.z < player.position.z - despawnDistance)
            {
                obstaclesToRemove.Add(obstacle);
            }
        }

        // Remove obstáculos fora do alcance
        foreach (GameObject obstacle in obstaclesToRemove)
        {
            activeObstacles.Remove(obstacle);
            Destroy(obstacle);
        }
    }
}

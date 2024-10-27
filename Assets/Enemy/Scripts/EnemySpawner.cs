using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    private bool isGameActive = true;
    [Header("Configurações de Spawn")]
    public GameObject enemy1;
    public GameObject enemy2;
    private Transform planet;
    public float spawnInterval = 2f;
    public float spawnDistance = 5f;
    public float minSpawnInterval = 0.1f;

    [Header("Configurações de Velocidade")]
    public float initialSpeed = 0.1f;

    private float currentSpeed;

    private void Start()
    {

        planet = GameObject.FindGameObjectWithTag("Planet").transform;
        currentSpeed = initialSpeed; // Define a velocidade inicial
        StartCoroutine(SpawnEnemies());
    }


    private IEnumerator SpawnEnemies()
    {
        while (isGameActive)
        {
            SpawnObject();
            yield return new WaitForSeconds(spawnInterval);
            spawnInterval = Mathf.Max(spawnInterval - 0.01f, minSpawnInterval);
        }
    }

    //get random enemy type 
    private GameObject GetRandomEnemy()
    {

        if (Time.time < 30f)
        {
            return enemy1;
        }
        if (Time.time < 60f)
        {
            return Random.value < 0.3f ? enemy1 : enemy2;
        }

        return Random.value < 0.5f ? enemy1 : enemy2;
    }

    private void SpawnObject()
    {
        if (!isGameActive || planet == null) return;

        Vector3 spawnPosition = GetRandomEdgePosition();
        GameObject _enemy = GetRandomEnemy();
        GameObject newObject = Instantiate(_enemy, spawnPosition, Quaternion.identity);
        newObject.GetComponent<EnemyMovement>().Initialize(planet, _enemy.GetComponent<Enemy>().velocity);

        // Aumenta a velocidade para o próximo inimigo
        //currentSpeed += speedIncreaseRate;
    }

    // private Vector3 GetRandomEdgePosition()
    // {
    //     float screenWidth = Camera.main.orthographicSize * Camera.main.aspect;
    //     float screenHeight = Camera.main.orthographicSize;

    //     Vector3 position = Vector3.zero;

    //     // Escolher aleatoriamente se spawnar na borda vertical ou horizontal
    //     if (Random.value < 0.5f)  // Vertical
    //     {
    //         position.x = Random.Range(-screenWidth, screenWidth);
    //         position.y = Random.value < 0.5f ? screenHeight : -screenHeight;
    //     }
    //     else  // Horizontal
    //     {
    //         position.y = Random.Range(-screenHeight, screenHeight);
    //         position.x = Random.value < 0.5f ? screenWidth : -screenWidth;
    //     }

    //     return position;
    // }

    private Vector3 GetRandomEdgePosition()
    {
        Vector3 position = Vector3.zero;
        Vector2 screenSize = new Vector2(Screen.width, Screen.height);

        // Escolher aleatoriamente se spawnar na borda vertical ou horizontal
        if (Random.value < 0.5f)  // Vertical
        {
            position.x = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, screenSize.x), 0, 0)).x;
            position.y = Random.value < 0.5f ?
                Camera.main.ScreenToWorldPoint(new Vector3(0, screenSize.y + spawnDistance, 0)).y :
                Camera.main.ScreenToWorldPoint(new Vector3(0, -spawnDistance, 0)).y;
        }
        else  // Horizontal
        {
            position.y = Camera.main.ScreenToWorldPoint(new Vector3(0, Random.Range(0, screenSize.y), 0)).y;
            position.x = Random.value < 0.5f ?
                Camera.main.ScreenToWorldPoint(new Vector3(screenSize.x + spawnDistance, 0, 0)).x :
                Camera.main.ScreenToWorldPoint(new Vector3(-spawnDistance, 0, 0)).x;
        }

        return position;
    }
    public void StopSpawning()
    {
        isGameActive = false; // Para de spawnar inimigos
    }
}
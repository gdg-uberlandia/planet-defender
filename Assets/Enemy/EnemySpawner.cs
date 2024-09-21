using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject objectPrefab;  // Prefab do objeto a ser spawnado
    public Transform planet;          // Referência ao planeta
    public float spawnInterval = 2f;  // Intervalo de spawn
    public float spawnDistance = 5f;   // Distância das bordas da tela
    public float initialSpeed = .1f;     // Velocidade inicial
    public float speedIncreaseRate = 0.05f; // Aumento de velocidade a cada intervalo

    private float currentSpeed;
     private void Start()
    {
        currentSpeed = initialSpeed; // Define a velocidade inicial
        InvokeRepeating(nameof(SpawnObject), 0f, spawnInterval);
    }

    private void SpawnObject()
    {
        Vector3 spawnPosition = GetRandomEdgePosition();
        GameObject newObject = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
        newObject.GetComponent<EnemyMovement>().Initialize(planet, currentSpeed);

        // Aumenta a velocidade para o próximo inimigo
        currentSpeed += speedIncreaseRate;
    }

    private Vector3 GetRandomEdgePosition()
    {
        float screenWidth = Camera.main.orthographicSize * Camera.main.aspect;
        float screenHeight = Camera.main.orthographicSize;

        Vector3 position = Vector3.zero;

        // Escolher aleatoriamente se spawnar na borda vertical ou horizontal
        if (Random.value < 0.5f)  // Vertical
        {
            position.x = Random.Range(-screenWidth, screenWidth);
            position.y = Random.value < 0.5f ? screenHeight : -screenHeight;
        }
        else  // Horizontal
        {
            position.y = Random.Range(-screenHeight, screenHeight);
            position.x = Random.value < 0.5f ? screenWidth : -screenWidth;
        }

        return position;
    }
}
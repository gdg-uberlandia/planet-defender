using UnityEngine;
using UnityEngine.UI; // Adicione isso se estiver usando o UI padrão
using TMPro;

public class PlanetHealth : MonoBehaviour
{
    private float currentlHealth = 0;
    public float maxHealth = 10f;
    public GameManager gameManager; // Referência ao GameManager
    public TextMeshProUGUI healthText; // Referência ao Text de vida
    
    public GameObject ship;

    private void Start()
    {
        currentlHealth = maxHealth;
        UpdateHealthText(); // Atualiza o texto no início
    }

    public void Damage(float damage)
    {
        currentlHealth -= damage;
        UpdateHealthText(); // Atualiza o texto após dano

        if (currentlHealth <= 0)
        {
            Destroy(gameObject);
            Destroy(ship);
            gameManager.GameOver(); // Chama o Game Over
        }
    }

    private void UpdateHealthText()
    {
        healthText.text = "Planet health: " + currentlHealth/maxHealth*100 + "%"; // Atualiza o texto com a vida atual
    }
}
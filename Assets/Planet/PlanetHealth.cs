using UnityEngine;
using UnityEngine.UI; // Adicione isso se estiver usando o UI padrão
using TMPro;

public class PlanetHealth : MonoBehaviour
{
    public int health = 10;
    public GameManager gameManager; // Referência ao GameManager
    public TextMeshProUGUI healthText; // Referência ao Text de vida

    private void Start()
    {
        UpdateHealthText(); // Atualiza o texto no início
    }

    public void Damage(int damage)
    {
        health -= damage;
        UpdateHealthText(); // Atualiza o texto após dano

        if (health <= 0)
        {
            Destroy(gameObject);
            gameManager.GameOver(); // Chama o Game Over
        }
    }

    private void UpdateHealthText()
    {
        healthText.text = "Vida do Planeta: " + health; // Atualiza o texto com a vida atual
    }
}
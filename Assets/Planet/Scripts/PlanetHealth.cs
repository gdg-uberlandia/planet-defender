using UnityEngine;
using UnityEngine.UI; // Adicione isso se estiver usando o UI padrão
using TMPro;

public class PlanetHealth : MonoBehaviour
{

    public GameManager gameManager; // Referência ao GameManager
    public TextMeshProUGUI healthText; // Referência ao Text de vida

    public void Dead()
    {
        gameManager.GameOver(); // Chama o Game Over
    }

    public void UpdateHealthText(float currentlHealth, float maxHealth)
    {
        healthText.text = "Planet health: " + currentlHealth / maxHealth * 100 + "%"; // Atualiza o texto com a vida atual
    }
}
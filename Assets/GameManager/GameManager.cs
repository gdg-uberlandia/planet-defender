using UnityEngine;
using UnityEngine.UI; 

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel; // Referência ao painel de Game Over

    public void GameOver()
    {
        gameOverPanel.SetActive(true); 
        Time.timeScale = 0; // Pausa o jogo
    }
}
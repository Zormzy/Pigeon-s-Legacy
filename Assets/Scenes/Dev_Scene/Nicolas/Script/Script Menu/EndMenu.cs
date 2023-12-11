using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameOverTitle;
    public bool _win;

    public void EndMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnGameOverCheck()
    {
        if (_win) 
            gameOverTitle.text = "Étage terminé";
        else
            gameOverTitle.text = "Votre équipe à succombé";        
    }
}
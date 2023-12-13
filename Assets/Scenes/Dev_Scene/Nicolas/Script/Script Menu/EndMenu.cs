using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameOverTitle;

    public void EndMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void Replay()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnGameOverCheck(bool _isWin)
    {
        if (_isWin)
            gameOverTitle.text = "Étage terminé";
        else
            gameOverTitle.text = "Votre équipe à succombé";

        Time.timeScale = 0;
    }
}
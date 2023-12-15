using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameOverTitle;
    [SerializeField] private TutoData _tutoData;

    public void EndMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void Replay()
    {
        Time.timeScale = 1;
        string nomSceneActuelle = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(nomSceneActuelle);
    }

    public void OnGameOverCheck(bool _isWin)
    {
        if (_isWin)
            gameOverTitle.text = "�tage termin�";
        else
            gameOverTitle.text = "Votre �quipe � succomb�";

        Time.timeScale = 0;
    }
}
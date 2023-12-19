using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameOverTitle;
    [SerializeField] private GameObject _ButtonRejouer;
    [SerializeField] private GameObject _ButtonNiveauSuivant;
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
        {
            gameOverTitle.text = "Etage termine";
            _ButtonNiveauSuivant.SetActive(true);
            _ButtonRejouer.SetActive(false);
        }  
        else
        {
            gameOverTitle.text = "Votre equipe à succombe";
            _ButtonNiveauSuivant.SetActive(false);
            _ButtonRejouer.SetActive(true);
        }
            

        Time.timeScale = 0;
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

public class PL_MainMenuButtons : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject _creditsCanvas;
    [SerializeField] private GameObject _commencerBtn;
    [SerializeField] private GameObject _creditsBtn;
    [SerializeField] private GameObject _quitterBtn;
    [SerializeField] private TutoManager _tutoData;

    //Start Button
    public void OnCommencerBtn()
    {
        SceneManager.LoadScene("Level_MVP");        
    }

    //Credits Button
    public void OnCreditsBtn()
    {
        _creditsCanvas.SetActive(true);
        _commencerBtn.SetActive(false); 
        _creditsBtn.SetActive(false);
        _quitterBtn.SetActive(false);
    }

    //Button return in credits canvas
    public void OnRetournerBtn()
    {
        _commencerBtn.SetActive(true);
        _creditsBtn.SetActive(true);
        _quitterBtn.SetActive(true);
        _creditsCanvas.SetActive(false);
    }

    // Leave Button
    public void OnQuitterBtn()
    {
        Application.Quit();
    }
}

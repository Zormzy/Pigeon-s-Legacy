using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] public GameObject pauseMenu;
    private bool _gamePaused;

    public void Start()
    {
        _gamePaused = false;
    }

    public void PauseMenuOpen(InputAction.CallbackContext context)
    {
        if (context.performed && !_gamePaused)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            _gamePaused = true;
        }
        else if (context.performed && _gamePaused)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            _gamePaused = false;
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        _gamePaused = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
}

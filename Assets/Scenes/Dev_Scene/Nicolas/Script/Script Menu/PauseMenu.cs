using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] public GameObject pauseMenu;

    public void Start()
    {
        pauseMenu.SetActive(false);
    }


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pauseMenu.activeSelf)
        {
            PauseMenuOpen();
        }
        else if(pauseMenu.activeSelf && (Input.GetKeyDown(KeyCode.Escape)))
        {
            Resume();
        }
    }

    public void PauseMenuOpen()
    {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
    }



    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
}

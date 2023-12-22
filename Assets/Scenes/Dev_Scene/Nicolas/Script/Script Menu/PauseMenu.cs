using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] public GameObject pauseMenu;
    private OpenInventory openInventory;

    public void Start()
    {
        openInventory = GetComponent<OpenInventory>();
    }

    public void PauseInput(InputAction.CallbackContext context)
    {
        if (!openInventory.inventoryOpened && context.performed)
        {
            Time.timeScale = (Time.timeScale == 0) ? 1 : 0;
            pauseMenu.SetActive(!pauseMenu.activeSelf);
        }

    }

    public void Pause()
    {
        if (!openInventory.inventoryOpened)
        {
            Time.timeScale = (Time.timeScale == 0) ? 1 : 0;
            pauseMenu.SetActive(!pauseMenu.activeSelf);
        };
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
}

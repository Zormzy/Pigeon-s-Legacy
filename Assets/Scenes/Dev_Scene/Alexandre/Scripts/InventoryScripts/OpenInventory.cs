using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class OpenInventory : MonoBehaviour
{

    public GameObject GreenPigeonCard; //warrior
    public GameObject BluePigeonCard; //Thief
    public GameObject YellowPigeonCard; //Engineer
    public GameObject RedPigeonCard; //Doctor
    public GameObject PlayerHotBar;
    [SerializeField] private GameObject Bg;
    public bool inventoryOpened { get; private set; } = false;
    private void Start()
    {
        GreenPigeonCard.SetActive(false);
        BluePigeonCard.SetActive(false);
        YellowPigeonCard.SetActive(false);
        RedPigeonCard.SetActive(false);
        PlayerHotBar.SetActive(false);
        Bg.SetActive(false);
    }

    public void WarriorClicked()
    {
        CloseInventory();
        GreenPigeonCard.SetActive(true);
        PlayerHotBar.SetActive(true);
        Bg.SetActive(true);
        inventoryOpened = true;
        Time.timeScale = 0;
    }
    public void ThiefClicked()
    {
        CloseInventory();
        BluePigeonCard.SetActive(true);
        PlayerHotBar.SetActive(true);
        Bg.SetActive(true);
        inventoryOpened = true;
        Time.timeScale = 0;
    }
    public void EngineerClicked()
    {
        CloseInventory();
        YellowPigeonCard.SetActive(true);
        PlayerHotBar.SetActive(true);
        Bg.SetActive(true);
        inventoryOpened = true;
        Time.timeScale = 0;
    }
    public void DoctorClicked()
    {
        CloseInventory();
        PlayerHotBar.SetActive(true);
        RedPigeonCard.SetActive(true);
        Bg.SetActive(true);
        inventoryOpened = true;
        Time.timeScale = 0;
    }
    public void CloseInventory()
    {
        GreenPigeonCard.SetActive(false);
        BluePigeonCard.SetActive(false);
        YellowPigeonCard.SetActive(false);
        RedPigeonCard.SetActive(false);
        PlayerHotBar.SetActive(false);
        Bg.SetActive(false);
        inventoryOpened = false;
        Time.timeScale = 1;
    }

    private void Update()
    {
        print(inventoryOpened);
    }

    public void CloseInventoryInput(InputAction.CallbackContext ctx)
    {
        if (ctx.canceled && inventoryOpened)
        {
            GreenPigeonCard.SetActive(false);
            BluePigeonCard.SetActive(false);
            YellowPigeonCard.SetActive(false);
            RedPigeonCard.SetActive(false);
            PlayerHotBar.SetActive(false);
            Bg.SetActive(false);
            inventoryOpened = false;
            Time.timeScale = 1;
        }
    }
}

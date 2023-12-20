using UnityEngine;
using UnityEngine.UI;

public class OpenInventory : MonoBehaviour
{

    public GameObject GreenPigeonCard; //warrior
    public GameObject BluePigeonCard; //Thief
    public GameObject YellowPigeonCard; //Engineer
    public GameObject RedPigeonCard; //Doctor
    public GameObject PlayerHotBar;
    [SerializeField] private GameObject Bg;
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
    }
    public void ThiefClicked()
    {
        CloseInventory();
        BluePigeonCard.SetActive(true);
        PlayerHotBar.SetActive(true);
        Bg.SetActive(true);
    }
    public void EngineerClicked()
    {
        CloseInventory();
        YellowPigeonCard.SetActive(true);
        PlayerHotBar.SetActive(true);
        Bg.SetActive(true);
    }
    public void DoctorClicked()
    {
        CloseInventory();
        PlayerHotBar.SetActive(true);
        RedPigeonCard.SetActive(true);
        Bg.SetActive(true);
    }
    public void CloseInventory()
    {
        GreenPigeonCard.SetActive(false);
        BluePigeonCard.SetActive(false);
        YellowPigeonCard.SetActive(false);
        RedPigeonCard.SetActive(false);
        PlayerHotBar.SetActive(false);
        Bg.SetActive(false);
    }
}

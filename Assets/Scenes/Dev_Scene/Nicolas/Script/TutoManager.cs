using UnityEngine;

public class TutoManager : MonoBehaviour
{ 
    [SerializeField] private TutoData _tutoData;
    [SerializeField] public GameObject tuto1;
    [SerializeField] public GameObject tuto2;
    [SerializeField] public GameObject tuto3;
    [SerializeField] public GameObject tuto4;
    [SerializeField] public GameObject CharacterUI;

    public void Start()
    {
        //set timescale to 0 for the tuto
        Time.timeScale = 0;
        if (!_tutoData.tuto4)
        {
            CharacterUI.SetActive(false);
        }
        // Tuto Finish set all tuto to false for so active ui tuto in restart
        if (_tutoData.tuto1 && _tutoData.tuto2 && _tutoData.tuto3 && _tutoData.tuto4)
        {
            tuto1.SetActive(false);
            tuto2.SetActive(false);
            tuto3.SetActive(false);
            tuto4.SetActive(false);
            CharacterUI.SetActive(true);
            Time.timeScale = 1;
        }

    }

    //when tuto 1 finish 
    public void Tuto1Exit()
    { 
        Time.timeScale = 0;
        tuto1.SetActive(false);
        tuto2.SetActive(true);
        _tutoData.tuto1 = true;      
    }

    //when tuto 2 finish 
    public void Tuto2Exit()
    {
        Time.timeScale = 0;
        _tutoData.tuto2 = true;
        tuto2.SetActive(false);
        tuto3.SetActive(true);
    }

    //when tuto 3 finish 
    public void Tuto3Exit()
    {
        Time.timeScale = 0;
        _tutoData.tuto3 = true;
        tuto3.SetActive(false);
        tuto4.SetActive(true);
    }

    //when tuto 4 finish 
    public void Tuto4Exit()
    {
        Time.timeScale = 1;
        _tutoData.tuto4 = true;
        tuto4.SetActive(false);
        CharacterUI.SetActive(true);
    }

    //private void OnDestroy()
    //{
    //    _tutoData.tuto1 = false;
    //    _tutoData.tuto2 = false;
    //    _tutoData.tuto3 = false;
    //    _tutoData.tuto4 = false;

    //}
}

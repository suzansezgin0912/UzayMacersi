using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OyunKontrol : MonoBehaviour
{
    public GameObject GameOver;
    public GameObject joystick;
    public GameObject Ziplama;
    public GameObject Tabela;
    public GameObject Menu;
    public GameObject Slider;

    // Start is called before the first frame update
    void Start()
    {
        GameOver.SetActive(false);
        UIAc();
    }

   
    public void OyunuBitir()
    {
        FindObjectOfType<SesKontrol>().OyunBittiSes();
        GameOver.SetActive(true);
        FindObjectOfType<Puan>().OyunBitti();
        FindObjectOfType<OyuncuHareket>().OyunBitti();
        FindObjectOfType<KameraHareket>().OyunBitti();
        UIKapat();
    }

    public void AnamenuDon()
    {
        SceneManager.LoadScene("Menu");
    }

    public void TekrarOyna()
    {
        SceneManager.LoadScene("Oyun");
    }

    void UIAc()
    {
        joystick.SetActive(true);
        Ziplama.SetActive(true);
        Tabela.SetActive(true);
        Menu.SetActive(true);
        Slider.SetActive(true);

    }

    void UIKapat()
    {
        joystick.SetActive(false);
        Ziplama.SetActive(false);
        Tabela.SetActive(false);
        Menu.SetActive(false);
        Slider.SetActive(false);
    }
}

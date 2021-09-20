using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuKontrol : MonoBehaviour
{
    [SerializeField] 
    Sprite[] muzikIconlar = default;

    [SerializeField]
    Button muzikButton = default;

   
    // Start is called before the first frame update
    void Start()
    {
        if (Secenekler.KayitVarmi() == false)
        {
            Secenekler.KolayDegerAta(1);
        }
        if(Secenekler.MuzikVarmi() == false)
        {
            Secenekler.MuzikAcikDegerAta(1);
        }
        MuzikAyalrlariniDenetle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OyunuBaslat()
    {
        SceneManager.LoadScene("Oyun");
    }

    public void EnyuksekPuan()
    {
        SceneManager.LoadScene("Puan");
    }

    public void Ayarlar()
    {
        SceneManager.LoadScene("Ayarlar"); 
    }

    public void Muzik()
    {
        if(Secenekler.MuzikAcikDegerOku()==1)
        {
            Secenekler.MuzikAcikDegerAta(0);
            MuzikKontrol.instance.MüzikCal(false);
            muzikButton.image.sprite = muzikIconlar[0];
        }
        else
        {
            Secenekler.MuzikAcikDegerAta(1);
            MuzikKontrol.instance.MüzikCal(true);
            muzikButton.image.sprite = muzikIconlar[1];
        }
    }

    void MuzikAyalrlariniDenetle()
    {
        if(Secenekler.MuzikAcikDegerOku()==1)
        {
            MuzikKontrol.instance.MüzikCal(true);
            muzikButton.image.sprite = muzikIconlar[1];
        } else
        {
            MuzikKontrol.instance.MüzikCal(false);
            muzikButton.image.sprite = muzikIconlar[0];
        }
    }
}

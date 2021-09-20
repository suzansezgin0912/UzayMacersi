using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PuanKontrol : MonoBehaviour
{
    public Text kolayPuan, kolayAltin, ortaPuan, ortaAltin, zorPuan, ZorAltin;

    // Start is called before the first frame update
    void Start()
    {
        kolayPuan.text = "Puan: " + Secenekler.KolayPuanDegerOku();
        kolayAltin.text = " X " + Secenekler.KolayAltinDegerOku();

        ortaPuan.text = "Puan: " + Secenekler.OrtayPuanDegerOku();
        ortaAltin.text = " X " + Secenekler.OrtayAltinDegerOku();

        zorPuan.text = "Puan: " + Secenekler.ZorPuanDegerOku();
        ZorAltin.text = " X " + Secenekler.ZorAltinDegerOku();
    }

    public void Anamenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

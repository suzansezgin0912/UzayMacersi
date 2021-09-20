using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AyarlarKontrol : MonoBehaviour
{
    public Button kolayButton, ortaButton, zorButton;

    // Start is called before the first frame update
    void Start()
    {
        if (Secenekler.KolayDegerOku() == 1)
        {
            kolayButton.interactable = false;
            ortaButton.interactable = true;
            zorButton.interactable = true;
        }
        if (Secenekler.OrtayDegerOku() == 1)
        {
            kolayButton.interactable = true;
            ortaButton.interactable = false;
            zorButton.interactable = true;
        }
        if (Secenekler.ZorDegerOku() == 1)
        {
            kolayButton.interactable = true;
            ortaButton.interactable = true;
            zorButton.interactable = false;
        }
    }

    public void SecenekSecildi(string seviye)
    {
        switch (seviye)
        {
            case "kolay":
                Secenekler.KolayDegerAta(1);
                Secenekler.OrtaDegerAta(0);
                Secenekler.ZorDegerAta(0);
                kolayButton.interactable = false;
                ortaButton.interactable = true;
                zorButton.interactable = true;
                break;
            case "orta":
                Secenekler.KolayDegerAta(0);
                Secenekler.OrtaDegerAta(1);
                Secenekler.ZorDegerAta(0);
                kolayButton.interactable = true;
                ortaButton.interactable = false;
                zorButton.interactable = true;
                break;
            case "zor":
                Secenekler.KolayDegerAta(0);
                Secenekler.OrtaDegerAta(0);
                Secenekler.ZorDegerAta(1);
                kolayButton.interactable = true;
                ortaButton.interactable = true;
                zorButton.interactable = false;
                break;
            default:
                break;
        }
    }

    public void AnaMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

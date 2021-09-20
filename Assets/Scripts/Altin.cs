using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altin : MonoBehaviour
{
    [SerializeField]
    GameObject altin = default;
   public void altinAc()
    {
        altin.SetActive(true);
    }

    public void altinKapat()
    {
        altin.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gezegenler : MonoBehaviour
{
    List<GameObject> gezegenler = new List<GameObject>();
    List<GameObject> kullanilanGezegenler = new List<GameObject>();

    void Awake()
    {
        Object[] sprites = Resources.LoadAll("Gezegenler");

        for (int i = 1; i < 17; i++)
        {
            GameObject gezegen = new GameObject();
            SpriteRenderer sremderer = gezegen.AddComponent<SpriteRenderer>();
            sremderer.sprite = (Sprite)sprites[i];
            Color spriteColor = sremderer.color;
            spriteColor.a = 0.5f;
            sremderer.color = spriteColor;
            gezegen.name = sprites[i].name;
            sremderer.sortingLayerName = "Gezegen";
            Vector2 pozisyon = gezegen.transform.position;
            pozisyon.x = -10;
            gezegen.transform.position = pozisyon;
            gezegenler.Add(gezegen);
        }
    }
    public void GezegenYerlestir(float refY)
    {
        float yukseklik = EkranHesaplayicisi.instance.Yukseklik;
        float genislik = EkranHesaplayicisi.instance.Genislik;

        float xDeger1 = Random.Range(0.0f, genislik);
        float yDeger1 = Random.Range(refY, refY + yukseklik);
        GameObject gezegen1 = RandomGezegenler();
        gezegen1.transform.position = new Vector2(xDeger1, yDeger1);

        float xDeger2 = Random.Range(-genislik, 0.0f);
        float yDeger2 = Random.Range(refY, refY + yukseklik);
        GameObject gezegen2 = RandomGezegenler();
        gezegen2.transform.position = new Vector2(xDeger2, yDeger2);

        float xDeger3 = Random.Range(-genislik, 0.0f );
        float yDeger3 = Random.Range(refY - yukseklik, refY);
        GameObject gezegen3 = RandomGezegenler();
        gezegen3.transform.position = new Vector2(xDeger3, yDeger3);

        float xDeger4 = Random.Range(0.0f, genislik);
        float yDeger4 = Random.Range(refY - yukseklik, refY);
        GameObject gezegen4 = RandomGezegenler();
        gezegen4.transform.position = new Vector2(xDeger4, yDeger4);
    }

    GameObject RandomGezegenler()
    {
        if (gezegenler.Count > 0)
        {
            int random;
            if (gezegenler.Count == 1)
            {
                random = 0;
            } else
            {
                random = Random.Range(0, gezegenler.Count - 1);
            }
            GameObject gezegen = gezegenler[random];
            gezegenler.Remove(gezegen);
            kullanilanGezegenler.Add(gezegen);
            return gezegen;   
        } else
        {
            for (int i = 0; i < 8; i++)
            {
                gezegenler.Add(kullanilanGezegenler[i]);
            }
            kullanilanGezegenler.RemoveRange(0, 8);
            int random = Random.Range(0, 8);
            GameObject gezegen = gezegenler[random];
            gezegenler.Remove(gezegen);
            kullanilanGezegenler.Add(gezegen);
            return gezegen;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyuncuHareket : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator animator;

    Vector2 velocity;

    [SerializeField]
    float hiz = default;

    [SerializeField]
    float hizlanma = default;

    [SerializeField]
    float yavaslama = default;

    [SerializeField]
    float ziplamaGucu = default;

    int ziplamaLimiti = 3;
    int ziplamaSayisi = default;

    Joystick joystick;

    JoystickButton joystickButton;

    bool zipliyor;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        joystick = FindObjectOfType<Joystick>();
        joystickButton = FindObjectOfType<JoystickButton>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        KlavyeKontrol();
#else
                JoysticKontrol();
#endif

    } 

    void KlavyeKontrol()
    {
        float hareketInput = Input.GetAxisRaw("Horizontal");
        Vector2 scale = transform.localScale;

        if(hareketInput > 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, hareketInput * hiz, hizlanma * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = 0.3f;
        } else if(hareketInput < 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, hareketInput * hiz, hizlanma * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = -0.3f;
        } else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, yavaslama * Time.deltaTime);
            animator.SetBool("Walk", false);
        }

        transform.localScale = scale;
        transform.Translate(velocity * Time.deltaTime);

        if(Input.GetKeyDown("space"))
        {
            ZiplamayiBaslat();
        }

        if(Input.GetKeyUp("space"))
        {
            ZiplamayiDurdur();
        }
    }

    void JoysticKontrol()
    {
        float hareketInput = joystick.Horizontal;
        Vector2 scale = transform.localScale;

        if (hareketInput > 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, hareketInput * hiz, hizlanma * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = 0.3f;
        }
        else if (hareketInput < 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, hareketInput * hiz, hizlanma * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = -0.3f;
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, yavaslama * Time.deltaTime);
            animator.SetBool("Walk", false);
        }

        transform.localScale = scale;
        transform.Translate(velocity * Time.deltaTime);

        if(joystickButton.tusaBasildi == true && zipliyor==false)
        {
            ZiplamayiBaslat();
            zipliyor = true;
        }
        if (joystickButton.tusaBasildi == false && zipliyor == true)
        {
            ZiplamayiDurdur();
            zipliyor = false;
        }
    }

    void ZiplamayiBaslat()
    {
        if(ziplamaSayisi<ziplamaLimiti)
        {
            FindObjectOfType<SesKontrol>().ZiplamaSes();
            rb2d.AddForce(new Vector2(0, ziplamaGucu), ForceMode2D.Impulse);
            animator.SetBool("Jump", true);
            FindObjectOfType<SliderControl>().SliderDeger(ziplamaLimiti, ziplamaSayisi);
        }
        
    }

    void ZiplamayiDurdur()
    {
        animator.SetBool("Jump", false);
        ziplamaSayisi++;
        FindObjectOfType<SliderControl>().SliderDeger(ziplamaLimiti, ziplamaSayisi);

    }

    public void ZipkanayiSifirla()
    {
        ziplamaSayisi = 0;
        FindObjectOfType<SliderControl>().SliderDeger(ziplamaLimiti, ziplamaSayisi); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="olum")
        {
            FindObjectOfType<OyunKontrol>().OyunuBitir();
        }
    }
    public void OyunBitti()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class playerJett : MonoBehaviour
{
    public GameObject confeti;
    // Start is called before the first frame update
    public float force;
    public int life;
    public Sprite spray;
    float collDawn = 0;
    public float forceIntervalo;
    Rigidbody2D rb;
    int score;
    public GameObject panelLose;
    public TextMeshProUGUI lifeText;

    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI coinsText2;


    public scriptablePlayer sp;
    public ScriptableSelector playerSeleccionado;
    public scriptableScore scoreManage;

    SpriteRenderer spriteRender;
    public GameObject jett;
    bool sePropulsa=false;

    public AudioSource audioS;
    public AudioClip propulsor;

    private void Awake()
    {
        Time.timeScale = 1;
        force = playerSeleccionado.force;
        life = playerSeleccionado.life;
        spriteRender = GetComponent<SpriteRenderer>();
        spriteRender.sprite = playerSeleccionado.character;
        lifeText.text = "Life: " + life;
        // transform.rotation = playerSeleccionado.rotacion;
        if (playerSeleccionado.cambiarFlip)
        {
            spriteRender.flipX=true;
        }
        

    }
    void Start()
    {
        score = sp.coins;

        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("contador", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.touchCount > 0)
        {
            // Obtener el primer toque
            Touch touch = Input.GetTouch(0);

            // Verificar si el toque est� en curso (es decir, el jugador lo est� manteniendo presionado)
            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                if (collDawn >= forceIntervalo)
                {
                    sePropulsa = true;
                    //  jett.SetActive(true);
                    rb.AddForce(Vector2.up * force , ForceMode2D.Impulse);
                    collDawn = 0;

                    audioS.PlayOneShot(propulsor);


                }

                collDawn = collDawn + Time.deltaTime;
               // print(collDawn);
            }


        }

        else if (Input.GetKey("w")|| Input.GetKey(KeyCode.UpArrow))
        {
            sePropulsa = true;
           // jett.SetActive(true);
            if (collDawn >= forceIntervalo)
            {               

                rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
                collDawn = 0;
               
                    // Si no se est� reproduciendo ning�n sonido, reproduce el nuevo sonido.
                    audioS.PlayOneShot(propulsor);
                
               
            }
            collDawn = collDawn + Time.deltaTime;
            //print(collDawn);
        }
        else
        {
            //  jett.SetActive(false);
            sePropulsa = false;

        }
        jett.SetActive(sePropulsa);

        

    }


    public void contador()
    {
        if (life > 0)
        {
            score++;
            coinsText.text = "Coins: " + score;
            coinsText2.text = "Coins: " + score;
        }

    }

    void propulsorFunction()
    {
        audioS.PlayOneShot(propulsor);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "rayo")
        {
            life--;
            lifeText.text = "Life: " + life;
            if (life <= 0)
            {
                if (scoreManage.compareBest(score))
                {
                    print("entroLaFuncion");
                    confeti.SetActive(true);
                }

                playerSeleccionado.coins += score;
                panelLose.SetActive(true);
                
                scoreManage.AddHighScore(score);
                // Time.timeScale = 0;
                transform.position = new Vector2(100, 100);
                rb.gravityScale = 0;

            }
            
        }
        if (collision.gameObject.tag == "coin")
        {
            score++;
            coinsText.text = "Coins: " + score;
            coinsText2.text = "Coins: " + score;
        }
    }


}

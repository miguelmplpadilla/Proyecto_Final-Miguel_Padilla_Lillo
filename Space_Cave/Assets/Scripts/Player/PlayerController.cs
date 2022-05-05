using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour {
    public float defaultSpeed = 1f;
    public int life = 8;
    public float speed = 1f;
    public float dashSpeed = 2f;
    private int scale = 1;
    public Animator animator;
    public bool stop = false;
    public bool dashing = false;
    public bool mov = true;
    public Blink blink;
    private bool invulnerable = false;
    public GameObject vida;
    private GunController gunController;
    private bool muerto = false;

    private Vector2 input;

    public Rigidbody2D _rigidbody;

    public int numeroJugador = 1;
    
    //Controles
    public KeyCode arriba = KeyCode.W;
    public KeyCode abajo = KeyCode.S;
    public KeyCode izquierda = KeyCode.A;
    public KeyCode derecha = KeyCode.D;

    public KeyCode deslizar = KeyCode.LeftShift;

    private void Awake() {
        speed = defaultSpeed;
        gunController = GetComponent<GunController>();

        if (numeroJugador == 2)
        {
            arriba = KeyCode.UpArrow;
            abajo = KeyCode.DownArrow;
            izquierda = KeyCode.LeftArrow;
            derecha = KeyCode.RightArrow;

            deslizar = KeyCode.RightShift;
        }
    }

    private void Start()
    {
        /*if (PlayerPrefs.HasKey("vida"))
        {
            if (!SceneManager.GetActiveScene().name.Equals("SampleScene"))
            {
                life = PlayerPrefs.GetInt("vida");
                gunController.bulletNum = PlayerPrefs.GetInt("balas");
                gameObject.transform.position =
                    new Vector2(PlayerPrefs.GetFloat("playerX"), PlayerPrefs.GetFloat("playerY"));
                string nivel = PlayerPrefs.GetString("nivel");
            }
        }*/
        
        if (PlayerPrefs.HasKey("vida"))
        {
            if (!SceneManager.GetActiveScene().name.Equals("SampleScene"))
            {
                life = PlayerPrefs.GetInt("vida");
            }
        }
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Y))
        {
            SceneManager.LoadScene("Inicio");
        }
        

        if (stop == false && mov == true) {
            //flip();
        
            movimiento();
        }
        else
        {
            animator.SetBool("run",false);
            _rigidbody.velocity = new Vector2(input.normalized.x * 0, input.normalized.y * 0);
        }

        vida.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2((20*life), 15.086f);

    }

    void movimiento() {
        /*bool up = Input.GetKey(arriba);
        bool down = Input.GetKey(abajo);
        bool right = Input.GetKey(derecha);
        bool left = Input.GetKey(izquierda);*/
        
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(horizontalInput*speed, verticalInput*speed);

        _rigidbody.velocity = movement.normalized;
            //transform.TransformDirection(new Vector3(horizontalVelocity, verticalVelocity, 0));
        
        Vector3 localScale = transform.localScale;
        
        if (horizontalInput > 0) {
            localScale.x = scale;
        }
        else if (horizontalInput < 0) {
            localScale.x = -scale;
        }
        
        transform.localScale = localScale;
        
        /*if (up) {
            input.y = 1;
        } else if (down) {
            input.y = -1;
        }
        else {
            input.y = 0;
        }
        
        if (right) {
            input.x = 1;
        } else if (left) {
            input.x = -1;
        }
        else {
            input.x = 0;
        }*/

        if (verticalInput > 0 || horizontalInput > 0 || verticalInput < 0 || horizontalInput < 0) {
            animator.SetBool("run",true);
            if (Input.GetButtonDown("Dash"))
            {
                animator.SetTrigger("dash");
                speed = dashSpeed;
            }
        }
        else
        {
            animator.SetBool("run",false);
        }
    }

    private void LateUpdate()
    {
        if (dashing == false) {
            //_rigidbody.velocity = new Vector2(input.normalized.x * speed, input.normalized.y * speed);
            speed = defaultSpeed;
        }
    }

    public void hit(int damage)
    {
        if (invulnerable == false) {
            if (!muerto) {
                life -= damage;
                if (life <= 0)
                {
                    animator.SetTrigger("death");
                    muerto = true;
                    PlayerPrefs.SetInt("vida",8);
                }
                else {
                    blink.takeDamage(2);
                    StartCoroutine("invulnerabilidad");
                }
            }
        }
    }

    IEnumerator resetearNivel()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator invulnerabilidad() {
        invulnerable = true;
        yield return new WaitForSeconds(1.5f);
        invulnerable = false;
    }

    void flip() {
        Vector3 localScale = transform.localScale;

        if (input.x > 0) {
            localScale.x = scale;
        }
        else if (input.x < 0) {
            localScale.x = -scale;
        }

        transform.localScale = localScale;
    }

    void desactivarPlayer()
    {
        mov = false;
        animator.enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        StartCoroutine("resetearNivel");
    }
}
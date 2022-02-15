using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{

    Animator animator;
    Rigidbody2D rb;

    float speed; //Velocidad enb X a la que me muevo
    [SerializeField] float maxSpeed; //velocidad de desplazamiento máxima



    float desplX;

    [SerializeField] float jumpForce;
    //Velocidad de rodare
    [SerializeField] float rollSpeed;

    //¿Estoy vivo?
    bool alive = true;

    //Hacia dónde miro en cada momento
    bool facingRight = true;

    //Booleana que dice si estoy tocando suelo
    bool tocandoSuelo;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        maxSpeed = 4f;
        jumpForce = 10f;
        rollSpeed = 10f;
    }

    // Update is called once per frame
    void Update()
    {

        desplX = Input.GetAxis("Horizontal");
       /* if (alive)
        {
            Girar();

            Saltar();

            Crouch();

            Correr();

            Roll();
        }*/

    }

    private void FixedUpdate()
    {
        if (alive)
        {
            Caminar();
        }

    }

    void Roll()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            //print("rodando");
            Vector2 rollDir;
            animator.SetTrigger("Rodar");
            if (facingRight)
            {
                rollDir = new Vector2(rollSpeed, 0f);
            }
            else
            {
                rollDir = new Vector2(-rollSpeed, 0f);
            }

            rb.AddForce(rollDir, ForceMode2D.Impulse);
        }
    }

    void Caminar()
    {
        //print(animator.GetCurrentAnimatorStateInfo(0).IsName("RobotRoll"));
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("RobotRoll"))
        {

            rb.velocity = new Vector2(desplX * maxSpeed, rb.velocity.y);
        }
        else
        {
            print("rodando");
        }
        speed = rb.velocity.x;
        speed = Mathf.Abs(speed);
        animator.SetFloat("SpeedX", speed);
        //print(speed);
    }

    void Girar()
    {
        if (desplX < 0 && facingRight)
        {
            Flip();
            facingRight = false;
        }
        else if (desplX > 0 && !facingRight)
        {
            Flip();
            facingRight = true;
        }
    }

    void Flip()
    {

        Vector3 myScale = transform.localScale;
        myScale.x *= -1;
        transform.localScale = myScale;


    }

    void Saltar()
    {
        if (Input.GetKeyDown(KeyCode.Space) && tocandoSuelo == true)
        {
            animator.SetTrigger("Saltar");
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        }
    }



    void Crouch()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("Crouch", true);
            maxSpeed = 2f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.SetBool("Crouch", false);
            maxSpeed = 4f;
        }
    }

    void Correr()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && animator.GetBool("isGrounded"))
        {
            //Cambio la velocidad
            maxSpeed = 7f;
            animator.SetBool("Run", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool("Run", false);
            maxSpeed = 4f;
        }
    }

    public void Morir()
    {
        animator.SetTrigger("Morir");
        alive = false;


        Invoke("Reiniciar", 3f);
    }

    void Reiniciar()
    {
        SceneManager.LoadScene(1);
    }

    //Control de suelo
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6 && rb.velocity.y < 0.2f)
        {
            tocandoSuelo = true;
            animator.SetBool("IsGrounded", true);
        }

        if (collision.gameObject.tag == "Plataforma")
        {
            transform.parent = collision.gameObject.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            //print("NO Estoy tocando suelo");
            animator.SetBool("IsGrounded", false);
            tocandoSuelo = false;
        }

        if (collision.gameObject.tag == "Plataforma")
        {
            transform.parent = null;
        }

    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float thrust = 5;
    public float turnThrust = 5;

    private float thrustInput;
    private float turnInput;

    public float screenLimit = 9.3f;

    public float mode = 3;

    public float linerDrag;
    public float angularDrag;

    public float cowsInHold;
    public bool movementEnabled = false;
    public GameObject cowSelector;

    public Animator anim;
    //public bool immunity = false;
    //public GameObject shield;

    //1 Cow
    public float thrust1 = 9;
    public float turnThrust1 = 1;
    public float LD1 = 4;
    public float AD1 = 18;

    //2 Cows
    public float thrust2 = 7;
    public float turnThrust2 = 1;
    public float LD2 = 3;
    public float AD2 = 15;

    //3 Cows
    public float thrust3 = 5;
    public float turnThrust3 = 1;
    public float LD3 = 2;
    public float AD3 = 12;

    //4 Cows
    public float thrust4 = 3;
    public float turnThrust4 = 1;
    public float LD4 = 1;
    public float AD4 = 5;

    //5 Cows
    public float thrust5 = 1;
    public float turnThrust5 = 1;
    public float LD5 = 0.5f;
    public float AD5 = 3;

    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
        ChangeMode();
        //immunity = true;
    }

    // Update is called once per frame
    void Update()
    {
        thrustInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");

        if (transform.position.x > screenLimit || transform.position.x < -screenLimit)
        {
            Vector2 newPos = new Vector2(-transform.position.x, transform.position.y);
            transform.position = newPos;
        }


        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            FindObjectOfType<AudioManager>().Play("engine");
        }
        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            FindObjectOfType<AudioManager>().Stop("engine");
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }

        /*
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            mode = 1;
            ChangeMode();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            mode = 2;
            ChangeMode();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            mode = 3;
            ChangeMode();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            mode = 4;
            ChangeMode();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            mode = 5;
            ChangeMode();
        }
        */
    }

    void FixedUpdate()
    {
        if(movementEnabled == true)
        {
            rb.AddRelativeForce(Vector2.up * thrustInput * thrust);
            rb.AddTorque(-turnInput * turnThrust);

            //if(thrustInput > 0)
            //{
                //immunity = false;
                //shield.SetActive(false);
            //}
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Asteroid")
        {
            //this.gameObject.SetActive(false);
            gameManager.Respawn();

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            //this.gameObject.SetActive(false);
            gameManager.Respawn();

        }
        if (collision.gameObject.tag == "EarthTrigger")
        {
            if(gameManager.hasCargo == false)
            {
                movementEnabled = false;
                cowSelector.SetActive(true);
                gameManager.hasCargo = true;
            }

        }
        else if(collision.gameObject.tag == "MoonTrigger")
        {
            if (gameManager.hasCargo == true)
            {
                gameManager.deliveredNum = gameManager.deliveredNum - mode;
                mode = 1;
                ChangeMode();
                gameManager.DeliverCargo();
            }

        }
    }

    public void ChangeMode()
    {
        
        switch (mode)
        {
            case 1:
                print("1");
                thrust = 25;
                turnThrust = turnThrust1;
                rb.angularDrag = 30;
                rb.drag = 6;
                break;

            case 2:
                print("2");
                thrust = 15;
                turnThrust = turnThrust2;
                rb.angularDrag = 23;
                rb.drag = 4;
                break;

            case 3:
                print("3");
                thrust = 10;
                turnThrust = turnThrust3;
                rb.angularDrag = 17;
                rb.drag = 3;
                break;

            case 4:
                print("4");
                thrust = 4;
                turnThrust = turnThrust4;
                rb.angularDrag = 7;
                rb.drag = 0.5f;
                break;

            case 5:
                print("5");
                thrust = 2;
                turnThrust = turnThrust5;
                rb.angularDrag = 3;
                rb.drag = 0.1f;
                break;
        }
    }

    public void RespawnEarth()
    {
        transform.position = new Vector3(0.04f, -13.14f, 0f);
        movementEnabled = false;
        cowSelector.SetActive(true);
        //immunity = true;
        thrustInput = 0;
        this.gameObject.SetActive(true);
        //shield.SetActive(true);

    }

    public void RespawnMoon()
    {
        transform.position = new Vector3(0.04f, 16.8f, 0f);
        //immunity = true;
        thrustInput = 0;
        this.gameObject.SetActive(true);
        //shield.SetActive(true);
    }

}

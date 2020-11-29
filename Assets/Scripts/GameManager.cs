using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool hasCargo = true;
    float cargoNum;
    public float deliveredNum = 7f;

    public Text cargoText;
    public Text cowsText;
    public Text deliveredText;
    public Text timerText;

    public GameObject notif;

    public GameObject winScreen;
    public GameObject failScreen;

    public GameObject playerObj;
    public Animator anim;

    public float winCond = 0; // 0 = playing, 1 = win, 2 = loss

    float startTime;   
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        deliveredText.text = deliveredNum + " Cows Left To Deliver";
        player = FindObjectOfType<Player>();
        startTime = Time.time;
        anim = FindObjectOfType<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        float t = Time.time - startTime;

        float displayTime = 100 - t;

        if (displayTime <= 0)
        {
            if(winCond == 0)
            {
                Lose();
            }
            displayTime = 0;
        }

        string seconds = (displayTime).ToString("f0");
        timerText.text = "Time Remaining: " + seconds;
    }

    public void SetCargoText()
    {
        if (hasCargo)
        {
            cargoText.text = "Has Cargo";
        }
        else
        {
            cargoText.text = "No Cargo";
        }
    }

    public void DeliverCargo()
    {
        hasCargo = false;
        if(deliveredNum <= 0)
        {
            deliveredNum = 0;
            Win();
        }
        else
        {
            StartCoroutine(TextCoroutine());
        }
        FindObjectOfType<AudioManager>().Play("delivered");

        if (deliveredNum == 1)
        {
            deliveredText.text = deliveredNum + " Cow Left To Deliver";
        }
        else
        {
            deliveredText.text = deliveredNum + " Cows Left To Deliver";
        }
        cowsText.text = "No Cows In Hold";
    }

    public void Respawn()
    {
        StartCoroutine(RespawnCoroutine());
    }

    public IEnumerator RespawnCoroutine()
    {

        FindObjectOfType<AudioManager>().Play("explosion");
        anim.SetBool("isDead", true);
        yield return new WaitForSeconds(0.2f);
        FindObjectOfType<AudioManager>().Stop("engine");
        playerObj.SetActive(false);
        anim.SetBool("isDead", false);
        yield return new WaitForSeconds(2);
        if (hasCargo)
        {
            player.RespawnEarth();
        }
        else
        {
            player.RespawnMoon();
        }
    }

    public IEnumerator TextCoroutine()
    {
        notif.SetActive(true);
        yield return new WaitForSeconds(2);
        notif.SetActive(false);
    }

    public void Win()
    {
        winCond = 1;
        print("win");
        winScreen.SetActive(true);
        FindObjectOfType<AudioManager>().Play("win");
    }

    public void Lose()
    {
        winCond = 2;
        print("lose");
        failScreen.SetActive(true);
        FindObjectOfType<AudioManager>().Play("fail");
    }

    public void NextLevel()
    {
        FindObjectOfType<AudioManager>().Play("buttonPress");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayAgain()
    {
        FindObjectOfType<AudioManager>().Play("buttonPress");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

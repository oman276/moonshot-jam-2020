using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Player player;
    public GameObject cowSelector;
    public Text cowText;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public void Select1()
    {
        FindObjectOfType<AudioManager>().Play("moo");
        player.mode = 1;
        player.cowsInHold = 1;
        player.ChangeMode();
        player.movementEnabled = true;
        cowText.text = "1 Cow in Hold";
        cowSelector.SetActive(false);
    }

    public void Select2()
    {
        FindObjectOfType<AudioManager>().Play("moo");
        player.mode = 2;
        player.cowsInHold = 2;
        player.ChangeMode();
        player.movementEnabled = true;
        cowText.text = "2 Cows in Hold";
        cowSelector.SetActive(false);
    }

    public void Select3()
    {
        FindObjectOfType<AudioManager>().Play("moo");
        player.mode = 3;
        player.cowsInHold = 3;
        player.ChangeMode();
        player.movementEnabled = true;
        cowText.text = "3 Cows in Hold";
        cowSelector.SetActive(false);

    }

    public void Select4()
    {
        FindObjectOfType<AudioManager>().Play("moo");
        player.mode = 4;
        player.cowsInHold = 4;
        player.ChangeMode();
        player.movementEnabled = true;
        cowText.text = "4 Cows in Hold";
        cowSelector.SetActive(false);
    }

    public void Select5()
    {
        FindObjectOfType<AudioManager>().Play("moo");
        player.mode = 5;
        player.cowsInHold = 5;
        player.ChangeMode();
        player.movementEnabled = true;
        cowText.text = "5 Cows in Hold";
        cowSelector.SetActive(false);
    }

}

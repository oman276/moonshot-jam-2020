using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject introScreen;
    public GameObject tutorialScreen;

    public void MenuNext()
    {
        FindObjectOfType<AudioManager>().Play("buttonPress");
        introScreen.SetActive(false);
        tutorialScreen.SetActive(true);
    }

    public void NextLevel()
    {
        FindObjectOfType<AudioManager>().Play("buttonPress");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void BackToMain()
    {
        FindObjectOfType<AudioManager>().Play("buttonPress");
        SceneManager.LoadScene(0);
    }

}

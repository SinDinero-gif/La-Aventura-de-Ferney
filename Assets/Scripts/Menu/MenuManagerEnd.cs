using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerEnd : MonoBehaviour
{
    public GameObject quitButton;

    int bookPages = 0;

    public void Start()
    {
        quitButton.SetActive(false);
    }

    private void Update()
    {
        if (bookPages >= 1)
        {
            quitButton.SetActive(true);
        }
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void BookCount()
    {
        bookPages++;
    }

}

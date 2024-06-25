using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("UI")]

    [SerializeField] Animator _menuUI;

    [SerializeField] GameObject _buttons;

    [SerializeField] Animator _render;

    [SerializeField] Animator _book;

    [SerializeField] GameObject _playButton;

    [SerializeField] GameObject _settingsPanel;


    private bool buttons;
    private int bookPage;

    private void Start()
    {
        buttons = false;
        bookPage = 0;
        _playButton.SetActive(false);
        _buttons.SetActive(false);
        _settingsPanel.SetActive(false);

    }

    

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !buttons)
        {
            _menuUI.SetInteger("State", 1);

            _render.SetInteger("State", 1);

            buttons = true;

            if (buttons)
            {
                _buttons.SetActive(true);
            }
        }


        if (bookPage >= 2)
        {
            StartCoroutine(ComicTransition2());
        }

    }

    private IEnumerator ComicTransition2()
    {
        yield return new WaitForSeconds(3.6f);

        _playButton.SetActive(true);

       

    }

    public void MenuUpdate1(int State)
    {
        _book.SetInteger("State", State);
        _buttons.SetActive(false);
        _render.SetInteger("State", State);
    }

    public void BookPage()
    {
        bookPage++;
    }

    public void SettingsWindow()
    {

        _settingsPanel.SetActive(true); 
    }

    public void GoBack()
    {
        _settingsPanel.SetActive(false);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void Play(int Scene)
    {
        SceneManager.LoadScene(Scene);
    }

}

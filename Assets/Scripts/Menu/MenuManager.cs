using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Animator _menuUI;

    [SerializeField] Animator _render;

    [SerializeField] Animator _book;

    public void MenuUpdate(int State)
    {
        _menuUI.SetInteger("State", State);
        _render.SetInteger("State", State);
        _book.SetInteger("State", State);
    }
    
}

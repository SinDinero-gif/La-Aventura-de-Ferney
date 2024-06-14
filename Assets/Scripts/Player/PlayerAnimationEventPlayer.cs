using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEventPlayer : MonoBehaviour
{
    public void Step1()
    {
        AudioManager.Instance.PlayPlayerSFX("Player Step 1");
        Debug.Log("paso 1");
    }

    public void Step2()
    {
        AudioManager.Instance.PlayPlayerSFX("Player Step 2");
        Debug.Log("paso 2");
    }

    public void Chanclazo()
    {
        AudioManager.Instance.PlayPlayerSFX("Player Special");
        Debug.Log("Special");
    }

}

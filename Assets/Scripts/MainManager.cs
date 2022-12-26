using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    [SerializeField] private MainBall mainBall;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private UIManager uIManager;



    void Start()
    {
        uIManager.KickEvent += UIManager_KickEvent;
        inputManager.ClickEvent += InputManager_ClickEvent;
    }

    private void InputManager_ClickEvent()
    {
        mainBall.StopBall();
    }

    private void UIManager_KickEvent(float kickMultiplier)
    {
        mainBall.KickBall(kickMultiplier);
    }



}

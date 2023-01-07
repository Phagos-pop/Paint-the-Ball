using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    [SerializeField] private MainBall mainBall;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private UIManager uIManager;
    [SerializeField] private BallCounter ballCounter;

    private void Start()
    {
        uIManager.KickEvent += UIManager_KickEvent;
        inputManager.ClickEvent += InputManager_ClickEvent;
        ballCounter.BallDeadEvent += BallCounter_BallDeadEvent;
    }

    private void BallCounter_BallDeadEvent(BallColorType color, int count)
    {
        uIManager.AddBallCounter(color, count);
    }

    private void InputManager_ClickEvent()
    {
        mainBall.StopBall();
    }

    private void UIManager_KickEvent(float kickMultiplier)
    {
        mainBall.KickBall(kickMultiplier);
    }

    private void OnDestroy()
    {
        uIManager.KickEvent -= UIManager_KickEvent;
        inputManager.ClickEvent -= InputManager_ClickEvent;
        ballCounter.BallDeadEvent -= BallCounter_BallDeadEvent;
    }
}

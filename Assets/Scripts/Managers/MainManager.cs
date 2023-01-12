using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    [SerializeField] private MainBall mainBall;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private UIManager uIManager;
    [SerializeField] private BallCounter ballCounter;

    private void Start()
    {
        uIManager.RestartEvent += UIManager_RestartEvent;
        uIManager.KickEvent += UIManager_KickEvent;
        inputManager.ClickEvent += InputManager_ClickEvent;
        ballCounter.BallDeadEvent += BallCounter_BallDeadEvent;
        mainBall.DeathEvent += MainBall_DeathEvent;
    }

    private void UIManager_RestartEvent()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void MainBall_DeathEvent()
    {
        uIManager.ShowRestartButton();
        mainBall = null;
    }

    private void BallCounter_BallDeadEvent(BallColorType color, int count)
    {
        uIManager.AddBallCounter(color, count);
    }

    private void InputManager_ClickEvent()
    {
        if(mainBall != null)
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


using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    [SerializeField] private MainBall mainBall;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private UIManager uIManager;
    [SerializeField] private BallCounter ballCounter;
    [SerializeField] private StarCounter starCounter;

    private void OnEnable()
    {
        uIManager.RestartEvent += UIManager_RestartEvent;
        uIManager.KickEvent += UIManager_KickEvent;
        inputManager.ClickEvent += InputManager_ClickEvent;
        ballCounter.BallDeadEvent += BallCounter_BallDeadEvent;
        mainBall.DeathEvent += MainBall_DeathEvent;
        starCounter.SetStarCountEvent += StarCounter_SetStarCountEvent;
    }

    private void OnDisable()
    {
        uIManager.RestartEvent -= UIManager_RestartEvent;
        uIManager.KickEvent -= UIManager_KickEvent;
        inputManager.ClickEvent -= InputManager_ClickEvent;
        ballCounter.BallDeadEvent -= BallCounter_BallDeadEvent;
        if (mainBall != null)
            mainBall.DeathEvent -= MainBall_DeathEvent;
        starCounter.SetStarCountEvent -= StarCounter_SetStarCountEvent;
    }

    private void StarCounter_SetStarCountEvent(int count)
    {
        uIManager.SetStarCount(count);
    }

    private void UIManager_RestartEvent()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void MainBall_DeathEvent()
    {
        uIManager.ShowRestartButton();
        mainBall.DeathEvent -= MainBall_DeathEvent;
        mainBall = null;
        uIManager.EndPowerBarAction();
    }

    private void BallCounter_BallDeadEvent(BallColorType color, int count)
    {
        //uIManager.AddBallCounter(color, count);
    }

    private void InputManager_ClickEvent()
    {
        if(mainBall != null)
            mainBall.StopBall();
    }

    private void UIManager_KickEvent(float kickMultiplier)
    {
        if (mainBall != null)
            mainBall.KickBall(kickMultiplier);
    }
}

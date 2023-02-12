using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Image powerBarImage;
    [SerializeField] private Text StarCount;
    [SerializeField] private float timeToChangePowerBar;
    [SerializeField] private GameObject PanelGameObj;

    private EventTrigger PanelTrigger;
    private PowerBarManager barManager;

    public event Action<float> KickEvent;
    public event Action RestartEvent;


    private void OnEnable()
    {
        SetUpPowerBarManager();
        restartButton.onClick.AddListener(Restart);
        SetUpEventTrigger();
    }

    private void SetUpPowerBarManager()
    {
        barManager = GetComponent<PowerBarManager>();
        barManager.KickEvent += BarManager_KickEvent;
    }

    private void BarManager_KickEvent(float obj)
    {
        KickEvent.Invoke(obj);
    }

    private void SetUpEventTrigger()
    {
        if (PanelTrigger == null)
        {
            PanelTrigger = PanelGameObj.GetComponent<EventTrigger>();
        }

        EventTrigger.Entry pointerDownEntry = new EventTrigger.Entry();
        pointerDownEntry.eventID = EventTriggerType.PointerDown;
        pointerDownEntry.callback.AddListener((data) => { barManager.StartKick((PointerEventData)data); });
        PanelTrigger.triggers.Add(pointerDownEntry);

        EventTrigger.Entry pointerUpEntry = new EventTrigger.Entry();
        pointerUpEntry.eventID = EventTriggerType.PointerUp;
        pointerUpEntry.callback.AddListener((data) => { barManager.Kick((PointerEventData)data); });
        PanelTrigger.triggers.Add(pointerUpEntry);
    }

    private void DisableEventTrigger()
    {
        PanelTrigger.triggers.Clear();
    }

    private void OnDisable()
    {
        restartButton.onClick.RemoveListener(Restart);
        DisableEventTrigger();
    }

    public void Restart()
    {
        RestartEvent?.Invoke();
    }

    public void SetStarCount(int countOfStar)
    {
        StarCount.text = "Star Left: " + countOfStar.ToString();
        if (countOfStar == 0)
        {
            ShowRestartButton();
        }
    }

    public void ShowRestartButton()
    {
        restartButton.gameObject.SetActive(true);
    }

    public void EndPowerBarAction()
    {
        DisableEventTrigger();
    }



    //public void AddBallCounter(BallColorType color, int count)
    //{
    //    [SerializeField] private Text redText;
    //    [SerializeField] private Text greenText;
    //    [SerializeField] private Text blueText;

    //    if (color == BallColorType.Red)
    //    {
    //        redText.text = count.ToString();
    //    }
    //    if (color == BallColorType.Green)
    //    {
    //        greenText.text = count.ToString();
    //    }
    //    if (color == BallColorType.Blue)
    //    {
    //        blueText.text = count.ToString();
    //    }
    //}
}

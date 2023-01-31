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
    //[SerializeField] private Text redText;
    //[SerializeField] private Text greenText;
    //[SerializeField] private Text blueText;
    [SerializeField] private Text StarCount;
    [SerializeField] private float timeToChangePowerBar;
    [SerializeField] private GameObject PanelGameObj;
    private EventTrigger PanelTrigger;

    private Coroutine powerBarCorotina;
    private bool isKick;
    private Transform panelTranform;

    public event Action<float> KickEvent;
    public event Action RestartEvent;

    private void Start()
    {
        panelTranform = PanelGameObj.GetComponent<RectTransform>();
    }

    private void Update()
    {

    }

    private void OnEnable()
    {
        restartButton.onClick.AddListener(Restart);
        SetUpEventTrigger();
    }

    private void SetUpEventTrigger()
    {
        if (PanelTrigger == null)
        {
            PanelTrigger = PanelGameObj.GetComponent<EventTrigger>();
        }

        EventTrigger.Entry pointerDownEntry = new EventTrigger.Entry();
        pointerDownEntry.eventID = EventTriggerType.PointerDown;
        pointerDownEntry.callback.AddListener((data) => { StartKick((PointerEventData)data); });
        PanelTrigger.triggers.Add(pointerDownEntry);

        EventTrigger.Entry pointerUpEntry = new EventTrigger.Entry();
        pointerUpEntry.eventID = EventTriggerType.PointerUp;
        pointerUpEntry.callback.AddListener((data) => { Kick((PointerEventData)data); });
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

    public void Kick(PointerEventData pointerEventData)
    {
        KickEvent?.Invoke(powerBarImage.fillAmount);
        StopCoroutine(powerBarCorotina);
        powerBarImage.gameObject.SetActive(false);
    }

    public void AddBallCounter(BallColorType color, int count)
    {
        //if (color == BallColorType.Red)
        //{
        //    redText.text = count.ToString();
        //}
        //if (color == BallColorType.Green)
        //{
        //    greenText.text = count.ToString();
        //}
        //if (color == BallColorType.Blue)
        //{
        //    blueText.text = count.ToString();
        //}
    }

    public void StartKick(PointerEventData pointerEventData)
    {
        isKick = true;
        powerBarCorotina = StartCoroutine(PowerBarCouratine());
    }

    private IEnumerator PowerBarCouratine()
    {
        powerBarImage.gameObject.SetActive(true);
        powerBarImage.fillAmount = 0;
        bool increase = true;
        while (isKick)
        {
            yield return new WaitForSeconds(timeToChangePowerBar);

            if (powerBarImage.fillAmount > 0.95)
            {
                increase = false;
            }
            else if (powerBarImage.fillAmount < 0.15f)
            {
                increase = true;
            }

            if (increase)
            {
                powerBarImage.fillAmount += 0.1f;
            }
            else
            {
                powerBarImage.fillAmount -= 0.1f;
            }

        }

    }
}

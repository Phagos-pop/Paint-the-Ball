using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Image powerBarImage;
    [SerializeField] private Text redText;
    [SerializeField] private Text greenText;
    [SerializeField] private Text blueText;
    [SerializeField] private float timeToChangePowerBar;

    private Coroutine powerBarCorotina;
    private bool isKick;
    private Camera mainCamera;

    public event Action<float> KickEvent;
    public event Action RestartEvent;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    public void Restart()
    {
        RestartEvent?.Invoke();
    }

    public void ShowRestartButton()
    {
        restartButton.gameObject.SetActive(true);
    }

    public void Kick()
    {
        KickEvent?.Invoke(powerBarImage.fillAmount);
        StopCoroutine(powerBarCorotina);
        powerBarImage.gameObject.SetActive(false);
    }

    public void AddBallCounter(BallColorType color, int count)
    {
        if (color == BallColorType.Red)
        {
            redText.text = count.ToString();
        }
        if (color == BallColorType.Green)
        {
            greenText.text = count.ToString();
        }
        if (color == BallColorType.Blue)
        {
            blueText.text = count.ToString();
        }
    }

    public void StartKick()
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

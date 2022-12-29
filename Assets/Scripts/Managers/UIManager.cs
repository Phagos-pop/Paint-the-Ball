using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button kickButton;
    [SerializeField] private Image powerBarImage;
    [SerializeField] private Text redText;
    [SerializeField] private Text greenText;
    [SerializeField] private Text yellowText;

    private Coroutine powerBarCorotina;
    private bool isKick;

    public event Action<float> KickEvent;

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
        if (color == BallColorType.Yellow)
        {
            yellowText.text = count.ToString();
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
            yield return new WaitForSeconds(0.1f);

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

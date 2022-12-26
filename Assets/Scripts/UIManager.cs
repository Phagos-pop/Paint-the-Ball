using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button kickButton;
    [SerializeField] private Image powerBarImage;

    private Coroutine powerBarCorotina;
    private bool isKick;

    public event Action<float> KickEvent;

    public void Kick()
    {
        KickEvent?.Invoke(powerBarImage.fillAmount);
        StopCoroutine(powerBarCorotina);
        powerBarImage.gameObject.SetActive(false);
    }

    public void StartKick()
    {
        isKick = true;
        powerBarCorotina = StartCoroutine(PowerBarCouratine());
    }

    private IEnumerator PowerBarCouratine()
    {
        powerBarImage.gameObject.SetActive(true);
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

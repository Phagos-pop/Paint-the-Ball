using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PowerBarManager : MonoBehaviour
{
    [SerializeField] private Image powerBarImage;
    [SerializeField] private float timeToChangePowerBar;

    public event Action<float> KickEvent;

    private Coroutine powerBarCorotina;
    private bool isKick;

    public void StartKick(PointerEventData pointerEventData)
    {
        isKick = true;
        powerBarCorotina = StartCoroutine(PowerBarCouratine());
    }

    public void Kick(PointerEventData pointerEventData)
    {
        KickEvent?.Invoke(powerBarImage.fillAmount);
        StopCoroutine(powerBarCorotina);
        powerBarImage.gameObject.SetActive(false);
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

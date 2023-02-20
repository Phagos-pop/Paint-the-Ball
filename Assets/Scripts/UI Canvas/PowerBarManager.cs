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
    [SerializeField] private float multiplaer = 2.5f;

    public event Action<float> KickEvent;
    public event Action StartKickEvent;
    public event Action CancelKickEvent;

    //private Coroutine powerBarCorotina;
    private bool isKick;
    //private Camera mainCamera;
    float FirstClickPos;
    //Vector2 DragClickPos;

    public void Start()
    {
        //mainCamera = Camera.main;
    }

    public void StartKick(PointerEventData pointerEventData)
    {
        if (isKick)
        {
            return;
        }
        StartKickEvent?.Invoke();
        FirstClickPos = Input.mousePosition.y;
        isKick = true;
        powerBarImage.gameObject.SetActive(true);
        powerBarImage.fillAmount = 0;
        //powerBarCorotina = StartCoroutine(PowerBarCouratine());
    }

    public void OnKick(PointerEventData pointerEventData)
    {
        float Mag = (Math.Abs(FirstClickPos - Input.mousePosition.y)/Screen.height) * multiplaer;
        if (Mag < 0.2)
        {
            powerBarImage.gameObject.SetActive(false);
            return;
        }
        else
        {
            powerBarImage.gameObject.SetActive(true);
        }
        powerBarImage.fillAmount = Mag;
        //Debug.Log(powerBarImage.fillAmount + "  " + Mag + "  " + FirstClickPos + "   " + mainCamera.ScreenToWorldPoint(Input.mousePosition));
    }

    public void Kick(PointerEventData pointerEventData)
    {
        isKick = false;
        if (powerBarImage.fillAmount > 0.2)
        {
            KickEvent?.Invoke(powerBarImage.fillAmount);
            //Debug.Log($"fillAmount {powerBarImage.fillAmount}");
            powerBarImage.fillAmount = 0;
        }
        else
        {
            CancelKickEvent?.Invoke();
        }
        //StopCoroutine(powerBarCorotina);
        powerBarImage.gameObject.SetActive(false);
    }



    //private IEnumerator PowerBarCouratine()
    //{
    //    powerBarImage.gameObject.SetActive(true);
    //    powerBarImage.fillAmount = 0;

    //    while (true)
    //    {

    //        yield return new WaitForSeconds(timeToChangePowerBar);
    //    }
    //    bool increase = true;
    //    while (isKick)
    //    {
    //        yield return new WaitForSeconds(timeToChangePowerBar);

    //        if (powerBarImage.fillAmount > 0.95)
    //        {
    //            increase = false;
    //        }
    //        else if (powerBarImage.fillAmount < 0.15f)
    //        {
    //            increase = true;
    //        }

    //        if (increase)
    //        {
    //            powerBarImage.fillAmount += 0.1f;
    //        }
    //        else
    //        {
    //            powerBarImage.fillAmount -= 0.1f;
    //        }

    //    }

    //}

}

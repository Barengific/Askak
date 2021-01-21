using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour{
    // Start is called before the first frame update
    [SerializeField]
    private int maxStamina = 100;

    public int currentStamina;

    public Toggle toggle;

    public event Action<float> OnStaminaPctChanged = delegate{ };

    private void OnEnable()
    {
        currentStamina = maxStamina;
    }

    public void ModifyStamina(int amount)
    {
        currentStamina += amount;

        float currentStaminaPct = (float)currentStamina / (float)maxStamina;
        OnStaminaPctChanged(currentStaminaPct);
    }

    //private IEnumerator HandleStamina()
    //{
    //    //fore.fillAmount = pct;
    //    //StartCoroutine(ChangeToPct(pct));
    //    while (toggle.isOn)
    //    {
    //        //if (toggle.isOn)    {
    //            ModifyStamina(-10);
    //            yield return new WaitForSeconds(2);
    //    //}
    //    }

    //}
    void Start() {
        //StartCoroutine(HandleStamina());

    }
    // Update is called once per frame
    private void Update()    {
        //StartCoroutine(HandleStamina(1f));
        //HandleStamina(1f);

        if (toggle.isOn)       {
            ModifyStamina(-10);
            //Debug.Log("tooge on");
            
        }
        Debug.Log(toggle.isOn);
    }
}

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
    [SerializeField]
    private Toggle toggle;
    public event Action<float> OnStaminaPctChanged = delegate{ };

    private void OnEnable()
    {
        currentStamina = maxStamina;
    }

    public void ModifyStamina(int amount)
    {
        currentStamina += amount/10;

        float currentStaminaPct = (float)currentStamina / (float)maxStamina;
        OnStaminaPctChanged(currentStaminaPct);
    }
    // Update is called once per frame
    private void Update()    {
        if (toggle.isOn == true)
        {
            ModifyStamina(-10);
            //Debug.Log("tooge on");

        }
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    ModifyStamina(-10);
        //}
    }



}

﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour{
    // Start is called before the first frame update
    [SerializeField]
    private int maxHealth = 100;

    public int currentHealth;

    public event Action<float> OnHealthPctChanged = delegate{ };

    private void OnEnable()
    {
        currentHealth = maxHealth;
    }

    public void ModifyHealth(int amount)
    {
        currentHealth += amount;

        float currentHealthPct = (float)currentHealth / (float)maxHealth;
        OnHealthPctChanged(currentHealthPct);
    }

    // Update is called once per frame
    private void Update()    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ModifyHealth(-10);
        }
            
    }
}

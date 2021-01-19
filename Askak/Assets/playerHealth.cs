using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour{
    // Start is called before the first frame update

    public int maxHealth = 100;

    public int currentHealth;

    public event Action<float> onHealthChanged = delegate
    {

    };

    private void OnEnable()
    {
        currentHealth = maxHealth;
    }

    public void ModifyHealth(int amount)
    {
        currentHealth += amount;

        float currentHealthPct = (float)currentHealth / (float)maxHealth;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            ModifyHealth(-10);
    }
}

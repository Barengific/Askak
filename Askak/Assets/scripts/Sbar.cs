using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Sbar : MonoBehaviour
{
    public Slider sbar;

    private int maxS = 100;
    private int currentS;

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;

    public static Sbar instance;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentS = maxS;
        sbar.maxValue = maxS;
        sbar.value = maxS;        
    }

    public void UseStamina(int amount)
    {
        if(currentS - amount >= 0)
        {
            currentS -= amount;
            sbar.value = currentS;

            if (regen != null)
            {
                StopCoroutine(regen);
            }
            regen = StartCoroutine(Sregen());
        }
        else
        {
            Debug.Log("not even stamina");
        }
    }
    private IEnumerator Sregen()
    {
        yield return new WaitForSeconds(2);
        while(currentS < maxS)
        {
            currentS += maxS / 100;
            sbar.value = currentS;
            yield return regenTick;
        }
    }

}

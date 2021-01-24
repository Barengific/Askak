using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Hbar : MonoBehaviour
{
    public Slider hbar;

    private int maxH = 100;
    private int currentH;

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;

    public static Hbar instance;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentH = maxH;
        hbar.maxValue = maxH;
        hbar.value = maxH;
    }

    public void UseHealth(int amount)
    {
        if (currentH - amount >= 0)
        {
            currentH -= amount;
            hbar.value = currentH;

            if (regen != null)
            {
                StopCoroutine(regen);
            }
            regen = StartCoroutine(Hregen());
        }
        else
        {
            Debug.Log("not even health");
        }
    }
    private IEnumerator Hregen()
    {
        yield return new WaitForSeconds(2);
        while (currentH < maxH)
        {
            currentH += maxH / 100;
            hbar.value = currentH;
            yield return regenTick;
        }
    }
}

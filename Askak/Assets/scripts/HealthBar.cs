using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Image foregroundImage;
    [SerializeField]
    private float updateSpeedsSeconds = 0.5f;

    private void Awake()
    {
        //foregroundImage = GetComponent<Image>();
        GetComponentInParent<Health>().OnHealthPctChanged += HandleHealthChanged;
    }

    private void HandleHealthChanged(float pct)
    {
        //fore.fillAmount = pct;
        StartCoroutine(ChangeToPct(pct));
    }

    private IEnumerator ChangeToPct(float pct)
    {
        float preChangepct = foregroundImage.fillAmount;
        float elapsed = 0f;
        while(elapsed < updateSpeedsSeconds){
            elapsed += Time.deltaTime;
            foregroundImage.fillAmount = Mathf.Lerp(preChangepct, pct, elapsed / updateSpeedsSeconds);
            yield return null;
        }
        foregroundImage.fillAmount = pct;
    }

    private void LateUpdate()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
    }
}

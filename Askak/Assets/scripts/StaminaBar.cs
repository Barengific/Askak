using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Image StaminaImage;
    [SerializeField]
    private float updateSpeedsSeconds = 5f;

    private void Awake()
    {
        //foregroundImage = GetComponent<Image>();
        GetComponentInParent<Stamina>().OnStaminaPctChanged += HandleStaminaChanged;
    }

    private void HandleStaminaChanged(float pct)
    {
        //fore.fillAmount = pct;
        StartCoroutine(ChangeToPct(pct));
    }

    private IEnumerator ChangeToPct(float pct)
    {
        float preChangepct = StaminaImage.fillAmount;
        float elapsed = 0f;
        while(elapsed < updateSpeedsSeconds){
            elapsed += Time.deltaTime;
            StaminaImage.fillAmount = Mathf.Lerp(preChangepct, pct, elapsed / updateSpeedsSeconds);
            yield return null;
            yield return new WaitForSeconds(2);
        }
        StaminaImage.fillAmount = pct;
    }

    private void LateUpdate()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
    }
}

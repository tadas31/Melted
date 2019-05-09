using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField]
    private Image foregroundImg;
    [SerializeField]
    private float updateSpeedSeconds = 0.5f;

    private void Start()
    {
        GetComponentInParent<enemy>().OnHealthPctChanged += HandleHealthChanged;
    }

    private void HandleHealthChanged(float pct, float speed)
    {
        StartCoroutine(ChangeToPct(pct, speed));
    }

    private IEnumerator ChangeToPct(float pct, float speed)
    {
        float preChangePct = foregroundImg.fillAmount;
        float elapsed = 0f;

        if (speed != updateSpeedSeconds)
            updateSpeedSeconds = speed;
        while (elapsed < updateSpeedSeconds)
        {
            elapsed += Time.deltaTime;
            foregroundImg.fillAmount = Mathf.Lerp(preChangePct, pct, elapsed / updateSpeedSeconds);
            yield return null;
        }

        foregroundImg.fillAmount = pct;
    }

    private void LateUpdate()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
    }
}

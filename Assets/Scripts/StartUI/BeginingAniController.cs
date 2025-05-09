using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BeginingAniController : MonoBehaviour
{
    public Image beginImage;
    public GameObject beginUI;
    public TextMeshProUGUI beginText1;
    public TextMeshProUGUI beginText2;
    public TextMeshProUGUI beginText3;
    public float animationDuration = 1.0f; // Duration of the animation in seconds

    private IEnumerator AnimateScaleDown()
    {
        Vector3 originalScale = beginImage.transform.localScale;
        Vector3 targetScale = new Vector3(1f, 1f, 1f);
        Vector3 targetPosition = new Vector3(0, 0, 0);

        float elapsedTime = 0f;
        while (elapsedTime < animationDuration)
        {
            beginImage.transform.localScale = Vector3.Lerp(originalScale, targetScale, elapsedTime / animationDuration);
            beginImage.rectTransform.anchoredPosition = Vector3.Lerp(originalScale, targetPosition, elapsedTime / animationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        beginImage.transform.localScale = targetScale;
        beginImage.rectTransform.anchoredPosition = targetPosition;
    }
    public void ScaleUp()
    {
        beginImage.transform.localScale = beginImage.transform.localScale * 1.4f;
        beginImage.rectTransform.anchoredPosition = new Vector3(0, 100, 0);
    }
    public void ScaleDown()
    {
        StartCoroutine(AnimateScaleDown());
    }
    IEnumerator ShowTextGradient(TextMeshProUGUI text)
    {
        float elapsedTime = 0f;
        Color startColor = text.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 1f); 

        while (elapsedTime < animationDuration)
        {
            text.color = Color.Lerp(startColor, targetColor, elapsedTime / animationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        text.color = targetColor; 
    }
    IEnumerator FinishBeginingAni()
    {
        float elapsedTime = 0f;
        Color startColor = beginImage.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 0f);
        while (elapsedTime < animationDuration)
        {
            beginImage.color = Color.Lerp(startColor, targetColor, elapsedTime / animationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        beginImage.color = targetColor;
        beginUI.SetActive(false);
    }
    
    public void ShowText1()
    {
        beginText1.gameObject.SetActive(true);
        StartCoroutine(ShowTextGradient(beginText1));
    }
    public void HideText1()
    {
        beginText1.gameObject.SetActive(false);
    }
    public void ShowText2()
    {
        beginText2.gameObject.SetActive(true);
        StartCoroutine(ShowTextGradient(beginText2));
    }
    public void HideText2()
    {
        beginText2.gameObject.SetActive(false);
    }
    public void ShowText3()
    {
        beginText3.gameObject.SetActive(true);
        StartCoroutine(ShowTextGradient(beginText3));
    }
    public void HideText3()
    {
        beginText3.gameObject.SetActive(false);
    }
    public void AniFinish()
    {
        StartCoroutine(FinishBeginingAni());
    }
}

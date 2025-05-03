using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingPanelController : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI text;
    void Awake()
    {
        Time.timeScale = 1;
    }
    public void LoadScene(string sceneName)
    {
        StartCoroutine(StartLoadScene(sceneName));
        Debug.Log(Time.timeScale);
    }
    private IEnumerator StartLoadScene(string sceneName)
    {
        yield return new WaitForEndOfFrame();
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;
        while (!operation.isDone)
        {
            SetSliderRate(operation.progress);
            if (operation.progress >= 0.9f)
            {
                SetSliderDone();
                #if UNITY_ANDROID || UNITY_IOS
                if (Input.touchCount > 0&& Input.GetTouch(0).phase==UnityEngine.TouchPhase.Began) operation.allowSceneActivation = true;
                #endif
                if (Keyboard.current.anyKey.isPressed) operation.allowSceneActivation = true;
            }
            yield return null;
        }

    }
    public void SetSliderRate(float rate = 0)
    {
        slider.value = rate;
        text.text = (rate * 100).ToString() + "%";
    }
    public void SetSliderDone()
    {
        slider.value = 1;
        text.text = "press any key";
        //StartCoroutine(WaitForPress());
    }
   
}

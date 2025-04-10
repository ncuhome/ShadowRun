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
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public IEnumerator LoadScene(string sceneName)
    {
        gameObject.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;
        while (!operation.isDone)
        {
            SetSliderRate(operation.progress);
            if (operation.progress >= 0.9f)
            {
                SetSliderDone();
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

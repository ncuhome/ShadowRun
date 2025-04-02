using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingPanelController : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI text;

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

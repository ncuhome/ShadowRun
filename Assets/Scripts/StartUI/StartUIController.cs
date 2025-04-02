using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class StartUIController : MonoBehaviour
{
    public GameObject loadingPanel;
    private VisualElement root;
    private Button startBtn;
    private Button settingBtn;
    private Button exitBtn;
    private LoadingPanelController loading;
    private void Awake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        startBtn = root.Q<Button>(name: "Start");
        settingBtn = root.Q<Button>(name: "Setting");
        exitBtn = root.Q<Button>(name: "Exit");
        loading = loadingPanel.GetComponent<LoadingPanelController>();
    }

    private void OnEnable()
    {
        startBtn.clicked += OnStartBtn;
    }

    void OnStartBtn()
    {
        StartCoroutine(StartNewGame());
    }

    IEnumerator StartNewGame()
    {
        loadingPanel.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync("Game Level2");
        operation.allowSceneActivation=false;
        while (!operation.isDone)
        {
            loading.SetSliderRate(operation.progress);
            if (operation.progress >= 0.9f)
            {
                loading.SetSliderDone();
                if (Keyboard.current.anyKey.isPressed) operation.allowSceneActivation = true;
            }
            yield return null;
        }

    }
}

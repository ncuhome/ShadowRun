using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class StartUIController : MonoBehaviour
{
    private GameObject loadingPanel;
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
        loadingPanel = GameObject.FindGameObjectWithTag("LoadingPanel");
        loading = loadingPanel.GetComponent<LoadingPanelController>();     
    }

    private void OnEnable()
    {
        startBtn.clicked += OnStartBtn;
    }

    void OnStartBtn()
    {
        StartCoroutine(loading.LoadScene("Game Level2"));
    }
}

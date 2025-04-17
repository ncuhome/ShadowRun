using UnityEngine;
using UnityEngine.UIElements;

public class StartUIController : MonoBehaviour
{
    private GameObject loadingPanel;
    private VisualElement root;
    private Button startBtn;
    private Button settingBtn;
    private Button exitBtn;
    private void Awake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        startBtn = root.Q<Button>(name: "Start");
        settingBtn = root.Q<Button>(name: "Setting");
        exitBtn = root.Q<Button>(name: "Exit");
        loadingPanel = GameObject.FindGameObjectWithTag("LoadingPanel");     
    }

    private void OnEnable()
    {
        startBtn.clicked += OnStartBtn;
    }
    private void OnDisable()
    {
        startBtn.clicked -= OnStartBtn;
    }

    void OnStartBtn()
    {
        LoadManager.LoadingScene("Game Level2");
    }
}

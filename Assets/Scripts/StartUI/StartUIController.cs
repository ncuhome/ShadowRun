using UnityEngine;
using UnityEngine.UIElements;

public class StartUIController : MonoBehaviour
{
    private VisualElement root;
    private Button startBtn;
    private Button settingBtn;
    private Button exitBtn;
    public GameObject aboutPanel;
    private void Awake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        startBtn = root.Q<Button>(name: "Start");
        settingBtn = root.Q<Button>(name: "Setting");
        exitBtn = root.Q<Button>(name: "Exit");   
    }

    private void OnEnable()
    {
        startBtn.clicked += OnStartBtn;
        settingBtn.clicked += OnAboutBtn;
        exitBtn.clicked += OnExitBtn;
    }
    private void OnDisable()
    {
        startBtn.clicked -= OnStartBtn;
        settingBtn.clicked -= OnAboutBtn;
        exitBtn.clicked -= OnExitBtn;
    }

    void OnStartBtn()
    {
        if(PlayerPrefs.GetInt("Noviced")==0)
        {
            LoadManager.LoadingScene(SceneEnum.Novice);
        }
        else
        {
            LoadManager.LoadingScene(SceneEnum.Game);
        }
    }
    void OnExitBtn()
    {
        Application.Quit();
    }
    void OnAboutBtn()
    {
        aboutPanel.SetActive(true);
    }
    public void OnCloseAboutPanel()
    {
        aboutPanel.SetActive(false);
    }
}

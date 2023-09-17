using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject guideTab;

    void Awake()
    {
        guideTab = GameObject.Find("GuideTab");
    }

    void Start()
    {
        guideTab.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            CloseGuideTab();
        }
    }

    public void StatGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenGuideTab()
    {
        guideTab.SetActive(true);
    }

    public void CloseGuideTab()
    {
        guideTab.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

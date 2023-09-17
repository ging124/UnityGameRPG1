using UnityEngine;
using TMPro;

public class MenuIngame : MonoBehaviour
{
    [SerializeField]
    private GameObject tabStats;
    [SerializeField]
    private GameObject tabSkills;
    [SerializeField]
    private GameObject menu;
    [SerializeField]
    private GameObject gameOverMenu;
    [SerializeField]
    private TMP_Text timeSurvival;
    [SerializeField]
    private TMP_Text yourLevel;
    [SerializeField]
    private bool inStatsTab = false;
    [SerializeField]
    private bool inSkillsTab = false;
    [SerializeField]
    private bool inMenu = false;
    private bool isMenuOpen = false;
    [SerializeField]
    private bool isOpen = false;

    static public MenuIngame instance;

    void Awake()
    {
        MenuIngame.instance = this;
        tabStats = GameObject.Find("Stats_Tab");
        tabSkills = GameObject.Find("Skills_Tab");
        menu = GameObject.Find("Menu");
        gameOverMenu = GameObject.Find("GameOverMenu");
        timeSurvival = GameObject.Find("TimeSurvival_Text").GetComponent<TMP_Text>();
        yourLevel = GameObject.Find("YourLevel_Text").GetComponent<TMP_Text>();
    }

    void Start()
    {
        tabStats.SetActive(false);
        tabSkills.SetActive(false);
        menu.SetActive(false);
        gameOverMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && inSkillsTab == false && inMenu == false)
        {
            StatsTab();
        }

        if (Input.GetKeyDown(KeyCode.U) && inStatsTab == false && inMenu == false)
        {
            SkillTab();
        }

        if(Input.GetKeyDown(KeyCode.Escape) && inSkillsTab == false && inStatsTab == false)
        {
            MenuTab();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && inStatsTab == true)
        {
            ExitStatsTab();
        }
        if (Input.GetKeyDown(KeyCode.Escape) && inSkillsTab == true)
        {
            ExitSkillsTab();
        }
    }

    public void StatsTab()
    {
        inStatsTab = true;
        if (isOpen == false)
        {
            EnterTab(tabStats);
        }
        else
        {
            ExitTab(tabStats);
            inStatsTab = false;
        }
    }

    public void ExitStatsTab()
    {
        ExitTab(tabStats);
        inStatsTab = false;
    }

    public void SkillTab()
    {
        inSkillsTab = true;
        if (isOpen == false)
        {
            EnterTab(tabSkills);
        }
        else
        {
            ExitTab(tabSkills);
            inSkillsTab = false;
        }
    }

    public void ExitSkillsTab()
    {
        ExitTab(tabSkills);
        inSkillsTab = false;
    }

    public void MenuTab()
    {
        inMenu = true;
        if (inStatsTab == true || inSkillsTab == true)
        {
            if (isMenuOpen == false)
            {
                menu.SetActive(true);
                isMenuOpen = true;
            }
            else
            {
                menu.SetActive(false);
                isMenuOpen = false;
                inMenu = false;
            }
        }
        else
        {
            if (isOpen == false)
            {
                EnterTab(menu);
            }
            else
            {
                ExitTab(menu);
                inMenu = false;
            }
        }
    }

    void EnterTab(GameObject tab)
    {
        tab.SetActive(true);
        isOpen = true;
        GameManager.instance.PauseGame();
    }

    void ExitTab(GameObject tab)
    {
        tab.SetActive(false);
        isOpen = false;
        GameManager.instance.ContinueGame();
    }

    public void GameOverMenuOn()
    {
        tabStats.SetActive(false);
        tabSkills.SetActive(false);
        menu.SetActive(false);
        gameOverMenu.SetActive(true);
        GameManager.instance.PauseGame();
        timeSurvival.text = PlayingClock.instance.timeText.text;
        yourLevel.text = PlayerController.instance.playerLvUp.level.ToString();
    }
}

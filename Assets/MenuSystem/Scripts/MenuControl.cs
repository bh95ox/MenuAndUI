using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    [SerializeField] string playScene = "PlaySandBoxScene";
    [SerializeField] string mainMenuScene = "StartScene";

    [Tooltip("Drag in an options menu panel, if one exists")]
    [SerializeField] GameObject optionalMenuPanel;

    [Tooltip("Drag in an pause menu panel, if one exists")]
    [SerializeField] GameObject pauseMenuPanel;

    [SerializeField] bool IsPauseMenuAvailable = false;
    [HideInInspector] public static bool IsGamePaused = false;

    public void StartGame()
    {
        Cursor.visible = false;
        SceneManager.LoadScene(playScene);

    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
    
    public void Setting()
    {
        Debug.Log(" Coming Soon");
    }

    public void OptionsMenuClose()
    {
        optionalMenuPanel.SetActive(false);
    }


    public void OptionsMenuOpen()
    {
        optionalMenuPanel.SetActive(true);
    }

    void changeCursor()
    {


    }

    void Update()
    {
        PauseMenu();
    }

    void PauseMenu()
    {
        if (IsPauseMenuAvailable)
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                if (IsGamePaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }

        }
    }

    public void Resume()
    {
        Cursor.visible = false;
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        IsGamePaused = false;
    }

    public void ReturnToMainMenu()
    {
        Resume();
        Cursor.visible = true;
        SceneManager.LoadScene(mainMenuScene);
    }

    void Pause()
    {
        Cursor.visible = true;
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
        IsGamePaused= true;
    }

    // Start is called before the first frame update
    void Start()
    {
        changeCursor();
    }

    // Update is called once per frame
    
}

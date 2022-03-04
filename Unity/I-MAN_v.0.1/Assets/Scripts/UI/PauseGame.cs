using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PauseGame : MonoBehaviour
{

    public GameObject pauseMenuScreen;
    /*  public bool isPaused;
      public PlayerInput playerInput;
      [SerializeField] private GameObject pauseMenuPanel;


      public void TogglePause(InputAction.CallbackContext context)
      {
          if (!pauseMenuPanel.activeInHierarchy)
          {
              Time.timeScale = 0;
              playerInput.SwitchCurrentActionMap("UI");
              pauseMenuPanel.SetActive(true);
              InputSystem.settings.updateMode = InputSettings.UpdateMode.ProcessEventsInDynamicUpdate;
              Debug.Log("Game Paused");
              //isPaused = true;
          }

          else 
          {
              Time.timeScale = 1;
              playerInput.SwitchCurrentActionMap("Player");
              pauseMenuPanel.SetActive(false);
              InputSystem.settings.updateMode = InputSettings.UpdateMode.ProcessEventsInFixedUpdate;
              Debug.Log("Game Unpaused");

          }

      }

      */

    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenuScreen.SetActive(true);
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenuScreen.SetActive(false);

    }
    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
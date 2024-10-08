 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject SettingsMenu;

    public Slider FirstSliderSelected;
    public Button FirstButtonSelected;

    // Deactivates Main Menu and activates Settings Menu.
    public void EnterSettingsUI()
    {
        MainMenu.SetActive(false);
        SettingsMenu.SetActive(true);
    }

    // Selects Settings slider UI.
    public void SelectFirstSlider()
    {
        if (FirstSliderSelected != null && EventSystem.current != null)
        {
            EventSystem.current.SetSelectedGameObject(FirstSliderSelected.gameObject);
        }
    }

    // Selects Main Menu button UI.
    public void SelectFirstButton()
    {
        if (FirstButtonSelected != null && EventSystem.current != null)
        {
            EventSystem.current.SetSelectedGameObject(FirstButtonSelected.gameObject);
        }
    }

    // Reactivates Main Menu and deactivates Settings Menu.
    public void ExitSettingsUI()
    {
        SettingsMenu.SetActive(false);
        MainMenu.SetActive(true);
    }
}

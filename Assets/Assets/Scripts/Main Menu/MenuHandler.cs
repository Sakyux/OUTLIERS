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

    public void EnterSettingsUI()
    {
        MainMenu.SetActive(false);
        SettingsMenu.SetActive(true);
    }

    public void SelectFirstSlider()
    {
        if (FirstSliderSelected != null && EventSystem.current != null)
        {
            EventSystem.current.SetSelectedGameObject(FirstSliderSelected.gameObject);
        }
    }

    public void SelectFirstButton()
    {
        if (FirstButtonSelected != null && EventSystem.current != null)
        {
            EventSystem.current.SetSelectedGameObject(FirstButtonSelected.gameObject);
        }
    }

    public void ExitSettingsUI()
    {
        SettingsMenu.SetActive(false);
        MainMenu.SetActive(true);
    }
}

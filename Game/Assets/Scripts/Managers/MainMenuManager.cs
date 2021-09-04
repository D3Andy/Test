using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public GameObject campaignButton;
    public GameObject gearButton;
    public GameObject optionButton;
    public GameObject controlsButton;

    public GameObject campaignPanel;
    public GameObject gearPanel;
    public GameObject optionPanel;
    public GameObject controlsPanel;

    [SerializeField]
    private GameObject selectedButton;

    [SerializeField]
    private GameObject selectedPanel;

    private ColorBlock buttonsDefaultColors;
    private ColorBlock buttonSelectedColors;
    // Start is called before the first frame update
    void Start()
    {
        selectedPanel = campaignPanel;
        selectedButton = campaignButton;

        //store & change buttons colors
        buttonsDefaultColors = selectedButton.GetComponent<Button>().colors;
        buttonSelectedColors = buttonsDefaultColors;
        buttonSelectedColors.normalColor = buttonSelectedColors.selectedColor;
        selectedButton.GetComponent<Button>().colors = buttonSelectedColors;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OpenPanel(GameObject panelToOpen)
    {
        if(panelToOpen != selectedPanel)
        {
            panelToOpen.SetActive(true);
            selectedPanel.SetActive(false);
            selectedPanel = panelToOpen;
            selectedButton.GetComponent<Button>().colors = buttonsDefaultColors;
            if (panelToOpen.name.Contains("Campaign"))
            {
                selectedButton = campaignButton;
            }
            else if (panelToOpen.name.Contains("Gear"))
            {
                selectedButton = gearButton;
            }
            else if (panelToOpen.name.Contains("Options"))
            {
                selectedButton = optionButton;
            }
            else if (panelToOpen.name.Contains("Controls"))
            {
                selectedButton = controlsButton;
            }
            selectedButton.GetComponent<Button>().colors = buttonSelectedColors;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    public GameObject qualityPreset;
    private int qualityPresetIndex;

    public TMP_Text qualityText;
    public TMP_Text antiAliasingText;
    public TMP_Text shadowQualityText;
    public TMP_Text textureQualityText;

    private List<Resolution> screenResolutions;



    // Start is called before the first frame update
    void Start()
    {
        screenResolutions = new List<Resolution>();
        int index = QualitySettings.GetQualityLevel();
        qualityPresetIndex = index;
        SetQualityText();

        if (qualityPresetIndex == 0)
        {
            qualityPreset.transform.Find("ArrowLeft").gameObject.SetActive(false);

        }
        else if (qualityPresetIndex == QualitySettings.names.Length - 1)
        {
            qualityPreset.transform.Find("ArrowRight").gameObject.SetActive(false);
        }

        Resolution[] screenRes = Screen.resolutions;
        float aspectRatio = 16.0f / 9.0f;
        float resolutionAspectRatio;
        foreach (Resolution resolution in screenRes)
        {
            resolutionAspectRatio = resolution.width / (float)resolution.height;

            if (Mathf.Approximately(aspectRatio, resolutionAspectRatio))
            {
                if (!screenResolutions.Contains(resolution))
                {
                    screenResolutions.Add(resolution);
                }
            }
        }
        foreach (Resolution resolution in screenResolutions)
        {
            Debug.Log(resolution);
        }

    }

    private void SetQualityText()
    {
        qualityText.text = QualitySettings.names[qualityPresetIndex];

        int aaIndex = QualitySettings.antiAliasing;
        if (aaIndex != 0)
        {
            antiAliasingText.text = aaIndex + "x Multi Sampling";
        }
        else
        {
            antiAliasingText.text = "Disabled";
        }

        shadowQualityText.text = QualitySettings.shadowResolution.ToString();
        textureQualityText.text = GetTextureQualityTOString();
    }

    public void SetBetterQuality()
    {
        qualityPresetIndex++;
        QualitySettings.SetQualityLevel(qualityPresetIndex);
        SetQualityText();
        if (qualityPresetIndex == 1)
        {
            qualityPreset.transform.Find("ArrowLeft").gameObject.SetActive(true);

        }
        else if(qualityPresetIndex == QualitySettings.names.Length - 1)
        {
            qualityPreset.transform.Find("ArrowRight").gameObject.SetActive(false);
        }
    }

    public void SetLowerQuality()
    {
        qualityPresetIndex--;
        QualitySettings.SetQualityLevel(qualityPresetIndex);
        SetQualityText();
        if (qualityPresetIndex == 0)
        {
            qualityPreset.transform.Find("ArrowLeft").gameObject.SetActive(false);

        }
        else if (qualityPresetIndex < QualitySettings.names.Length - 1)
        {
            qualityPreset.transform.Find("ArrowRight").gameObject.SetActive(true);
        }
    }

    private string GetTextureQualityTOString()
    {
        switch (qualityPresetIndex)
        {
            case 0:
            case 1:
                return "Low";
            case 2:
                return "Medium";
            case 3:
            case 4:
            case 5:
                return "High";
            default:
                return "High";
        }
    }
}

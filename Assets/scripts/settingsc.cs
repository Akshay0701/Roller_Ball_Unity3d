using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class settingsc : MonoBehaviour {
    public AudioMixer audiomixer;
    public Dropdown resulotiondropdown;
    Resolution[] resolution;

    public void start()
    {
        resolution = Screen.resolutions;
        resulotiondropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentresolutionindex = 0;
        for(int i = 0; i < resolution.Length; i++)
        {
            string option = resolution[i].width + "x" + resolution[i].height;
            options.Add(option);
            if(resolution[i].width==Screen.currentResolution.width && resolution[i].height == Screen.currentResolution.height)
            {
                currentresolutionindex = i;
            }
        }
        resulotiondropdown.AddOptions(options);
        resulotiondropdown.value = currentresolutionindex;
        resulotiondropdown.RefreshShownValue();
    }

    public void Setresolution(int resolutionindex)
    {
        Resolution resolutions1 = resolution[resolutionindex];
        Screen.SetResolution(resolutions1.width, resolutions1.height, Screen.fullScreen);
    }

        public void SetVolume(float volume)
    {
        audiomixer.SetFloat("volume",volume);
    }
    public void SetQuailty(int qualityindex)
    {
        QualitySettings.SetQualityLevel(qualityindex);
    }
}

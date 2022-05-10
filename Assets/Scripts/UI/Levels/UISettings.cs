using System;
using Disablers;
using Services.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Utility;
using Zenject;

namespace UI.Levels
{
    public class UISettings : MonoBehaviour
    {
        [SerializeField] private Slider slider;
        [SerializeField] private Button backButton;
        [SerializeField] private CanvasSwitcher canvasSwitcher;
        [SerializeField] private CanvasDisabler mainMenuDisabler;
        private IAudioService audioService;
        
        [Inject]
        private void Construct(IAudioService audioService)
        {
            this.audioService = audioService;
        }

        private void Start()
        {
            slider.onValueChanged.AddListener((val) =>
            {
                audioService.SetVolume(val);
            });
            
            backButton.onClick.AddListener(() =>
            {
                canvasSwitcher.DelayedOpenTable(mainMenuDisabler);
            });
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


public class GameEndPanel : Panel
{
    public Panel LevelSuccesPanel;
    public Panel LevelFailPanel;

    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnLevelFail.AddListener(InitializeLevelFailPanel);
        EventManager.OnLevelSuccess.AddListener(InitializeLevelSuccessPanel);
        EventManager.OnLevelContine.AddListener(HidePanel);
        EventManager.OnLevelFinish.AddListener(HidePanel);
        
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnLevelFail.RemoveListener(InitializeLevelFailPanel);
        EventManager.OnLevelSuccess.RemoveListener(InitializeLevelSuccessPanel);
        EventManager.OnLevelContine.RemoveListener(HidePanel);
        EventManager.OnLevelFinish.RemoveListener(HidePanel);

    }

    private void InitializeLevelFailPanel()
    {
        LevelSuccesPanel.HidePanel();
        LevelFailPanel.ShowPanel();
        ShowPanel();
    }

    private void InitializeLevelSuccessPanel()
    {
        LevelSuccesPanel.ShowPanel();
        LevelFailPanel.HidePanel();
        ShowPanel();
    }
}

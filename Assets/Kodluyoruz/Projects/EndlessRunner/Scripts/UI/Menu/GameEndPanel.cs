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

        
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        
    }

    private void InitializeLevelFailPanel()
    {
        
    }

    private void InitializeLevelSuccessPanel()
    {
        
    }
}

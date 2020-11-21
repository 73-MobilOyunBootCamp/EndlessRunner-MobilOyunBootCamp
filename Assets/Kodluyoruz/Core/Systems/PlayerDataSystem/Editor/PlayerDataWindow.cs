using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;


public class PlayerDataWindow : OdinEditorWindow
{
    public PlayerData PlayerData;

    [MenuItem("Kodluyoruz/Player Data Window")]
    public static void OpenWindow()
    {
        GetWindow<PlayerDataWindow>().Show();
    }

    protected override void Initialize()
    {
        base.Initialize();
        PlayerData = SaveLoadManager.LoadPDP<PlayerData>(SavedFileNameHolder.PlayerData, new PlayerData());
    }

    [Button]
    public void SaveData()
    {
        SaveLoadManager.SavePDP(PlayerData, SavedFileNameHolder.PlayerData);
    }

    [Button]
    public void LoadData()
    {
        PlayerData = SaveLoadManager.LoadPDP<PlayerData>(SavedFileNameHolder.PlayerData, new PlayerData());
    }

    [Button]
    public void DeleteData()
    {
        SaveLoadManager.DeleteFile(SavedFileNameHolder.PlayerData);
        PlayerData = SaveLoadManager.LoadPDP<PlayerData>(SavedFileNameHolder.PlayerData, new PlayerData());
    }

}

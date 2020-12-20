using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class CharacterHealthController : MonoBehaviour, IDamageable, IHealable
{

    public int MaxHealth;
    [ShowInInspector]
    [ReadOnly]
    public int CurrentHealth
    {
        get
        {
            var playerData = SaveLoadManager.LoadPDP<PlayerData>(SavedFileNameHolder.PlayerData, new PlayerData());
            return playerData.CurrentHelath;
        }
        set
        {
            var playerData = SaveLoadManager.LoadPDP<PlayerData>(SavedFileNameHolder.PlayerData, new PlayerData());
            playerData.CurrentHelath = value;
            SaveLoadManager.SavePDP(playerData, SavedFileNameHolder.PlayerData);
        }
    }

    Character character;
    Character Character { get { return (character == null) ? character = GetComponent<Character>() : character; } }

    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;

        Character.OnCharacterRevive.AddListener(ResetHealth);
        EventManager.OnGameStart.AddListener(ResetHealth);

    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        Character.OnCharacterRevive.RemoveListener(ResetHealth);
        EventManager.OnGameStart.RemoveListener(ResetHealth);
    }

    [Button]
    private void ResetHealth()
    {
        CurrentHealth = MaxHealth;
    }

    [Button]
    public void Damage()
    {
        CurrentHealth--;
        Character.OnCharacterHit.Invoke();
        if (CurrentHealth <= 0)
        {
            Character.KillCharacter();
            CurrentHealth = 0;
        }
            
    }

    [Button]
    public void Heal()
    {
        CurrentHealth++;
        Character.OnCharacterHeal.Invoke();
        if (CurrentHealth >= MaxHealth)
            CurrentHealth = MaxHealth;
    }


}

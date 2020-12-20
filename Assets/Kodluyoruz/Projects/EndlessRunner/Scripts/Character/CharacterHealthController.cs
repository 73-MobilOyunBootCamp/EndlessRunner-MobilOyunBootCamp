using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealthController : MonoBehaviour, IDamagable, IHealable
{

    public int MaxHealth;
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


    private void ResetHealth()
    {
        CurrentHealth = MaxHealth;
    }


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

    public void Heal()
    {
        CurrentHealth++;
        Character.OnCharacterHeal.Invoke();
        if (CurrentHealth >= MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
    }


}

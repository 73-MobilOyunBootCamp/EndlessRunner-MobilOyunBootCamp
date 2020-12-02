using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealthController : MonoBehaviour
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

        Character.OnCharacterHit.AddListener(Damage);
        Character.OnCharacterHeal.AddListener(Heal);
        Character.OnCharacterRevive.AddListener(ResetHealth);
        EventManager.OnGameStart.AddListener(ResetHealth);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        Character.OnCharacterHit.RemoveListener(Damage);
        Character.OnCharacterHeal.RemoveListener(Heal);
        Character.OnCharacterRevive.RemoveListener(ResetHealth);
        EventManager.OnGameStart.RemoveListener(ResetHealth);
    }

    private void ResetHealth()
    {
        CurrentHealth = MaxHealth;
    }

    private void Damage()
    {
        CurrentHealth--;
        if (CurrentHealth <= 0)
            Character.KillCharacter();
    }

    private void Heal()
    {
        CurrentHealth++;
        if (CurrentHealth >= MaxHealth)
            CurrentHealth = MaxHealth;
    }


}

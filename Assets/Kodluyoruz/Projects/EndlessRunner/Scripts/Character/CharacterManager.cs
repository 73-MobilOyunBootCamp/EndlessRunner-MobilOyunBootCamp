using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class CharacterManager : Singleton<CharacterManager>
{

    private List<Character> characters;
    [ShowInInspector]
    [ReadOnly]
    public List<Character> Characters { get { return (characters == null) ? characters = new List<Character>() : characters; } set { characters = value; } }

    private Character player;
    [ShowInInspector]
    [ReadOnly]
    public Character Player
    {
        get
        {
            if(player == null)
            {
                foreach (var character in Characters)
                {
                    if (character.CharacterControllerType == CharacterControllerType.Player)
                        player = character;
                }
            }

            return player;
        }

        set
        {
            player = value;
        }
    }

    private List<Character> aiCharacters;
    public List<Character> AICharacters
    {
        get
        {
            if(aiCharacters == null || aiCharacters.Count == 0)
            {
                foreach (var character in Characters)
                {
                    if(character.CharacterControllerType == CharacterControllerType.AI)
                    {
                        if (!aiCharacters.Contains(character))
                            aiCharacters.Add(character);
                    }
                }
            }

            return aiCharacters;
        }

        set
        {
            aiCharacters = value;
        }
    }

    
    public void AddCharacter(Character character)
    {
        if (!characters.Contains(character))
        {
            characters.Add(character);
        }
    }

    public void RemoveCharacter(Character character)
    {
        if (characters.Contains(character))
        {
            characters.Remove(character);
        }
    }
}

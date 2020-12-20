using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


public class MagnetPowerUp : PowerUpBase
{
    private GameObject effect;
    public override IEnumerator ExecuteCo()
    {
        effect = Instantiate(PowerUpDisplayPrefab, 
            CharacterManager.Instance.Player.transform.position,
            Quaternion.identity,
            CharacterManager.Instance.Player.transform);


        GameManager.Instance.GameData.IsMagnetActive = true;
        yield return new WaitForSeconds(GameManager.Instance.GameData.MagnetTimer);
        GameManager.Instance.GameData.IsMagnetActive = false;

        Destroy(effect);
        yield return null;
    }

    public override void Use()
    {
       
    }

    public override void Interup()
    {
        base.Interup();
    }
}

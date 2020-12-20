using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


public class MultipilyPowerUp : PowerUpBase
{
    public override IEnumerator ExecuteCo()
    {
        effect = Instantiate(PowerUpDisplayPrefab,
            CharacterManager.Instance.Player.transform.position,
            Quaternion.identity,
            CharacterManager.Instance.Player.transform);

        GameManager.Instance.GameData.PointMultiplier = 2;
        yield return new WaitForSeconds(GameManager.Instance.GameData.MultiplyTimer);
        GameManager.Instance.GameData.PointMultiplier = 1;
        Destroy(effect);
        Destroy(this);

        yield return null;
    }

    public override void Use()
    {
        MultipilyPowerUp multipilyPowerUp = CharacterManager.Instance.Player.gameObject.AddComponent<MultipilyPowerUp>();
        multipilyPowerUp.Initialize(this);
        multipilyPowerUp.Execute();
        Dispose();
    }

    public override void Interup()
    {
        base.Interup();

        GameManager.Instance.GameData.PointMultiplier = 1;
    }
}

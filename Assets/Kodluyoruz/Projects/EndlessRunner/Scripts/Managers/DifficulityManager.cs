
public class DifficulityManager : Singleton<DifficulityManager>
{
    #region Private Methods
    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnPlayerDataUpdated.AddListener(ChangeDifficulty);
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;

        EventManager.OnPlayerDataUpdated.RemoveListener(ChangeDifficulty);
    }

    /// <summary>
    /// Change difficulty mode according to coin amount collected 
    /// </summary>
    /// <param name="playerData"></param>
    private void ChangeDifficulty(PlayerData playerData)
    {
        if(playerData.CoinAmount > LevelManager.Instance.DifficulityData.ActivateTimeTrashold)
        {
            LevelManager.Instance.DifficulityIndex++;
        }
    }
    #endregion
}

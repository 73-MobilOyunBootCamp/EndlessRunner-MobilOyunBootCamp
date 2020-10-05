using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayButton : MonoBehaviour
{
    Button button;
    Button Button { get { return (button == null) ? button = GetComponent<Button>() : button; } }

    private void OnEnable()
    {
        Button.onClick.AddListener(StartGame);
    }

    private void OnDisable()
    {
        Button.onClick.AddListener(StartGame);
    }

    private void StartGame()
    {
        GameManager.Instance.StartGame();
    }
}

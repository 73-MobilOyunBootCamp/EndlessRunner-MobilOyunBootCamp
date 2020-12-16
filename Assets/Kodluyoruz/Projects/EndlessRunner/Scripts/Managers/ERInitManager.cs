using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ERInitManager : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene("EndlessRunnerUI", LoadSceneMode.Additive);
        SceneManager.LoadScene("EndlessRunnerGame", LoadSceneMode.Additive);
        Destroy(gameObject);
    }
}

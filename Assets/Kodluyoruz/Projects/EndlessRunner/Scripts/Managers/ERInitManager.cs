using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ERInitManager : MonoBehaviour
{
    void Start()
    {
        //Init Game Here
        SceneManager.LoadScene("EndlessRunnerUI", LoadSceneMode.Additive);
        SceneManager.LoadScene("EndlessRunnerGame", LoadSceneMode.Additive);

        Destroy(gameObject);
    }
}

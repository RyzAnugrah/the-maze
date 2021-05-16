using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Opening : MonoBehaviour
{
    [SerializeField]
    private float delayBeforeLoading = 25f;

    [SerializeField]
    private string sceneMenuToLoad;

    private float timeElapsed;

    private void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > delayBeforeLoading)
        {
            SceneManager.LoadScene(sceneMenuToLoad);
        }
    }
}

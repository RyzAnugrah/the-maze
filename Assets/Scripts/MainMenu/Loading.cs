using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public Image loadingImage;
    public Image loadingImageUnity;
    public Text textPower;
    public Text textCopyright;

    [SerializeField]
    private float delayBeforeLoading = 8f;

    private float timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        loadingImage.canvasRenderer.SetAlpha(0.0f);
        loadingImageUnity.canvasRenderer.SetAlpha(0.0f);
        textPower.canvasRenderer.SetAlpha(0.0f);
        textCopyright.canvasRenderer.SetAlpha(0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        loadingImage.CrossFadeAlpha(1, 3, false);
        loadingImageUnity.CrossFadeAlpha(1, 3, false);
        textPower.CrossFadeAlpha(1, 3, false);
        textCopyright.CrossFadeAlpha(1, 3, false);

        if (timeElapsed > delayBeforeLoading)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}

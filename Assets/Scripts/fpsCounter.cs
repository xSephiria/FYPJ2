using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class fpsCounter : MonoBehaviour
{
    public Text fpsText;
    public float deltaTime;

    void Update()
    {
        if (Time.timeScale == 0)
            return;
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = Mathf.Ceil(fps).ToString();
    }
}

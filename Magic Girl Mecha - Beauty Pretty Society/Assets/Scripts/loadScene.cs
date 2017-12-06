using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour {

    public string levelToLoad;
    public Color loadToColor = Color.black;

    private void Update()
    {
        if (Input.anyKey)
            Initiate.Fade(levelToLoad, loadToColor, 3.0f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneOnTrigger : MonoBehaviour
{

    public string levelToLoad;
    public Color loadToColor = Color.black;
    public GameObject DestroyThis;
    public GameObject Kaboom;
    bool destroyed = false;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Triggered");
            Destroy(DestroyThis);
            Invoke("loadLevel", 5);

            if (!destroyed)
            {
                Instantiate(Kaboom, DestroyThis.transform.position, Quaternion.identity);
                destroyed = true;
            }
            

        }
    }
    void loadLevel()
    {
        Initiate.Fade(levelToLoad, loadToColor, 3.0f);
    }

    private void FixedUpdate()
    {
        if(Input.GetKey("r") == true)
        {
            Destroy(DestroyThis);
            Invoke("loadLevel", 5);
            if (!destroyed)
            {
                Instantiate(Kaboom, DestroyThis.transform.position, Quaternion.identity);
                destroyed = true;
            }
        }
    }
}

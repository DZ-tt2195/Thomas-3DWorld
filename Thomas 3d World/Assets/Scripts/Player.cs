using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player instance;
    Vector3 startingPos;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void Died()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

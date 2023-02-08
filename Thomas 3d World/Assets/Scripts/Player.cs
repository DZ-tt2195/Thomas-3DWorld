using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player instance; 

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void Died()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

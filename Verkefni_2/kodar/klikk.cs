using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Klikk : MonoBehaviour
{
    public void Byrja()
    {
        // setur spilara í næstu senu
        SceneManager.LoadScene(1);
    }
}

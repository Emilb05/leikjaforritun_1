using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayerCharacter : MonoBehaviour
{
    public float displayTime = 4.0f;//tíma lengd hlutar
    public GameObject dialogBox;
    float timerDisplay;

    void Start()
    {
        dialogBox.SetActive(false);// hluturinn er ósýnilegur
        timerDisplay = -1.0f;
    }

    void Update()
    {
        if (timerDisplay >= 0)
        {
            timerDisplay -= Time.deltaTime;// tel niður
            if (timerDisplay < 0)
            {
                dialogBox.SetActive(false);// hluturinn verður ósýnilegur
            }
        }
    }

    public void DisplayDialog()
    {
        timerDisplay = displayTime;// setur tímann
        dialogBox.SetActive(true);// sýni hlut
    }
}
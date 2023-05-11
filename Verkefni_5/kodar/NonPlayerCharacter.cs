using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayerCharacter : MonoBehaviour
{
    public float displayTime = 4.0f;//t�ma lengd hlutar
    public GameObject dialogBox;
    float timerDisplay;

    void Start()
    {
        dialogBox.SetActive(false);// hluturinn er �s�nilegur
        timerDisplay = -1.0f;
    }

    void Update()
    {
        if (timerDisplay >= 0)
        {
            timerDisplay -= Time.deltaTime;// tel ni�ur
            if (timerDisplay < 0)
            {
                dialogBox.SetActive(false);// hluturinn ver�ur �s�nilegur
            }
        }
    }

    public void DisplayDialog()
    {
        timerDisplay = displayTime;// setur t�mann
        dialogBox.SetActive(true);// s�ni hlut
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    public static UIHealthBar instance { get; private set; }

    public Image mask;
    float originalSize;// upprunnaleg st�r�

    void Awake()
    {
        //setur 'current instance' yfir � 'static instance' breytuna
        instance = this;
    }

    void Start()
    {
        //setur upprunnalegu breiddina � 'mask'inu � 'originalSize' breytuna
        originalSize = mask.rectTransform.rect.width;
    }

    public void SetValue(float value)
    {
        //setur st�r�ina � 'mask'inu til a� vera pr�sentu tala af upprunnalegu st�r�inni samhv�mt t�lunni sem sett er inn
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
    }
}
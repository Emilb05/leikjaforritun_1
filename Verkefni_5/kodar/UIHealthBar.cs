using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    public static UIHealthBar instance { get; private set; }

    public Image mask;
    float originalSize;// upprunnaleg stærð

    void Awake()
    {
        //setur 'current instance' yfir í 'static instance' breytuna
        instance = this;
    }

    void Start()
    {
        //setur upprunnalegu breiddina á 'mask'inu í 'originalSize' breytuna
        originalSize = mask.rectTransform.rect.width;
    }

    public void SetValue(float value)
    {
        //setur stærðina á 'mask'inu til að vera prósentu tala af upprunnalegu stærðinni samhvæmt tölunni sem sett er inn
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
    }
}
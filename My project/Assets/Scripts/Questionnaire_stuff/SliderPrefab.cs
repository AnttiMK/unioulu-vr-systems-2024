using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SliderPrefab : PrefabBase
{
    public Slider slider;
    public TMP_Text text;
    public float value;
    public string prompt;
    public Vector2Int limits;
    
    public void Awake()
    {
        type = "slider";
    }
    // Start is called before the first frame update
    public void Start()
    {
        Init();
    }
    public override void Init()
    {
        setText();
        slider.minValue = limits.x;
        slider.maxValue = limits.y;
    }

    public void onValueChange()
    {

        value = slider.value;
        setText();
    }

    void setText()
    {
        text.text = prompt + ": " + value;
    }

    public override string toString()
    {
        return value.ToString();
    }
    public override bool Ready()
    {
        return true;
    }
}

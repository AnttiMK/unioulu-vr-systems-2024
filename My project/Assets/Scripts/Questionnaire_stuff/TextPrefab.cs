using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextPrefab : PrefabBase
{
    public TMP_Text text;
    public RectTransform rect;
    public void Awake()
    {
        type = "text";
    }

    [TextArea(1, 10)]
    public string value;
    public void Start()
    {
        Init();
    }
    public override void Init()
    {
        setText();
    }

    void setText()
    {
        text.text = value;
        Vector2 size = rect.sizeDelta;
        size.y = text.preferredHeight+10;
        rect.sizeDelta = size;
    }

    public override string toString()
    {
        return value;
    }
    public override bool Ready()
    {
        return true;
    }
}

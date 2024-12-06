using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MultiPrompt : MonoBehaviour
{
    public int value;
    public string prompt;
    public TMP_Text text;

    public List<Toggle> toggles = new List<Toggle>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init()
    {
        setText();
        value = -1;
        foreach (Toggle t in toggles)
        {
            t.isOn = false;
        }
        

    }

    public void toggled(int i)
    {
        if(toggles[i].isOn)
            value = i;

    }

    void setText()
    {
        text.text = prompt;
    }
}

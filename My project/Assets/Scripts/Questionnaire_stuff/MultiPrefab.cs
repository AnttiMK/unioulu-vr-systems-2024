using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MultiPrefab : PrefabBase
{
    [TextArea(1, 10)]
    public string title;
    public List<string> choices = new List<string>();
    public List<string> prompts = new List<string>();
    List<MultiPrompt> promptScripts = new List<MultiPrompt>();

    public List<TMP_Text> choice_texts = new List<TMP_Text>();

    public TMP_Text text;

    public GameObject multiPrefab;
    public void Awake()
    {
        type = "multi";
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void setText()
    {
        text.text = title;
        
    }

    public override string toString()
    {
        string toReturn = promptScripts[0].value.ToString() ;
        for (int i = 1; i < promptScripts.Count; i++)
        {
            toReturn += ", " + promptScripts[i].value.ToString();
        }
        return toReturn;
    }

    public override void Init()
    {
        setText();
        for (int i = 0; i < choices.Count; i++)
        {
            choice_texts[i].text = choices[i];
        }
        id = prompts[0].ToLower().Replace(" ","_");

        GameObject ob = GameObject.Instantiate(multiPrefab, this.transform);
        MultiPrompt mp1 = ob.GetComponent<MultiPrompt>();
        promptScripts.Add(mp1);
        mp1.prompt = prompts[0];
        mp1.Init();
        for (int i = 1; i<prompts.Count; i++)
        {
            id += ", " + prompts[i].ToLower().Replace(" ", "_"); ;
            GameObject o = GameObject.Instantiate(multiPrefab, this.transform);
            MultiPrompt mp = o.GetComponent<MultiPrompt>();
            promptScripts.Add(mp);
            mp.prompt = prompts[i];
            mp.Init();
        }
        RectTransform r = GetComponent<RectTransform>();
        Vector2 size = r.sizeDelta;
        size.y = 50 + 20 * prompts.Count;
        r.sizeDelta = size;
    }

    public override bool Ready()
    {
        foreach (MultiPrompt mp in promptScripts)
            if (mp.value == -1)
                return false;
        return true;
    }
}

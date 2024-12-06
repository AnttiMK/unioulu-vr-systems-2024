using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class QSystem : MonoBehaviour
{
    public static QSystem instance;
    public void Awake()
    {
        instance = this;
    }
    public static string basePath = "SsqResult";
    public string filename;
    public List<PrefabBase> QuestionnaireElements = new List<PrefabBase>();

    public GameObject content;
    public List<string> titles = new List<string>();
    public static string userID;

    public bool singleFile = false;
    public static GameObject receiver;

    // Start is called before the first frame update
    void Start()
    {
        foreach(PrefabBase prefab in content.GetComponentsInChildren<PrefabBase>())
        {
            prefab.Init();
            QuestionnaireElements.Add(prefab);
            switch(prefab.type)
            {
                case "text":
                    break;
                case "slider":
                    titles.Add(prefab.id);
                    break;
                case "multi":
                    titles.Add(prefab.id);
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveToFile()
    {
        string path = Path.Combine(Application.persistentDataPath, basePath, userID);
        if (singleFile)
            path = Path.Combine(Application.persistentDataPath, basePath);
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
        if(!singleFile)
        {
            filename = Path.Combine(Application.persistentDataPath, basePath, userID + "_ssq.csv");
            using (StreamWriter sw = new StreamWriter(filename))
            {
                sw.WriteLine(string.Join(", ", titles));
                List<string> values = new List<string>();

                foreach (PrefabBase prefab in QuestionnaireElements)
                {
                    if (prefab.type != "text")
                        values.Add(prefab.toString());
                }
                sw.WriteLine(string.Join(", ", values));
            }
        }
        else
        {
            filename = Path.Combine(Application.persistentDataPath, basePath, "ssq.csv");
            bool exists = File.Exists(filename);
            using (StreamWriter sw = new StreamWriter(filename, true))
            {
                if(!exists)
                {
                    string t = "user_id, " + string.Join(", ", titles);
                    sw.WriteLine(t);
                }
                
                List<string> values = new List<string>();
                values.Add(userID);
                foreach (PrefabBase prefab in QuestionnaireElements)
                {
                    if (prefab.type != "text")
                        values.Add(prefab.toString());
                }
                sw.WriteLine(string.Join(", ", values));
            }
        }
        
    }

    public void OnGUI()
    {
        GUI.enabled = true;
        userID = GUILayout.TextField(userID, GUILayout.Height(30));
        bool ready = true;
        foreach (PrefabBase prefab in QuestionnaireElements)
        {
            if (prefab.Ready() == false)
                ready = false;
        }

        //GUI.enabled = ready;
        if (GUILayout.Button("SaveQuestionnaire", GUILayout.Height(30)))
        {
            
            SaveToFile();
            try
            {
                receiver.BroadcastMessage("QuestionnaireSaved");
            }
            catch
            {
                Debug.Log("No receiver");
            }
            SceneManager.UnloadSceneAsync("SSQ_Scene");
            SceneManager.LoadScene(0);
        }
    }
}

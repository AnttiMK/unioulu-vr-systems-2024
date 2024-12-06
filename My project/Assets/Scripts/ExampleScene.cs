using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExampleScene : MonoBehaviour
{
    QSystem qsystem;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Press space to start ssq");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("SSQ_Scene", LoadSceneMode.Additive);
            qsystem = QSystem.instance;
            QSystem.receiver = this.gameObject;
            QSystem.userID = "FakeID";
            QSystem.basePath = "Base folder";
        }

        /*if(qsystem == null)
        {
            if (QSystem.instance != null)
            {
                qsystem = QSystem.instance;
                qsystem.receiver = this.gameObject;
            }
        }*/
    }

    public void QuestionnaireSaved()
    {
        Debug.Log("Continuing doing stuff");
    }
}

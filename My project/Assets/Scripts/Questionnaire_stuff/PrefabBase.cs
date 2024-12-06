using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PrefabBase : MonoBehaviour
{
    public string id;
    public string type;

    public abstract string toString();
    public abstract void Init();
    public abstract bool Ready();
}

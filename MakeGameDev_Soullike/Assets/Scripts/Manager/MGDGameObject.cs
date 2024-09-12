using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGDGameObject : MonoBehaviour
{
    public MGDGameObject(string objectName)
    {
        new GameObject(objectName);
    }
}

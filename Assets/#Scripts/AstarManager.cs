using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class AstarManager : MonoBehaviour
{
    public static AstarManager instance;

    AstarPath _astarPath;

    private void Awake()
    {
        instance = this;
        _astarPath = GetComponent<AstarPath>();
    }

    public void Scan()
    {
        _astarPath.Scan();
    }
}

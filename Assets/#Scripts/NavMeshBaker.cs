using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class NavMeshBaker : MonoBehaviour
{
    public static NavMeshBaker instance;

    NavMeshSurface _navMeshSurface;

    private void Awake()
    {
        instance = this;
        _navMeshSurface = GetComponent<NavMeshSurface>();
    }

    private void Start()
    {
        BakeNavMesh();
    }

    public void BakeNavMesh()
    {
        _navMeshSurface.RemoveData();
        _navMeshSurface.BuildNavMesh();
    }
}

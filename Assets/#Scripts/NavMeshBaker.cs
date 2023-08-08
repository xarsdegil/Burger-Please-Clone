using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshBaker : MonoBehaviour
{
    public static NavMeshBaker instance;

    NavMeshSurface _navMeshSurface;
    [SerializeField] NavMeshData _navMeshData;

    private void Awake()
    {
        instance = this;
        _navMeshSurface = GetComponent<NavMeshSurface>();
    }

    private void Start()
    {
        //_navMeshSurface.BuildNavMesh();
        _navMeshSurface.navMeshData = _navMeshData;
        BakeNavMesh();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            BakeNavMesh();
        }

        
    }

    public void BakeNavMesh()
    {
        //_navMeshSurface.RemoveData();
        //if(_navMeshSurface.navMeshData == null) _navMeshSurface.BuildNavMesh();
        //_navMeshSurface.UpdateNavMesh(_navMeshSurface.navMeshData);
    }
}

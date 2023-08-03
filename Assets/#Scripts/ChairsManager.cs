using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairsManager : MonoBehaviour
{
    public static ChairsManager instance;

    List<GameObject> _allChairs = new List<GameObject>();

    private void Awake()
    {
        instance = this;
    }

    public Transform GetRandomChair()
    {
        FindAllChairs();
        List<GameObject> availableChairs = new List<GameObject>();
        foreach (var chair in _allChairs)
        {
            if (chair.GetComponent<ChairController>().IsAvailable())
            {
                availableChairs.Add(chair);
            }
        }
        if (availableChairs.Count == 0) return null;
        return availableChairs[Random.Range(0, availableChairs.Count)].transform;
    }
    
    void FindAllChairs()
    {
        _allChairs.Clear();
        _allChairs = new List<GameObject>(GameObject.FindGameObjectsWithTag("Chair"));
    }

}

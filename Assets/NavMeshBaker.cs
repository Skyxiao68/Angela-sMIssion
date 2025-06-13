using NavMeshPlus.Components;
using UnityEngine;

public class NavMeshBaker : MonoBehaviour
{
    public NavMeshSurface surface;
    public float updateInterval = 10f; 

    private void Start()
    {
        StartCoroutine(UpdateNavMeshPeriodically());
    }

    private System.Collections.IEnumerator UpdateNavMeshPeriodically()
    {
        while (true) 
        {
            yield return new WaitForSeconds(updateInterval);
            surface.BuildNavMesh();
            Debug.Log($"NavMesh updated! Next update in {updateInterval} seconds.");
        }
    }
}
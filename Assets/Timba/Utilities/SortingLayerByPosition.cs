using System.Linq;
using UnityEngine;

[ExecuteInEditMode]
public class SortingLayerByPosition : MonoBehaviour
{
    public bool sortByX;
    public bool sortByY;
    public bool sortByZ;
    [Min(10)] public int xMultiplier = 1000;
    [Min(10)] public int yMultiplier = 1000;
    [Min(10)] public int zMultiplier = 1000;

    private Renderer[] renderers;
    private Vector3 lastPosition;
    private int[] originalSortingOrders;
    
    private void Awake() {
        renderers = GetComponentsInChildren<Renderer>().Concat(GetComponents<Renderer>()).ToArray();
        lastPosition = transform.position;
        originalSortingOrders = renderers.Select(x => x.sortingOrder).ToArray();
    }

    private void Update() {
        if(transform.position != lastPosition) {
            for(int i = 0; i < renderers.Length; i++) {
                renderers[i].sortingOrder = originalSortingOrders[i] 
                    + (int)(transform.position.x * xMultiplier * (sortByX ? 1 : 0)) 
                    + (int)(transform.position.y * yMultiplier * (sortByY ? 1 : 0))
                    + (int)(transform.position.z * zMultiplier * (sortByZ ? 1 : 0));
            }
            lastPosition = transform.position;
        }
    }
}

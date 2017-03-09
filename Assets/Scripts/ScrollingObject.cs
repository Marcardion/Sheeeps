using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour {

    public Vector3 scrollVelocity;
    public Vector3 size;

    public virtual void Update()
    {
        transform.position += scrollVelocity * Time.deltaTime;
    }

    [ContextMenu("Update Size From Children")]
    public void UpdateSizeFromChildren()
    {
        Bounds bounds = new Bounds (transform.position, Vector3.one);
        Renderer[] renderers = GetComponentsInChildren<Renderer> ();
        foreach (Renderer renderer in renderers)
        {
            bounds.Encapsulate (renderer.bounds);
        }

        size = bounds.size;
    }
}

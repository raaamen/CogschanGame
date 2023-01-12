using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctreeNode
{
    Bounds bound;

    public OctreeNode parent = null;
    public OctreeNode[] children = null;
    public bool isBlocked = false;

    public OctreeNode(Bounds bound)
    {
        this.bound = bound;
    }

    public void Divide(float minSize)
    {
        if (bound.size.x / 2 < minSize)
        {
            Collider[] colliders = Physics.OverlapBox(bound.center, new Vector3(bound.size.x / 2, bound.size.x / 2, bound.size.x / 2));

            if (colliders.Length > 0) isBlocked = true;
            return;
        }
        children = new OctreeNode[8];
        children[0] = new OctreeNode(new Bounds(new Vector3(bound.center.x + bound.size.x / 4, bound.center.y + bound.size.x / 4, bound.center.z + bound.size.x / 4), 
            new Vector3(bound.size.x / 2, bound.size.x / 2, bound.size.x / 2)));
        children[1] = new OctreeNode(new Bounds(new Vector3(bound.center.x + bound.size.x / 4, bound.center.y + bound.size.x / 4, bound.center.z - bound.size.x / 4),
            new Vector3(bound.size.x / 2, bound.size.x / 2, bound.size.x / 2)));
        children[2] = new OctreeNode(new Bounds(new Vector3(bound.center.x + bound.size.x / 4, bound.center.y - bound.size.x / 4, bound.center.z + bound.size.x / 4),
            new Vector3(bound.size.x / 2, bound.size.x / 2, bound.size.x / 2)));
        children[3] = new OctreeNode(new Bounds(new Vector3(bound.center.x + bound.size.x / 4, bound.center.y - bound.size.x / 4, bound.center.z - bound.size.x / 4),
            new Vector3(bound.size.x / 2, bound.size.x / 2, bound.size.x / 2)));
        children[4] = new OctreeNode(new Bounds(new Vector3(bound.center.x - bound.size.x / 4, bound.center.y + bound.size.x / 4, bound.center.z + bound.size.x / 4),
            new Vector3(bound.size.x / 2, bound.size.x / 2, bound.size.x / 2)));
        children[5] = new OctreeNode(new Bounds(new Vector3(bound.center.x - bound.size.x / 4, bound.center.y + bound.size.x / 4, bound.center.z - bound.size.x / 4),
            new Vector3(bound.size.x / 2, bound.size.x / 2, bound.size.x / 2)));
        children[6] = new OctreeNode(new Bounds(new Vector3(bound.center.x - bound.size.x / 4, bound.center.y - bound.size.x / 4, bound.center.z + bound.size.x / 4),
            new Vector3(bound.size.x / 2, bound.size.x / 2, bound.size.x / 2)));
        children[7] = new OctreeNode(new Bounds(new Vector3(bound.center.x - bound.size.x / 4, bound.center.y - bound.size.x / 4, bound.center.z - bound.size.x / 4),
            new Vector3(bound.size.x / 2, bound.size.x / 2, bound.size.x / 2)));

        for (int i = 0; i < 8; i++)
        {
            OctreeNode child = children[i];
            child.parent = this;
            Collider[] colliders = Physics.OverlapBox(child.bound.center, new Vector3(child.bound.size.x / 2, child.bound.size.x / 2, child.bound.size.x / 2));

            if (colliders.Length > 0) child.Divide(minSize);
        }
        
    }

    public void Draw()
    {
        if (isBlocked) Gizmos.color = Color.red;
        else Gizmos.color = Color.green;

        Gizmos.DrawWireCube(bound.center, bound.size);
        if (children != null)
        {
            for (int i = 0; i < 8; i++)
            {
                children[i].Draw();
            }
        }
    }

    public void DrawPoints(float pointRadius)
    {
        if (isBlocked) Gizmos.color = Color.red;
        else Gizmos.color = Color.green;
        
        if (children != null)
        {
            for (int i = 0; i < 8; i++)
            {
                children[i].DrawPoints(pointRadius);
            }
        }
        else
        {
            Gizmos.DrawWireSphere(bound.center, pointRadius);
        }
    }
}

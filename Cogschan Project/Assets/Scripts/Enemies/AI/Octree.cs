using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octree
{
    public OctreeNode root;

    public Octree(float size, Vector3 center, float nodeMinSize)
    {
        Bounds bound = new Bounds(center, new Vector3(size, size, size));
        root = new OctreeNode(bound);
        Collider[] colliders = Physics.OverlapBox(center, new Vector3(size / 2, size / 2, size / 2));

        if (colliders.Length > 0) root.Divide(nodeMinSize);
    }
}

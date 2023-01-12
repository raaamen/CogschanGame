using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateOctree : MonoBehaviour
{
    public float nodeMinSize = 5;
    public Transform center;
    public float size;
    public GameObject[] obstacles;
    
    Octree otree;

    void Start()
    {
        otree = new Octree(size, center.position, nodeMinSize);
    }

    private void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            otree.root.Draw();
            //otree.root.DrawPoints(0.1f);
        }
        else if (center != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireCube(center.position, new Vector3(size, size, size));
        }
    }
}

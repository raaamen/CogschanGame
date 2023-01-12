using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIFollow : MonoBehaviour
{
    public float lookRadius = 10f;
    public NavMeshAgent nav;
    public Transform Player;
    public float idleTime = 10f;
    private float currentTime;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        currentTime = idleTime;
    }

    void Update(){
        nav.SetDestination(Player.position);
        transform.LookAt(Player);
        if (nav.remainingDistance == 0){
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                nav.destination = Player.position;
                currentTime = idleTime;
            }
        }else{
            currentTime = idleTime;
        }

    }
    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}

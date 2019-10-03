using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleFollow : MonoBehaviour
{
    public GameObject target;
    NavMeshAgent ai;
    // Start is called before the first frame update
    void Start()
    {
        ai = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        ai.destination = target.transform.position;
    }
}

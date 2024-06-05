using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navMeshScript : MonoBehaviour
{

    NavMeshAgent agent;
    [SerializeField] Transform player;
    // Start is called before the first frame update

    private void Awake()
    {
        if (Vector3.Distance(transform.position, new Vector3(0, 0, 0)) < 30)
        {
            float randomOffset = Random.Range(15, 25);
            transform.position += (transform.position - Vector3.zero).normalized * randomOffset;
        }
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("FPSController").transform;

    }


    // Update is called once per frame
    void Update()
    {
        agent.destination = player.position;
    }
}

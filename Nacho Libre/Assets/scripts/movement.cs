using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class movement : MonoBehaviour
{
    public float flyerScore;

    [SerializeField]
    NavMeshAgent agent;

    [SerializeField]
    GameObject indicatorPrefab;

    GameObject indicator;

    private void Start()
    {
        indicator = Instantiate(indicatorPrefab);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                agent.destination = hit.point;
                indicator.transform.position = hit.point;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Flyer")
        {
            flyerScore += 1;
            Debug.Log("your score is now: " + flyerScore); 
        }
    }
}

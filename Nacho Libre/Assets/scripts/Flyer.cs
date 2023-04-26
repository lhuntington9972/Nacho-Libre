using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
        } else if (other.tag == "Building")
        {
            transform.position = new Vector3(Mathf.Round(Random.Range(-14f, 14f)), 1, Mathf.Round(Random.Range(-14f, 14f)));
            Debug.Log("movement needed!");
        }/* else if (other.tag == "Flyer")
        {
            transform.position = new Vector3(Random.Range(-14f, 14f), 1, Random.Range(-14f, 14f));
            Debug.Log("movement needed!");
        }*/
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

public class movement : MonoBehaviour
{
    public float flyerScore;

    [SerializeField]
    NavMeshAgent agent;

    [SerializeField]
    GameObject indicatorPrefab;

    GameObject indicator;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI taskText;
    private float game1Countdown;
    private bool game1Finished;
    private string currentTaskString;
    private int currentTask;
    

    private void Start()
    {
        indicator = Instantiate(indicatorPrefab);
        game1Countdown = 5f;
        currentTask = 1;
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

        if (flyerScore < 25 && currentTask == 1)
        {
            scoreText.text = "Score: " + flyerScore;
        } else if (flyerScore >= 25 && currentTask == 1)
        {
            StartCoroutine(game1FinishCountdown());
        }

        taskText.text = "Current task: " + currentTaskString;

        if (currentTask == 0)
        {
            currentTaskString = "Find something else do to!";
        } else if (currentTask == 1)
        {
            currentTaskString = "Tear down uninclusive flyers in the plaza!";
        } else if (currentTask == 2)
        {
            currentTaskString = "SLAM GORILLAS!!!";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Flyer")
        {
            flyerScore += 1;
            Debug.Log("your score is now: " + flyerScore); 
        } else if (other.tag == "taskTwoBarrier")
        {
            currentTask = 2; 
        } else if (other.tag == "taskOneBarrier" && game1Finished == false)
        {
            currentTask = 1; 
        }
    }

    IEnumerator game1FinishCountdown()
    {
        currentTask = 0;
        game1Finished = true; 
        scoreText.text = "You completed the first task!";
        yield return new WaitForSeconds(game1Countdown);
        //Destroy(scoreText);
        scoreText.text = "";
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MLAgents;

public class Fish : Agent
{
    [SerializeField]
    private float jumpForce = 250f;
    private Rigidbody2D rb;     // Fish
    Vector3 originalPos;
    public GameObject[] seaweeds;
    List<Vector3> positionsOfSeaweeds;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalPos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        seaweeds = GameObject.FindGameObjectsWithTag("seaweed");
        positionsOfSeaweeds = new List<Vector3>();
        foreach (GameObject seaweed in seaweeds)
        {
            positionsOfSeaweeds.Add(seaweed.transform.position);
        }
    }

    public override void AgentReset()
    {
        rb.velocity = Vector2.zero;
        rb.transform.eulerAngles = new Vector2(0, 0);
        rb.angularVelocity = 0;
        rb.transform.position = originalPos;
        seaweeds = GameObject.FindGameObjectsWithTag("seaweed");
        int i = 0;
        foreach (GameObject seaweed in seaweeds)
        {
            seaweed.transform.position = positionsOfSeaweeds[i];
            i++;
        }
    }

    public override void CollectObservations()
    {
        AddVectorObs(this.transform.position.y);
    }

    public override void AgentAction(float[] vectorAction, string textAction)
    {
        if(vectorAction[0] == 1)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce);            
        }

        if(transform.position.y > 4 || transform.position.y < -3.7)
        {
            SetReward(-10);
            // Debug.Log(GetReward());
            Done();
        }
        else
        {
            SetReward(1);
            // Debug.Log(GetReward());
        }
    }

    public override void AgentOnDone()
    {
        AgentReset();
    }
}

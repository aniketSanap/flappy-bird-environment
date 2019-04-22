using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MLAgents;

public class Seaweed : MonoBehaviour
{

    // void Start()
    // {
    //     fish = GameObject.Find("Fish").GetComponent<Fish>();
    // }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.collider.GetComponent<Fish>() != null)
        {
            collision.collider.GetComponent<Fish>().SetReward(-10);
            // Debug.Log(-10);
            collision.collider.GetComponent<Fish>().Done();
        }
    }
}

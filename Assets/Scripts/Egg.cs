using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SnakeHead"))
        {
            Destroy(gameObject);
            other.GetComponent<SnakeMovement>().AddNewPartOfTail(); 
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Box - Simple script that tells the box to return a Debug.Log when hit by a bullet.
*/
public class Box : MonoBehaviour, IDamageable
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage()
    {
        Debug.Log("Box: I am hit by a bullet!");
    }
}


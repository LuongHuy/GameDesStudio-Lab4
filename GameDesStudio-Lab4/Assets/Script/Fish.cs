using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : EnemyClass
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        Debug.Log("Child Start");
    }

    // Update is called once per frame
    void Update()
    {

    }
    protected override void Action()
    {
        throw new System.NotImplementedException();
    }

}

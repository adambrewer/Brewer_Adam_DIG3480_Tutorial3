using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

private float timer;
private bool timerOn;


    void Start()
    {
        timer = 30f;
	timerOn = false;
    }

    void Update()
	{
	if (timerOn == false)
	{	
		if(Input.GetKeyDown(KeyCode.U))
		{
		timerOn = true;
		}
	}

		if(timerOn == true)
		{
        	 timer -= Time.deltaTime;
        	 	if(timer < 0)
        	 	{
         		    Destroy(this.gameObject);
         		}

		}
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGScroller : MonoBehaviour
{
	private float scrollSpeed;
	public float tileSizeZ;
	public Text winText;

	private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
	scrollSpeed = -0.25f;
    }

    // Update is called once per frame
    void Update()
    {
if (winText.text == "You Win!  Game created by Adam Brewer.")
	{
	scrollSpeed = -5f;
	}
        float newPosition = Mathf.Repeat (Time.time * scrollSpeed, tileSizeZ);
	transform.position = startPosition + Vector3.forward * newPosition;
    }
}

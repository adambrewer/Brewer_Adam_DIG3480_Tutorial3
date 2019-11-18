using System.Collections;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{

	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	public GameController gameController;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}



    void OnTriggerEnter(Collider other)
{	
	if (other.tag == "Boundary" || other.tag == "Enemy")
	{
		return;
	}
	if (explosion != null)
	{
		Instantiate(explosion, transform.position, transform.rotation);
	}
	if (other.tag == "Player")
	{
	Instantiate(playerExplosion, transform.position, transform.rotation);
	gameController.gameOver ();
	}
	gameController.AddScore (scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}

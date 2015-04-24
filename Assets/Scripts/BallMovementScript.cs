using UnityEngine;
using System.Collections;

public class BallMovementScript : MonoBehaviour {


	public Rigidbody ballPrefab;
	private Rigidbody ballClone;
	public int pitchSpeed;
	private GameObject other;
	private bool started = false;
	public static float random;
	public Animator pitchAnimator;


	// Use this for initialization
	void Start () 
	{
	

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Random.Range (1, 5) == 2)
		{
			if(Random.Range (1,3)==1)
				pitchSpeed = 1250;
			else
				pitchSpeed = 2000;
		}
		else
			pitchSpeed = 1600;

random = Random.Range (3.3f, 4.2f);
	if (started == false && Input.GetKeyDown(KeyCode.S)) 
		{
			StartCoroutine ("Pitch");
			started = true;
		}
	}




	IEnumerator Pitch()
	{
		while (true)
		{
			pitchAnimator.SetInteger ("Pitch",1);
			yield return new WaitForSeconds (1f);
			ballClone = Instantiate (ballPrefab) as Rigidbody;
			ballClone.AddForce (transform.forward * -pitchSpeed);
			pitchAnimator.SetInteger("Pitch",0);
			yield return new WaitForSeconds(random);
			Destroy(ballClone.gameObject);


		}
	}

}

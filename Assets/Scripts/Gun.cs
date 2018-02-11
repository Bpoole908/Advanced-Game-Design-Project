using UnityEngine;

public class Gun : MonoBehaviour {

	public float damage = 10f;
	public float range = 100f;

	public Camera fpsCam;
	public ParticleSystem MuzzleFalsh;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			MuzzleFalsh.Play ();
			Shoot ();
		}
		
	}
	void Shoot () {
		RaycastHit hit;
		if (Physics.Raycast (fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) {
			print (hit.transform.name);
		}
	}
}

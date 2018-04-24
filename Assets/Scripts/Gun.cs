using UnityEngine;

public class Gun : MonoBehaviour {

	public float damage = 10f;
	public float range = 100f;

	public Camera fpsCam;
	public ParticleSystem MuzzleFalsh;
	public GameObject impactEffect;
	[HideInInspector] public GameObject controller;
	[HideInInspector] public GlobalVars target;
    AudioSource gunSound;
    AudioSource targetHit;

	// Use this for initialization
	void Start () {
		controller = GameObject.Find ("GameController");
		target = controller.GetComponent<GlobalVars> ();
        AudioSource[] audios = GetComponents<AudioSource>();
        gunSound = audios[0];
        targetHit = audios[1];
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1") && PauseSingle.Instance._enable) {
			MuzzleFalsh.Play ();
            gunSound.Play();
			Shoot ();
		}
		
	}
	void Shoot () {
		RaycastHit hit;
		if (Physics.Raycast (fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) {
			if (hit.transform.tag == "Target") {
                targetHit.Play();
				DestroyObject(hit.transform.gameObject);
				target.getTargets = GameObject.FindGameObjectsWithTag ("Target");
				target.targetCount = target.getTargets.Length -1;
				target.countText.text = (target.targetCount ).ToString ();

			}
			GameObject impact = Instantiate (impactEffect, hit.point, Quaternion.LookRotation (hit.normal));
			Destroy (impact, 1f);
		}
	}

}

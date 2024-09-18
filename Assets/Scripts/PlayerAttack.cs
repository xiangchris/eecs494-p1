using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public HasHealth health;
    public GameObject sword;
	public Projectile swordBeam;

	bool canAttack = true;

	void Start()
	{
		sword.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.X) && canAttack)
		{
			StartCoroutine(Attack());
		}
	}

	IEnumerator Attack()
	{
		canAttack = false;
		ArrowKeyMovement.playerRigidbody.velocity = Vector3.zero;
        ArrowKeyMovement.playerControl = false;

        sword.transform.position = transform.position;
		sword.transform.eulerAngles = new Vector3(0f, 0f, (float)ArrowKeyMovement.getDirection());
        sword.transform.position = transform.position + (Utility.GetFacingVector() * 0.6f);

        if (health != null && health.GetHealth() == Utility.MAX_HEALTH)
            swordBeam.StartMovement(transform.position);
        sword.SetActive(true);
		yield return new WaitForSeconds(.3f);
		
		sword.SetActive(false);
		yield return new WaitForSeconds(.3f);

        canAttack = true;
        ArrowKeyMovement.playerControl = true;
    }
}
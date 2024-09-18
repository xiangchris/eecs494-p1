using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public HasHealth health;
    public Inventory inv;
    public GameObject sword;
	public Projectile swordBeam;
    public Projectile arrow;

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
			StartCoroutine(Attack(true));
		}

		if (Input.GetKeyDown(KeyCode.Z) && canAttack && inv.GetItem(Inventory.Item.Rupees) > 0)
        {
            StartCoroutine(Attack(false));
        }
    }

	IEnumerator Attack(bool main)
	{
		canAttack = false;
		ArrowKeyMovement.playerRigidbody.velocity = Vector3.zero;
        ArrowKeyMovement.playerControl = false;

		if (main)
			Sword();
		else
			OffHand();
        
		yield return new WaitForSeconds(.3f);

        if (main)
            sword.SetActive(false);

        yield return new WaitForSeconds(.3f);

        canAttack = true;
        ArrowKeyMovement.playerControl = true;
    }

	void Sword()
	{
        sword.transform.position = transform.position;
        sword.transform.eulerAngles = new Vector3(0f, 0f, (float)ArrowKeyMovement.getDirection());
        sword.transform.position = transform.position + (Utility.GetFacingVector() * 0.6f);

        if (health != null && health.GetHealth() == Utility.MAX_HEALTH)
            swordBeam.StartMovement(transform.position);
        sword.SetActive(true);
    }

	void OffHand() 
	{
        arrow.StartMovement(transform.position);
		inv.AddItem(Inventory.Item.Rupees, -1);
	}
}
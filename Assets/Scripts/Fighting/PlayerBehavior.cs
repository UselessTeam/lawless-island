using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : FightingBehavior
{
	PlayerMovement movement;

	public GameObject attackObject;
	public float attackTime;
	public float attackPopDistance;

    public int[] equipementDamage;

    bool isAttacking = false;
	float timeSinceAttack = -10;
	Vector2 attackDirection;
	// Start is called before the first frame update
	protected override void Start()
    {
        base.Start();
        movement = GetComponent<PlayerMovement>();
        UpdateDamage();
    }

	// Update is called once per frame
	void Update()
	{
		FightingUpdate();
		if (Input.GetButtonDown("Attack") && IsCanAttack())
		{
			isAttacking = true;
			timeSinceAttack = Time.fixedTime;
			attackObject.SetActive(true);
			attackDirection = movement.facingDirection;
			attackObject.transform.localPosition += (Vector3)attackDirection * attackPopDistance;
		}

		if (isAttacking && Time.fixedTime - timeSinceAttack > attackTime)
		{
			isAttacking = false;
			attackObject.SetActive(false);
			attackObject.transform.localPosition = new Vector3();
		}
	}

	public Vector2 GetAttackDirection()
	{
		return attackDirection;
	}

	public override bool IsCanAttack()
	{
		return !isAttacking && !GetComponentInParent<MovingEntity>().IsTakingHit();
	}

    public void UpdateDamage()
    {
        int equipement = GameHandler.instance.selectedTool;
        if (InventoryHandler.instance.IsEnough(GameHandler.instance.tools[equipement], 1))
        {
            damage = equipementDamage[equipement];
        }
        else
        {
            damage = equipementDamage[equipementDamage.Length - 1];
        }
    }

    public override void Die()
	{
        if (InventoryHandler.instance.IsEnough(ItemType.Human, 2))
        {
            InventoryHandler.instance.Remove(ItemType.Human, 1);
            GameObject toDestroy = transform.parent.gameObject;
            HumanHandler.instance.NewPlayer();
            Destroy(toDestroy);
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
            Destroy(transform.parent.gameObject);
        }
    }

    public void SetNewPlayer(Transform newPlayer)
    {
        FightingBehavior newFightStats = newPlayer.GetComponentInChildren<FightingBehavior>();
        hpMax = newFightStats.hpMax;
        hp = newFightStats.getHP;
    }
}

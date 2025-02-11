using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // 敌人的属性
    public float health;  // 当前血量
    public float maxHealth;  // 最大血量
    public float attack;  // 攻击力
    public float defense;  // 防御力
    //public float moveSpeed;  // 移动速度
    public float attackRange;  // 敌人的攻击范围
    public Transform player;  // 目标玩家
    private Player playerScript;  // 引用玩家脚本

    void Start()
    {
        // 初始化属性
        maxHealth = 50f;  // 敌人的最大血量
        health = maxHealth;
        attack = 8f;  // 敌人的攻击力
        defense = 3f;  // 敌人的防御力
        //moveSpeed = 3f;  // 控制敌人移动速度
        attackRange = 1f;  // 设置敌人攻击范围小于玩家，比如1米

        playerScript = player.GetComponent<Player>();
    }

    void Update()
    {
        // 仅在玩家存活时才检查攻击和敌人状态
        if (playerScript != null && playerScript.isAlive)
        {
            Vector2 playerPos2D = new Vector2(player.position.x, player.position.y);
            Vector2 enemyPos2D = new Vector2(transform.position.x, transform.position.y);

            if (Vector2.Distance(playerPos2D, enemyPos2D) <= attackRange)
            {
                AttackPlayer();
            }
        }

        // 检查敌人是否死亡
        if (health <= 0)
        {
            Die();
        }
    }

    // 敌人受到伤害，减去防御后的血量
    public void TakeDamage(float damage)
    {
        float actualDamage = damage - defense;
        if (actualDamage < 0) actualDamage = 0;
        health -= actualDamage;

        Debug.Log("Enemy took " + actualDamage + " damage. Health left: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    // 当敌人死亡时调用的函数
    private void Die()
    {
        Debug.Log("Enemy died!");

        // 销毁当前 GameObject (敌人预制体)
        Destroy(gameObject);
    }

    // 敌人的攻击逻辑（可以和玩家交互）
    void AttackPlayer()
    {
        Player playerScript = player.GetComponent<Player>();
        playerScript.TakeDamage(attack);
        Debug.Log("Enemy attacked the player!");
    }
}
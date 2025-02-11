using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class Player : MonoBehaviour
{
    // 人物属性
    public int level;  // 等级
    public float health;  // 当前血量
    public float maxHealth;  // 最大血量
    public float attack;  // 攻击力
    public float defense;  // 防御力
    public float attackRange; // 攻击范围
    public LayerMask enemyLayer;  // 敌人所在的层，用于检测敌人
    public Transform attackPoint; // 攻击点（如剑挥动的位置）
    public bool isAlive = true; // 玩家是否存活

    // 使用标签找到场景中的所有敌人
    public string enemyTag = "Enemy";  // 敌人的标签


    void Start()
    {
        // 初始设置
        level = 1;
        maxHealth = 100f;
        health = maxHealth;
        attack = 10f;
        defense = 5f;
        attackRange = 10f;  // 设置为5米的攻击范围


    }

    // 更新人物状态（如移动、检测是否死亡等）
    void Update()
    {
        if (isAlive && Input.GetMouseButtonDown(0))
        {
            AttackClosestEnemy();
        }

        // 检查血量是否为 0 或更低，如果是则调用死亡函数
        if (health <= 0)
        {
            Die();
        }
    }

    // 人物受到伤害，减去防御后的血量
    public void TakeDamage(float damage)
    {
        float actualDamage = damage - defense;
        if (actualDamage < 0) actualDamage = 0;
        health -= actualDamage;

        Debug.Log("Player took " + actualDamage + " damage. Health left: " + health);
    }

    // 攻击函数
    void PerformAttack()
    {
        // 在攻击点位置生成一个圆形范围，检测范围内的敌人
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayer);

        // 对每个敌人造成伤害
        foreach (Collider enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attack);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        // 在场景中绘制攻击范围
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    // 当人物死亡时调用的函数
    private void Die()
    {
        Debug.Log("Player died!");
        isAlive = false; // 玩家是否存活

        // 销毁当前 GameObject (人物预制体)
        Destroy(gameObject);

        // 重启场景
        SceneManager.LoadScene("Battle");
    }

    // 人物升级时调用的函数，可以增加等级、攻击力、最大血量等
    public void LevelUp()
    {
        level++;
        maxHealth += 20;  // 每次升级增加最大血量
        attack += 5;  // 提高攻击力
        defense += 2;  // 提高防御力
        health = maxHealth;  // 恢复到最大血量

        Debug.Log("Player leveled up to " + level + "!");
    }

    void AttackClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);  // 查找所有带有Enemy标签的敌人
        GameObject closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        Vector2 playerPos2D = new Vector2(transform.position.x, transform.position.y);

        // 遍历所有敌人，找到范围内最近的敌人
        foreach (GameObject enemy in enemies)
        {
            Vector2 enemyPos2D = new Vector2(enemy.transform.position.x, enemy.transform.position.y);
            float distanceToEnemy = Vector2.Distance(playerPos2D, enemyPos2D);

            if (distanceToEnemy <= attackRange && distanceToEnemy < closestDistance)
            {
                closestDistance = distanceToEnemy;
                closestEnemy = enemy;
            }
        }

        // 如果找到了最近的敌人且在攻击范围内，则攻击
        if (closestEnemy != null)
        {
            Enemy enemyScript = closestEnemy.GetComponent<Enemy>();
            if (enemyScript != null)
            {
                enemyScript.health -= attack;
                Debug.Log("Player attacks enemy: " + closestEnemy.name);
            }
        }
        else
        {
            Debug.Log("No enemies in range to attack.");
        }
    }
}
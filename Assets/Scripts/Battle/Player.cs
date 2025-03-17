using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class Player : MonoBehaviour
{
    // ��������
    public int level;  // �ȼ�
    public float health;  // ��ǰѪ��
    public float maxHealth;  // ���Ѫ��
    public float attack;  // ������
    public float defense;  // ������
    public float attackRange; // ������Χ
    public LayerMask enemyLayer;  // �������ڵĲ㣬���ڼ�����
    public Transform attackPoint; // �����㣨�罣�Ӷ���λ�ã�
    public bool isAlive = true; // ����Ƿ���

    // ʹ�ñ�ǩ�ҵ������е����е���
    public string enemyTag = "Enemy";  // ���˵ı�ǩ


    void Start()
    {
        // ��ʼ����
        level = 1;
        maxHealth = 100f;
        health = maxHealth;
        attack = 10f;
        defense = 5f;
        attackRange = 10f;  // ����Ϊ5�׵Ĺ�����Χ


    }

    // ��������״̬�����ƶ�������Ƿ������ȣ�
    void Update()
    {
        if (isAlive && Input.GetMouseButtonDown(0))
        {
            AttackClosestEnemy();
        }

        // ���Ѫ���Ƿ�Ϊ 0 ����ͣ�������������������
        if (health <= 0)
        {
            Die();
        }
    }

    // �����ܵ��˺�����ȥ�������Ѫ��
    public void TakeDamage(float damage)
    {
        float actualDamage = damage - defense;
        if (actualDamage < 0) actualDamage = 0;
        health -= actualDamage;

        Debug.Log("Player took " + actualDamage + " damage. Health left: " + health);
    }

    // ��������
    void PerformAttack()
    {
        // �ڹ�����λ������һ��Բ�η�Χ����ⷶΧ�ڵĵ���
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayer);

        // ��ÿ����������˺�
        foreach (Collider enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attack);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        // �ڳ����л��ƹ�����Χ
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    // ����������ʱ���õĺ���
    private void Die()
    {
        Debug.Log("Player died!");
        isAlive = false; // ����Ƿ���

        // ���ٵ�ǰ GameObject (����Ԥ����)
        Destroy(gameObject);

        // ��������
        SceneManager.LoadScene("Battle");
    }

    // ��������ʱ���õĺ������������ӵȼ��������������Ѫ����
    public void LevelUp()
    {
        level++;
        maxHealth += 20;  // ÿ�������������Ѫ��
        attack += 5;  // ��߹�����
        defense += 2;  // ��߷�����
        health = maxHealth;  // �ָ������Ѫ��

        Debug.Log("Player leveled up to " + level + "!");
    }

    void AttackClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);  // �������д���Enemy��ǩ�ĵ���
        GameObject closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        Vector2 playerPos2D = new Vector2(transform.position.x, transform.position.y);

        // �������е��ˣ��ҵ���Χ������ĵ���
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

        // ����ҵ�������ĵ������ڹ�����Χ�ڣ��򹥻�
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
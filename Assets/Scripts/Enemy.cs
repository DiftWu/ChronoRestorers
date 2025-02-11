using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // ���˵�����
    public float health;  // ��ǰѪ��
    public float maxHealth;  // ���Ѫ��
    public float attack;  // ������
    public float defense;  // ������
    //public float moveSpeed;  // �ƶ��ٶ�
    public float attackRange;  // ���˵Ĺ�����Χ
    public Transform player;  // Ŀ�����
    private Player playerScript;  // ������ҽű�

    void Start()
    {
        // ��ʼ������
        maxHealth = 50f;  // ���˵����Ѫ��
        health = maxHealth;
        attack = 8f;  // ���˵Ĺ�����
        defense = 3f;  // ���˵ķ�����
        //moveSpeed = 3f;  // ���Ƶ����ƶ��ٶ�
        attackRange = 1f;  // ���õ��˹�����ΧС����ң�����1��

        playerScript = player.GetComponent<Player>();
    }

    void Update()
    {
        // ������Ҵ��ʱ�ż�鹥���͵���״̬
        if (playerScript != null && playerScript.isAlive)
        {
            Vector2 playerPos2D = new Vector2(player.position.x, player.position.y);
            Vector2 enemyPos2D = new Vector2(transform.position.x, transform.position.y);

            if (Vector2.Distance(playerPos2D, enemyPos2D) <= attackRange)
            {
                AttackPlayer();
            }
        }

        // �������Ƿ�����
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

        Debug.Log("Enemy took " + actualDamage + " damage. Health left: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    // ����������ʱ���õĺ���
    private void Die()
    {
        Debug.Log("Enemy died!");

        // ���ٵ�ǰ GameObject (����Ԥ����)
        Destroy(gameObject);
    }

    // ���˵Ĺ����߼������Ժ���ҽ�����
    void AttackPlayer()
    {
        Player playerScript = player.GetComponent<Player>();
        playerScript.TakeDamage(attack);
        Debug.Log("Enemy attacked the player!");
    }
}
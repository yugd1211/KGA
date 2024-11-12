using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.ParticleSystem;

public class Enemy : MonoBehaviour
{
    public float hp = 100f;
    public float damage = 10f;
    public float moveSpeed = 3f;
    public float damageInterval = 1f;
    public Image hpBar;
    public Player player;
    public ParticleSystem impactParticle;

    public float hpAmount { get { return hp / maxHp; } }
    private float maxHp;
    private Rigidbody2D rb;
    private Coroutine attackCoroutine;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        maxHp = hp;
    }

    private void Start()
    {
        PoolManager.Instance.CreatePool(impactParticle);
    }

    private void OnEnable()
    {
        GameManager.Instance.enemyAllKillEvent += Die;
        GameManager.Instance.enemies.Add(this);
        player = GameManager.Instance.player;
        hp = maxHp;
    }

    private void Update()
    {
        Vector2 moveDir = player.transform.position - transform.position;
        moveDir = moveDir.normalized;
        // image?????떔嶺??imagetype?????떔嶺??filled?????떔嶺????諛멥럪????????????떔嶺????諛멥럪???????????떔嶺???????떔??癲ル슢???몃쨨?
        hpBar.fillAmount = hpAmount;
        Move(moveDir);
    }
    private void Move(Vector2 dir)
    {
        Vector2 movePos = rb.position + (dir * moveSpeed * Time.deltaTime);
        rb.MovePosition(movePos);
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        GameManager.Instance.enemyAllKillEvent -= Die;
        GameManager.Instance.enemies.Remove(this);
        GameManager.Instance.player.KillCount++;
        GameManager.Instance.player.TotalKillCount++;
        GameManager.Instance.itemSpawner.SpawnExp(transform.position);
        PoolManager.Instance.Remove(this);
        // PoolManager.Instance.enemyPool.Push(this);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            ParticleSystem particle = Instantiate(impactParticle);
            // ParticleSystem particle = PoolManager.Instance.Get<ParticleSystem>();
            particle.gameObject.SetActive(true);
            particle.transform.position = other.GetContact(0).point;
            particle.Play();
            // _ = StartCoroutine(DistroyCoroutine(particle));
            Destroy(particle.gameObject, 2f);
            attackCoroutine = StartCoroutine(AttackCoroutine(other));
        }
    }

    private IEnumerator DistroyCoroutine(ParticleSystem particle)
    {
        yield return new WaitForSeconds(2f);
        PoolManager.Instance.Remove(particle);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player"))
            StopCoroutine(attackCoroutine);
    }


    private IEnumerator AttackCoroutine(Collision2D target)
    {
        while (true)
        {
            player.TakeDamage(damage);
            yield return new WaitForSeconds(damageInterval);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage;
    public float moveSpeed;
    public float duration;
    public ParticleSystem impactParticle;

    public int pierceCount = 0;


    private CircleCollider2D coll;

    private void Awake()
    {
        coll = GetComponent<CircleCollider2D>();
        // coll.enabled = false;
    }

    private void OnEnable() // start占쏙옙占쏙옙 占쏙옙占쏙옙 占쏙옙占쏙옙占?
    {
        //LeanPool.Despawn(this, duration); // 3占쏙옙 占쌘울옙 풀占쏙옙 占쏙옙占싣곤옙
        StartCoroutine(PushDelay(duration));
    }


    List<Collider2D> contactedColls = new List<Collider2D>();
    // OverlapCircle 占쌉쇽옙占쏙옙 占쏙옙占쏙옙 占쏙옙占쏙옙占쏙옙 占쏙옙占쏙옙 占쌍댐옙 占쌥띰옙占싱댐옙占쏙옙 占쏙옙占쏙옙 List

    private void Update()
    {
        Move(Vector2.up);
    }

    public void Move(Vector2 dir)
    {
        transform.Translate(dir * moveSpeed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            // other.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            // ParticleSystem p = Instantiate(impactParticle, transform.position, Quaternion.identity);
            // p.Play();
            pierceCount--;
            ParticleSystem p = Instantiate(impactParticle, transform.position, Quaternion.identity);
            other.GetComponent<Enemy>()?.TakeDamage(damage);
            p.Play();
            Destroy(p.gameObject, 2f);
            if (pierceCount == 0)
            {
                PoolManager.Instance.Remove(this);
            }
        }
    }
    private IEnumerator PushDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        PoolManager.Instance.Remove(this);
    }

    private void OnDisable()
    {
        contactedColls.Clear();
    }
}

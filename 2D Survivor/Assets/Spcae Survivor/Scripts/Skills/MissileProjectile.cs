using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MissileProjectile : MonoBehaviour
{
    public float damage;
    public float duration;

    CircleCollider2D coll;

    private Transform rendererTransform;

    public Vector2 rendererStartPos; // 占쏙옙탄占쏙옙 占쏙옙占쏙옙占쏙옙占쏙옙 占쏙옙, sprite renderer占쏙옙 占쏙옙占쏙옙 占쏙옙치(local pos)

    private void Awake()
    {
        coll = GetComponent<CircleCollider2D>();
        coll.enabled = false;
        rendererTransform = transform.Find("Renderer");
    }
    private void Start()
    {
        _ = StartCoroutine(Explosion());
    }

    private IEnumerator Explosion()
    {
        float startTime = Time.time;
        float endTime = startTime + duration;
        rendererTransform.localPosition = rendererStartPos;
        while (Time.time < endTime)
        {
            yield return null;
            float t = (Time.time - startTime) / duration;
            Vector2 curRendpos = Vector2.Lerp(rendererStartPos, Vector2.zero, t);
            rendererTransform.localPosition = curRendpos;
        }


        Collider2D[] contactedColl = Physics2D.OverlapCircleAll(transform.position, coll.radius);
        foreach (Collider2D coll in contactedColl)
        {
            if (coll.CompareTag("Enemy") && coll.TryGetComponent<Enemy>(out Enemy enemy))
                enemy.TakeDamage(damage);
        }
        PoolManager.Instance.Remove(this);
    }
    // 占쏙옙占쏙옙占쏙옙 占쏙옙치占쏙옙占쏙옙 占쏙옙占쏙옙 占시곤옙 占식울옙 占쏙옙占쏙옙 占쏙옙占쏙옙 占쏙옙占쏙옙占쏙옙 占쏙옙占쏙옙占쏙옙占쏙옙 占쌍곤옙 占쏙옙占쏙옙占?
}

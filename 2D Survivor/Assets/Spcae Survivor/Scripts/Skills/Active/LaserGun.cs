using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LaserGun : Skill
{
    public Transform target;

    public float duration;
    public float moveSpeed;
    public int pierceCount;

    public int projectileCount;

    public AudioClip fireAudioClip;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    protected virtual void Start()
    {
        _ = StartCoroutine(FireCoroutine());
    }
    protected virtual IEnumerator FireCoroutine()
    {
        while (true)
        {
            int count = projectileCount + GameManager.Instance.player.projectileCount;
            for (int i = 0; i < count; i++)
            {
                Fire();
                yield return new WaitForSeconds(interval / count);
            }
            yield return new WaitForSeconds(interval);
        }
    }

    // update占쏙옙占쏙옙 占쏙옙占쏙옙微占?占쌉뤄옙占쏙옙占쏙옙占쏙옙 true占쏙옙 占쏙옙占?占쌕뀐옙占쌔댐옙.
    // 占쌓뤄옙占쏙옙 占쏙옙占쏙옙占쏙옙 占쌉력뱄옙占쏙옙 占십억옙占쏙옙占쏙옙 false占쏙옙 占쌕꾸깍옙 占쏙옙占쏙옙 LateUpdate占쏙옙占쏙옙 false占쏙옙 占쌕뀐옙占쌔댐옙.

    //public override void UseSkill(Transform target)
    //{
    //	dir = target.position - transform.position;
    //}


    protected virtual void Fire()
    {
        //transform.up = dir;
        transform.up = GameManager.Instance.player.fireDir;
        // Projectile projectile = PoolManager.Instance.projectilePool.Pop();
        Projectile projectile = PoolManager.Instance.Get<Projectile>();
        projectile.gameObject.SetActive(true);
        projectile.transform.position = transform.position;
        projectile.damage = Damage;
        projectile.duration = duration;
        projectile.moveSpeed = moveSpeed;
        projectile.pierceCount = pierceCount;
        projectile.transform.up = GameManager.Instance.player.fireDir;
        audioSource.PlayOneShot(fireAudioClip);
    }

}

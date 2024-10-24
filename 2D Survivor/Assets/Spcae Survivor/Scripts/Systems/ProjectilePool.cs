using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
	public static ProjectilePool pool;

	public Projectile ProjectilePrefab;

	private void Awake()
	{
		pool = this;
	}

	List<Projectile> poolList = new();
	/// <summary>
	/// 투사체 꺼내오기
	/// </summary>
	/// <returns>꺼내온 투사체</returns>
	public Projectile Pop()
	{
		if (poolList.Count <= 0)
			poolList.Add(Instantiate(ProjectilePrefab));
		Projectile proj = poolList[0];

		poolList.Remove(proj);

		proj.gameObject.SetActive(true);
		proj.transform.SetParent(null, false);
		return proj;
	}

	/// <summary>
	/// 다 쓴 투사체 도로 집어넣기
	/// </summary>
	/// <param name="proj">다 쓴 투사체</param>
	public void Push(Projectile proj)
	{
		poolList.Add(proj);
		proj.gameObject.SetActive(false);
		proj.transform.SetParent(transform, false);
	}

	public void Push(Projectile proj, float delay)
	{
		StartCoroutine(PushCoroutine(proj, proj.duration));
	}

	private IEnumerator PushCoroutine(Projectile proj, float delay)
	{
		yield return new WaitForSeconds(delay);
		Push(proj);
	}
	/// <summary>
	/// 다 쓴 투사체 잠시 후에 집어넣기
	/// </summary>
	/// <param name="proj">다 쓴 투사체</param>
	/// <param name="delay">지연 시간</param>


}

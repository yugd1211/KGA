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
	/// ����ü ��������
	/// </summary>
	/// <returns>������ ����ü</returns>
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
	/// �� �� ����ü ���� ����ֱ�
	/// </summary>
	/// <param name="proj">�� �� ����ü</param>
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
	/// �� �� ����ü ��� �Ŀ� ����ֱ�
	/// </summary>
	/// <param name="proj">�� �� ����ü</param>
	/// <param name="delay">���� �ð�</param>


}

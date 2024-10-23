using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour, IContactable
{
	public ParticleSystem particle;
	public virtual void Contact()
	{
		ParticleSystem p = Instantiate(this.particle, transform.position, Quaternion.identity);
		p.Play();
		Destroy(p.gameObject, p.main.duration);
		Destroy(gameObject);
	}
}


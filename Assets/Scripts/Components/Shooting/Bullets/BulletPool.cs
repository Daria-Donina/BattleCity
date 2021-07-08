using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Components.Shooting.Bullets
{
	public class BulletPool : ObjectPool<Bullet>
	{
		//[SerializeField]
		//private int bulletsAmount = 10;
		//[SerializeField]
		//private Bullet bulletPrefab;

		//private readonly Queue<Bullet> _bulletsPool = new Queue<Bullet>();

		//private void Awake()
		//{
		//	for (int i = 0; i < bulletsAmount; i++)
		//	{
		//		_bulletsPool.Enqueue(CreateBullet());
		//	}
		//}

		//public Bullet GetBullet(Vector3 position)
		//{
		//	Bullet bullet;

		//	if (_bulletsPool.Count == 0)
		//	{
		//		bulletsAmount++;
		//		bullet = CreateBullet();
		//	}
		//	else
		//	{
		//		bullet = _bulletsPool.Dequeue();
		//	}

		//	bullet.gameObject.SetActive(true);
		//	bullet.transform.position = position;
		//	return bullet;
		//}

		//public void ReturnBullet(Bullet bullet)
		//{
		//	bullet.gameObject.SetActive(false);
		//	bullet.transform.SetParent(transform);
		//	bullet.transform.position = transform.position;
		//	bullet.transform.rotation = transform.rotation;

		//	_bulletsPool.Enqueue(bullet);
		//}

		//private Bullet CreateBullet()
		//{
		//	var bullet = Instantiate(bulletPrefab, transform);

		//	bullet.transform.SetParent(transform);
		//	bullet.gameObject.SetActive(false);

		//	return bullet;
		//}
	}
}
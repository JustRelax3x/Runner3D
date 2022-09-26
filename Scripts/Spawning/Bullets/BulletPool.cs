using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour, IPool
{
    [SerializeField]
    private Bullet _bulletPrefab;

    private readonly Queue<Bullet> _bulletsPool = new Queue<Bullet>();

    private const int QUANTITY_BULLETS = 3;

    public static BulletPool Instance;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        if (Instance != null)
        {
            Debug.LogError("Can't be 2 pools" + this);
            return;
        }
        for (var i = 0; i < QUANTITY_BULLETS; ++i)
        {
            _bulletsPool.Enqueue(CreateBullet());
        }
        Instance = this;
    }

    private Bullet CreateBullet()
    {
        var bullet = Instantiate(_bulletPrefab, transform, false);
        bullet.SetPool(this);
        bullet.gameObject.SetActive(false);
        return bullet;
    }

    public Bullet GetBullet(Vector3 position)
    {
        Bullet result = _bulletsPool.Count == 0 ? CreateBullet() : _bulletsPool.Dequeue();

        result.gameObject.SetActive(true);
        result.transform.position = position;
        return result;
    }

    public void ReturnBullet(Bullet bullet)
    {
        bullet.transform.position = new Vector3(-100, bullet.transform.position.y, -10);
        bullet.gameObject.SetActive(false);
        _bulletsPool.Enqueue(bullet);
    }

    private void OnDestroy()
    {
        Instance = null;
    }

    public void ReturnToPool(GameObject gameObject)
    {
        if (gameObject.TryGetComponent(out Bullet bullet))
            ReturnBullet(bullet);
    }
}
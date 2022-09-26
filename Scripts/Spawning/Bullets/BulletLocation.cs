using UnityEngine;
public class BulletLocation : BehaviorLocation
{
    public override LocationType GetLocationType() => LocationType.Bullet;

    private const float _maxOffset = 15f, _minOffset = 2f;

    private Bullet[] _bullets = new Bullet[3];

    private void SpawnBullets(Vector3 targetPos)
    {
        float offsetX = Random.Range(_minOffset, _maxOffset);
        float offsetZ = (transform.position.z - targetPos.z) / 2f;
        Vector3 offset = new Vector3(-offsetX * 2, 0, offsetZ);
        Vector3 destination = transform.position;
        destination.z -= 5 * offsetZ;
        for (int i = 0; i < _bullets.Length; i++)
        {
            offset.x += offsetX;
            Bullet bullet = BulletPool.Instance.GetBullet(transform.position + offset);
            bullet.transform.LookAt(destination);
            _bullets[i] = bullet;
        }
    }

    public override void Recycle()
    {
        foreach (var b in _bullets) b.Recycle();
        _pool.ReturnToPool(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CharacterController _))
            SpawnBullets(other.transform.position);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out CharacterController _))
            Recycle();
    }
}
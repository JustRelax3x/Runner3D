using UnityEngine;

[RequireComponent(typeof(Collider))]
public class BulletSpawner : MonoBehaviour
{
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

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(GameConstants.PlayerTag)) return;
        SpawnBullets(other.transform.position);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag(GameConstants.PlayerTag)) return;
        foreach (var b in _bullets) BulletPool.Instance.ReturnBullet(b);
        gameObject.SetActive(false); //To Do ObjectPool.Return
    }
}
using System.Collections;
using UnityEngine;

public class Catapult : MonoBehaviour
{
    [SerializeField] private SpringJoint _springPoint;
    [SerializeField] private Rigidbody _catapultStick;
    [SerializeField] private float _tensionAtLaunch;
    [SerializeField] private Transform _projectileSpawnPoint;
    [SerializeField] private Projectile _prefab;
    [SerializeField] private float _projectileSpawnTime;

    private WaitForSeconds _projectileSpawnDelay;

    private void Awake()
    {
        _projectileSpawnDelay = new WaitForSeconds(_projectileSpawnTime);
    }

    public void Launch()
    {
        _catapultStick.WakeUp();
        _springPoint.spring = _tensionAtLaunch;
    }

    public void Reload()
    {
        _catapultStick.WakeUp();
        _springPoint.spring = 0;
        StartCoroutine(SpawnProjectile());
    }

    private IEnumerator SpawnProjectile()
    {
        yield return _projectileSpawnDelay;
        Instantiate(_prefab, _projectileSpawnPoint.position, Quaternion.identity);
    }
}

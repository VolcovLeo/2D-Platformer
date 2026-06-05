using System.Collections;
using UnityEngine;

namespace Platformer
{
    public class CoinSpawner : MonoBehaviour
    {
        [SerializeField] private Coin _coinPrefab;
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private float _respawnDelay = 3f;

        private void Start()
        {
            foreach (Transform point in _spawnPoints)
            {
                SpawnCoin(point);
            }
        }

        private void SpawnCoin(Transform point)
        {
            Coin coin = Instantiate(_coinPrefab, point.position, Quaternion.identity);

            coin.Collected += OnCoinCollected;
        }

        private void OnCoinCollected(Coin coin)
        {
            coin.Collected -= OnCoinCollected;

            Transform point = GetClosestSpawnPoint(coin.transform.position);

            Destroy(coin.gameObject);

            StartCoroutine(RespawnAfterDelay(point));
        }

        private IEnumerator RespawnAfterDelay(Transform point)
        {
            yield return new WaitForSeconds(_respawnDelay);

            SpawnCoin(point);
        }

        private Transform GetClosestSpawnPoint(Vector3 position)
        {
            Transform closestPoint = _spawnPoints[0];

            float minDistance = (closestPoint.position - position).sqrMagnitude;

            foreach (Transform point in _spawnPoints)
            {
                float distance = (point.position - position).sqrMagnitude;

                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestPoint = point;
                }
            }

            return closestPoint;
        }
    }
}
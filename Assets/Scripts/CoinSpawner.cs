using System.Collections;
using UnityEngine;

namespace Platformer
{
    public class CoinSpawner : MonoBehaviour
    {
        [SerializeField] private Coin coinPrefab;
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private float respawnDelay = 3f;

        private void Start()
        {
            foreach (Transform point in spawnPoints)
            {
                SpawnCycle(point);
            }
        }

        private void SpawnCycle(Transform point)
        {
            StartCoroutine(SpawnRoutine(point));
        }

        private IEnumerator SpawnRoutine(Transform point)
        {
            while (true)
            {
                Coin coin = Instantiate(coinPrefab, point.position, Quaternion.identity);
                coin.Collected += OnCoinCollected;

                yield return new WaitUntil(() => coin == null || coin.gameObject.activeSelf == false);

                coin.Collected -= OnCoinCollected;

                yield return new WaitForSeconds(respawnDelay);
            }
        }

        private void OnCoinCollected(Coin coin)
        {
            coin.Collected -= OnCoinCollected;
            Destroy(coin.gameObject);
        }
    }
}
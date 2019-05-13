using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject circleGreenPrefab;
    [SerializeField] private GameObject circleBlackPrefab;
    [SerializeField] private Transform parent;
    [SerializeField] private RectTransform canvas;
    [SerializeField] private RectTransform HUD;
    [SerializeField] private float spawnDelay = 3;
    private float spawnTimer = 0;
    private float NewSpawnDelay => spawnDelay - 3 * spawnDelay / 28;
    private List<Vector2> spawnPositions = new List<Vector2>();

    private void Start()
    {
        for (int i = 0; i < parent.childCount; i++)
        {
            var circle = parent.GetChild(i);
            Vector2 position = circle.GetComponent<RectTransform>().position;
            spawnPositions.Add(position);
            StartCoroutine(ClearSpawnPosition(position, circle.GetComponent<Circle>().lifespan));
        }
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnDelay && Time.deltaTime != 0)
        {
            GameObject circlePrefab = Random.Range(0, 10) > 0 ? circleGreenPrefab : circleBlackPrefab;
            Vector2 circleSize = circlePrefab.GetComponent<RectTransform>().rect.size;
            float posX = Random.Range(0 + circleSize.x, canvas.rect.width - circleSize.x);
            float posY = Random.Range(0 + circleSize.y, canvas.rect.height - HUD.rect.height - circleSize.y);
            Vector3 newPosition = new Vector2(posX, posY);

            foreach (Vector2 position in spawnPositions)
                if (Vector2.Distance(position, newPosition) < circleSize.x)
                    return;

            GameObject newCircle = Instantiate(circlePrefab, parent);

            spawnPositions.Add(newPosition);
            StartCoroutine(ClearSpawnPosition(newPosition, newCircle.GetComponent<Circle>().lifespan));
            newCircle.GetComponent<RectTransform>().position = newPosition;
            
            spawnTimer = 0;
            spawnDelay = NewSpawnDelay;
        }
    }

    private IEnumerator ClearSpawnPosition(Vector2 position, float delay)
    {
        yield return new WaitForSeconds(delay);
        spawnPositions.Remove(position);
    }
}

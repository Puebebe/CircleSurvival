using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject circleGreenPrefab;
    [SerializeField] private GameObject circleBlackPrefab;
    [SerializeField] private Transform canvas;
    [SerializeField] private RectTransform HUD;
    [SerializeField] private float spawnDelay = 3;
    private float spawnTimer = 0;
    
    private void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnDelay)
        {
            Rect canvasField = canvas.GetComponent<RectTransform>().rect;
            GameObject newCircle = Random.Range(0, 10) > 0 ? Instantiate(circleGreenPrefab, canvas) : Instantiate(circleBlackPrefab, canvas);
            Vector2 circleSize = newCircle.GetComponent<RectTransform>().rect.size;
            float posX = Random.Range(0 + circleSize.x, canvasField.width - circleSize.x);
            float posY = Random.Range(0 + circleSize.y, canvasField.height - HUD.rect.height - circleSize.y);
            newCircle.GetComponent<RectTransform>().position = new Vector2(posX, posY);

            spawnTimer = 0;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject circlePrefab;

    private void Start()
    {
        Instantiate(circlePrefab, transform);
    }
    
    private void Update()
    {
        
    }
}

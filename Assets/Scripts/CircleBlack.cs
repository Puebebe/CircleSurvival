using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleBlack : Circle
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(Lose);
    }

    private void Lose()
    {
        Debug.Log("przegranko (czarne)");
    }
}

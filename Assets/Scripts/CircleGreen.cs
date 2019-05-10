using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleGreen : Circle
{
    Image fill;

    private void Start()
    {
        lifespan = Random.Range(2f, 4f);
        fill = transform.GetChild(0).GetComponent<Image>();
        GetComponent<Button>().onClick.AddListener(Delete);
    }

    private new void Update()
    {
        base.Update();
        SetFillAmount();
    }

    protected override void Die()
    {
        Debug.Log("przegranko (zielone)");
        Destroy(gameObject);
    }

    private void SetFillAmount()
    {
        fill.fillAmount = lifetime / lifespan;
    }

    private void Delete()
    {
        Destroy(gameObject);
    }
}

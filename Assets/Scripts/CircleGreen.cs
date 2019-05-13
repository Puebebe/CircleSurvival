using UnityEngine;
using UnityEngine.UI;

public class CircleGreen : Circle
{
    private Image fill;

    private void Start()
    {
        lifespan = Random.Range(2f, 4f);
        fill = transform.GetChild(0).GetComponent<Image>();
        GetComponent<Button>().onClick.AddListener(() => Destroy(gameObject));
    }

    private new void Update()
    {
        base.Update();
        SetFillAmount();
    }

    protected override void Die()
    {
        Destroy(gameObject);
        Game.EndGame();
    }

    private void SetFillAmount()
    {
        fill.fillAmount = lifetime / lifespan;
    }
}

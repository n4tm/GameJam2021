using System;
using UnityEngine;

public class CircleRender : MonoBehaviour
{
    [SerializeField] public GameObject circleRender;
    private CircleCollider2D _areaRender;
    private float _radius;

    private void Awake()
    {
        circleRender.transform.localScale = Vector3.one;
    }

    private void Start()
    {
        _areaRender = GetComponent<CircleCollider2D>();
        _radius = _areaRender.radius;
        circleRender.transform.localScale += Vector3.one * 2 * _radius;
    }

    public void ShowCircle()
    {
        circleRender.SetActive(true);
    }

    public void HideCircle()
    {
        circleRender.SetActive(false);
    }
}

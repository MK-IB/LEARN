using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TouchEffect : MonoBehaviour
{
    public RectTransform circle1;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DOTween.Sequence().Append(circle1.DOScale(Vector3.one * 0.5f, 0.3f)).Append(circle1.DOScale(Vector3.one * 0.65f, 0.3f));
        }
        if (Input.GetMouseButtonUp(0))
        {
            DOTween.Sequence().Append(circle1.DOScale(Vector3.one * 1.3f, 0.3f)).Append(circle1.DOScale(Vector3.one, 0.3f));
        }
        if (Input.GetMouseButton(0))
        {
            circle1.position = Input.mousePosition;
        }
    }
}

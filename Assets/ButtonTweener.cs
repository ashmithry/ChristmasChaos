using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonTweener : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        LeanTween.reset();
        LeanTween.scale(gameObject, new Vector3(1.15f, 1.15f, 1), 0.1f).setEase(LeanTweenType.easeInExpo);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        LeanTween.reset();
        LeanTween.scale(gameObject, new Vector3(1f, 1f, 1), 0.1f).setEase(LeanTweenType.easeInExpo);
    }
}

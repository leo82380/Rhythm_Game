using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Setting : MonoBehaviour, IPointerClickHandler
{
    public enum ButtonType
    {
        Setting,
        Back
    }
    [SerializeField] private ButtonType _buttonType;
    [SerializeField] private Ease _ease;
    [SerializeField] private float _duration;
    public void OnPointerClick(PointerEventData eventData)
    {
        if(_buttonType == ButtonType.Setting)
            transform.parent.DOMoveX(0f, _duration).SetEase(_ease);
        else if(_buttonType == ButtonType.Back)
            transform.parent.DOMoveX(17.7f, _duration).SetEase(_ease);
    }
}

using UnityEngine;

public class MenuArrow : MonoBehaviour
{
    [SerializeField] private RectTransform arrow;

    public void MoveArrow(RectTransform button)
    {
        arrow.anchoredPosition = button.anchoredPosition;
    }
}

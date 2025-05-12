using UnityEngine;

[ExecuteInEditMode]
public class AlignSpriteToLeftEdge : MonoBehaviour
{
    public RectTransform parentRectTransform;

    void Update()
    {
        AlignToParentLeftEdge();
    }

    void AlignToParentLeftEdge()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();

        if (parentRectTransform == null || rectTransform == null)
        {
            Debug.LogError("Parent RectTransform or this RectTransform is missing.");
            return;
        }

        // Устанавливаем привязки и pivot
        rectTransform.anchorMin = new Vector2(0, 0.5f);
        rectTransform.anchorMax = new Vector2(0, 0.5f);
        rectTransform.pivot = new Vector2(0, 0.5f);

        // Вычисляем ширину и масштаб родителя
        float parentWidth = parentRectTransform.rect.width * parentRectTransform.localScale.x;

        // Вычисляем ширину и масштаб спрайта
        float spriteWidth = rectTransform.rect.width * rectTransform.localScale.x;

        // Устанавливаем позицию спрайта относительно левого края родителя
        float adjustedPositionX = (spriteWidth / 2);
        rectTransform.anchoredPosition = new Vector2(adjustedPositionX, rectTransform.anchoredPosition.y);
    }
}

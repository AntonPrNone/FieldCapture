using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
[RequireComponent(typeof(RectTransform))]
public class SpriteStackPanel : MonoBehaviour
{
    public bool isVertical = true; // true для вертикальной, false для горизонтальной
    public float spacing = 0f; // Расстояние между элементами

    private void OnValidate()
    {
        ArrangeChildren();
    }

    public void ArrangeChildren()
    {
        float offset = 0f;

        foreach (Transform child in transform)
        {
            RectTransform rectTransform = child.GetComponent<RectTransform>();
            if (rectTransform == null || !child.gameObject.activeSelf) continue;

            if (isVertical)
            {
                rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, -offset);
                offset += rectTransform.rect.height * rectTransform.localScale.y + spacing;
            }
            else
            {
                rectTransform.anchoredPosition = new Vector2(offset, rectTransform.anchoredPosition.y);
                offset += rectTransform.rect.width * rectTransform.localScale.x + spacing;
            }
        }
    }
}

[CustomEditor(typeof(SpriteStackPanel))]
public class SpriteStackPanelEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        SpriteStackPanel stackPanel = (SpriteStackPanel)target;

        if (GUILayout.Button("Arrange Children"))
        {
            stackPanel.ArrangeChildren();
        }
    }
}

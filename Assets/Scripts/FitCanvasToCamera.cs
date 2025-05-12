using UnityEngine;

[ExecuteInEditMode]
public class FitObjectToCamera : MonoBehaviour
{
    public Camera mainCamera;
    public Vector2 referenceResolution = new Vector2(1920, 1080); // ������� ����������

    private Canvas canvas;
    private RectTransform rectTransform;

    void Awake()
    {
        canvas = GetComponent<Canvas>();
        rectTransform = GetComponent<RectTransform>();

        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    public void FitObject()
    {
        if (mainCamera == null)
        {
            Debug.LogError("Main camera is not assigned.");
            return;
        }

        // ������ ������ � ����
        float screenHeight = 2f * mainCamera.orthographicSize;
        float screenWidth = screenHeight * mainCamera.aspect;

        if (canvas != null && canvas.renderMode == RenderMode.WorldSpace)
        {
            // ��������������� Canvas �� ������� ������
            rectTransform.sizeDelta = new Vector2(screenWidth, screenHeight);
            rectTransform.position = mainCamera.transform.position + mainCamera.transform.forward * 10f; // �������, ��� Canvas ����� �������
            rectTransform.rotation = mainCamera.transform.rotation;
        }
        else if (rectTransform != null)
        {
            // ��������������� � ���������������� RectTransform �������
            rectTransform.sizeDelta = new Vector2(screenWidth, screenHeight);
            rectTransform.position = mainCamera.transform.position + mainCamera.transform.forward * 10f; // �������, ��� ������ ����� �������
            rectTransform.rotation = mainCamera.transform.rotation;
        }
        else
        {
            // ��������������� � ���������������� �������� GameObject
            transform.localScale = new Vector3(screenWidth / referenceResolution.x, screenHeight / referenceResolution.y, 1);

            // ���������������� ������� �� ������ ������
            Vector3 cameraCenter = mainCamera.ScreenToWorldPoint(new Vector3(mainCamera.pixelWidth / 2, mainCamera.pixelHeight / 2, mainCamera.nearClipPlane));
            transform.position = cameraCenter;
            transform.rotation = mainCamera.transform.rotation;
        }
    }
}

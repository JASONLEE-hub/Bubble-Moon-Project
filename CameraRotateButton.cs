using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraRotateButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField]
    private RectTransform rect_CB_BG;

    [SerializeField]
    private RectTransform rect_CB_Ball;

    [SerializeField]
    private GameObject rotate_Camera;

    private Transform cameraTrans;

    [SerializeField]
    private float rotCamXAxisSpeed = 5;

    [SerializeField]
    private float rotCamYAxisSpeed = 3;

    private float limitMinX = -80;
    private float limitMaxX = 50;
    private float eulerAngleX;
    private float eulerAngleY;
    private float valueX;
    private float valueY;

    private float radius;

    private bool isTouch = false;

    void Start()
    {
        radius = rect_CB_BG.rect.width * 0.5f;
        cameraTrans = rotate_Camera.GetComponent<Transform>();
    }

    void Update()
    {
        if (isTouch)
        {
            UpdateRotate(valueX, valueY, cameraTrans);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 value = eventData.position - (Vector2)rect_CB_BG.position;

        value = Vector2.ClampMagnitude(value, radius); // 가두기 

        rect_CB_Ball.localPosition = value; // 거리 계산하여 볼 위치를 움직이기 위해

        value = value.normalized; // value 속도값 빠지고 방향값만

        float distance = Vector2.Distance(rect_CB_BG.position, rect_CB_Ball.position) / radius;

        valueX = value.x * distance * rotCamXAxisSpeed * Time.deltaTime;
        valueY = value.y * distance * rotCamYAxisSpeed * Time.deltaTime;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isTouch = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isTouch = false;
        rect_CB_Ball.localPosition = Vector3.zero;
        cameraTrans.transform.rotation = Quaternion.Euler(Vector3.zero);
        valueX = 0f;
        valueY = 0f;
    }

    public void UpdateRotate(float valueX, float valueY, Transform trans)
    {
        eulerAngleY += valueX * rotCamYAxisSpeed;
        eulerAngleX += valueY * rotCamXAxisSpeed;

        eulerAngleX = ClampAngle(eulerAngleX, limitMinX, limitMaxX);

        trans.transform.rotation = Quaternion.Euler(-eulerAngleX, eulerAngleY, 0);

        Debug.Log(eulerAngleX);
        Debug.Log(eulerAngleY);

    }

    public float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle += 360;

        return Mathf.Clamp(angle, min, max);
    }
}

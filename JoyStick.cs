using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField]
    private RectTransform rect_Joy_BG;

    [SerializeField]
    private RectTransform rect_Joy_Ball;

    [SerializeField]
    private GameObject go_Player;

    [SerializeField]
    private float moveSpeed;

    private Rigidbody rigid;

    private bool isTouch = false;

    private float h, v;

    private float radius; // 버튼이 배경에 벗어나지 않게 하기 위해 반지름 구하기

    private void Start()
    {
        radius = rect_Joy_BG.rect.width * 0.5f;
    }

    private void Awake()
    {
        rigid = go_Player.GetComponent<Rigidbody>(); // player의 rigid를 가져와라.
    }

    private void FixedUpdate()
    {
        if (isTouch)
        {
            Move(h, v, rigid);
        }
    }


    public void OnDrag(PointerEventData eventData)
    {
        Vector2 value = eventData.position - (Vector2)rect_Joy_BG.position;

        value = Vector2.ClampMagnitude(value, radius); // 가두기 

        rect_Joy_Ball.localPosition = value; // 거리 계산하여 볼 위치를 움직이기 위해

        value = value.normalized; // value 속도값 빠지고 방향값만

        float distance = Vector2.Distance(rect_Joy_BG.position, rect_Joy_Ball.position)/radius; // 거리차 주기 위해 , 반지름 / 반지름 최대 스피드 1 

        h = value.x * distance * moveSpeed * Time.deltaTime;
        v = value.y * distance * moveSpeed * Time.deltaTime;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isTouch = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isTouch = false;
        rect_Joy_Ball.localPosition = Vector3.zero;
        h = 0f;
        v = 0f;
    }

    public void Move(float h, float v,Rigidbody rigid)
    {
        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);
    }

}

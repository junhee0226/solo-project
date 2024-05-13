using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownController
{
    private Camera camera;
    //Scale 값을 건드려 캐릭터 이동방향에 따른 좌우반전은 했는데 마우스 포인트를 따라가는건 모르겠음!
    [SerializeField][Range(1f, 10f)] float moveSpeed = 1f;

    private void Update()
    {
        Vector3 flipMove = Vector3.zero;

        if(Input.GetAxisRaw("Horizontal") < 0)
        {
            flipMove = Vector3.left;
            transform.localScale = new Vector3(-1, 1, 1);
        }

        else if(Input.GetAxisRaw("Horizontal") > 0) 
        { 
            flipMove = Vector3.right;
            transform.localScale = new Vector3(1, 1, 1);
        }

        transform.position += flipMove * moveSpeed * Time.deltaTime;
    }

    private void Awake()
    {
        camera = Camera.main;
    }
    
    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }

    public void ONLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = camera.ScreenToWorldPoint(newAim);
        newAim = (worldPos = (Vector2)transform.position).normalized;

        CallLookEvent(newAim);
    }
}

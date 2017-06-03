using UnityEngine;
using UnityEngine.UI;

public class TouchController : MonoBehaviour
{
    //public Camera backgroundCamera;
    private Vector3 prevPos;

    public float zoomSpeed = 0.001f;
    public float moveSpeed = 0.1f;

    private float upMax;
    private float downMax;
    private float leftMax;
    private float rightMax;

    private float sizeMin;
    private float sizeMax;

    private float startTime;

    private void Start()
    {
        Vector3 downLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        Vector3 upRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        downMax = downLeft.x;
        upMax = upRight.x;
        leftMax = downLeft.y;
        rightMax = upRight.y;

        sizeMin = 1.5f;
        sizeMax = Camera.main.orthographicSize;
    }
        
    void Update()
    {
        if (Input.touchCount == 2)
        {
            zoom();
        }
        else if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            prevPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            startTime = Time.time;
        }
        else if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            swipe();
        }
        else if (/*Input.GetMouseButtonDown(0))*/Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {

            if ((Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position) - prevPos).magnitude < 0.1 && Time.time - startTime < 0.2f)
            {
                click();
            }
        }
    }

    public void zoom()
    {
        float prevSize = Camera.main.orthographicSize;

        // Store both touches.
        Touch touchZero = Input.GetTouch(0);
        Touch touchOne = Input.GetTouch(1);

        // Find the position in the previous frame of each touch.
        Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
        Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

        // Find the magnitude of the vector (the distance) between the touches in each frame.
        float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
        float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

        // Find the difference in the distances between each frame.
        float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

        // ... change the orthographic size based on the change in distance between the touches.
        Camera.main.orthographicSize += deltaMagnitudeDiff * zoomSpeed;
        //backgroundCamera.orthographicSize += deltaMagnitudeDiff * zoomSpeed;

        Camera.main.orthographicSize = Camera.main.orthographicSize < sizeMin ? sizeMin : Camera.main.orthographicSize;
        Camera.main.orthographicSize = Camera.main.orthographicSize > sizeMax ? sizeMax : Camera.main.orthographicSize;

        Vector3 downLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        Vector3 upRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        Camera.main.orthographicSize = downLeft.x < downMax ? prevSize : Camera.main.orthographicSize;
        Camera.main.orthographicSize = downLeft.y < leftMax ? prevSize : Camera.main.orthographicSize;
        Camera.main.orthographicSize = upRight.x > upMax ? prevSize : Camera.main.orthographicSize;
        Camera.main.orthographicSize = upRight.y > rightMax ? prevSize : Camera.main.orthographicSize;

        zoomSpeed = Camera.main.orthographicSize <= 2 ? 0.05f : 0.1f;

        moveSpeed = Camera.main.orthographicSize / 80;
    }

    public void swipe()
    {
        Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
        Vector3 prevPos = transform.position;

        //transform.Translate(Camera.main.ScreenToWorldPoint(touchDeltaPosition));
        transform.Translate(-touchDeltaPosition.x * moveSpeed, -touchDeltaPosition.y * moveSpeed, 0);
        //backgroundCamera.transform.Translate(-touchDeltaPosition.x * moveSpeed, -touchDeltaPosition.y * moveSpeed, 0);

        Vector3 downLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        Vector3 upRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        Camera.main.transform.position = downLeft.x < downMax ? prevPos : transform.position;
        Camera.main.transform.position = downLeft.y < leftMax ? prevPos : transform.position;
        Camera.main.transform.position = upRight.x > upMax ? prevPos : transform.position;
        Camera.main.transform.position = upRight.y > rightMax ? prevPos : transform.position;
    }

    public void click()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(/*Input.mousePosition);*/Input.GetTouch(0).position);

        RaycastHit2D[] hits = Physics2D.RaycastAll(pos, Vector2.zero);

        if (hits.Length > 0 && hits[hits.Length - 1].collider.gameObject.GetComponent<Button>() == null)
        {
            GameData.GAME_TYPE.checkInList(hits[0].collider.gameObject.transform.name, pos);

            /*if (!GameData.GAME_TYPE.GetType().Name.Equals("TimeGame"))
            {
                Destroy(hits[0].collider.gameObject);
            }*/
        }
    }
}
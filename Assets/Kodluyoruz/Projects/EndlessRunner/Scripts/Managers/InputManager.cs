using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


class CardinalDirection
{
    public static readonly Vector2 Up = new Vector2(0, 1);
    public static readonly Vector2 Down = new Vector2(0, -1);
    public static readonly Vector2 Right = new Vector2(1, 0);
    public static readonly Vector2 Left = new Vector2(-1, 0);
    public static readonly Vector2 UpRight = new Vector2(1, 1);
    public static readonly Vector2 UpLeft = new Vector2(-1, 1);
    public static readonly Vector2 DownRight = new Vector2(1, -1);
    public static readonly Vector2 DownLeft = new Vector2(-1, -1);
}

public enum Swipe
{
    None,
    Up,
    Down,
    Left,
    Right,
    UpLeft,
    UpRight,
    DownLeft,
    DownRight
};


public class InputManager : Singleton<InputManager>
{

    private void OnEnable()
    {
        if (Managers.Instance == null)
            return;
    }

    private void OnDisable()
    {
        if (Managers.Instance == null)
            return;
    }


    private void Update()
    {
        if (EventSystem.current == null) return;
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (Input.GetMouseButton(0))
        {
            LevelManager.Instance.StartLevel();
        }

        TapInput();
        SwipeInput();
    }
    #region Tap Input

    private float tapInputDownTime;
    private float tapDuration;
    private void TapInput()
    {
        //Editor Input
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
            tapInputDownTime = Time.time;

        if (Input.GetMouseButtonUp(0))
        {
            tapDuration = Mathf.Abs(tapInputDownTime - Time.time);

            if (tapDuration < 0.2f)
            {
                EventManager.OnTapDetected.Invoke();
                //Debug.Log("Tap " + tapDuration);
            }
            tapDuration = 0;

        }
#else //Android and IOS Input


        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    tapInputDownTime = Time.time;
                    break;
                case TouchPhase.Moved:
                    break;
                case TouchPhase.Stationary:
                    break;
                case TouchPhase.Ended:
                    tapDuration = Mathf.Abs(tapInputDownTime - Time.time);

                    if (tapDuration < 0.2f)
                    {
                        OnTapInput.Invoke();
                        Debug.Log("Tap " + tapDuration);
                    }
                    tapDuration = 0;
                    GameManager.Instance.StartGame();
                    LevelManager.Instance.StartLevel();
                    break;
                case TouchPhase.Canceled:
                    tapDuration = Mathf.Abs(tapInputDownTime - Time.time);

                    if (tapDuration < 0.2f)
                    {
                        OnTapInput.Invoke();
                        Debug.Log("Tap " + tapDuration);
                    }
                    tapDuration = 0;
                    break;
                default:
                    break;
            }
        }
#endif
    }
    #endregion

    #region Swipe Input

    #region Inspector Variables

    [Tooltip("Min swipe distance (inches) to register as swipe")]
    [SerializeField] float minSwipeLength = 0.5f;

    [Tooltip("If true, a swipe is counted when the min swipe length is reached. If false, a swipe is counted when the touch/click ends.")]
    [SerializeField] bool triggerSwipeAtMinLength = false;

    [Tooltip("Whether to detect eight or four cardinal directions")]
    [SerializeField] bool useEightDirections = false;

    #endregion

    const float eightDirAngle = 0.906f;
    const float fourDirAngle = 0.5f;
    const float defaultDPI = 72f;
    const float dpcmFactor = 2.54f;

    static Dictionary<Swipe, Vector2> cardinalDirections = new Dictionary<Swipe, Vector2>()
    {
        { Swipe.Up,         CardinalDirection.Up                 },
        { Swipe.Down,         CardinalDirection.Down             },
        { Swipe.Right,         CardinalDirection.Right             },
        { Swipe.Left,         CardinalDirection.Left             },
        { Swipe.UpRight,     CardinalDirection.UpRight             },
        { Swipe.UpLeft,     CardinalDirection.UpLeft             },
        { Swipe.DownRight,     CardinalDirection.DownRight         },
        { Swipe.DownLeft,     CardinalDirection.DownLeft         }
    };

    public static Vector2 swipeVelocity;

    static float dpcm;
    static float swipeStartTime;
    static float swipeEndTime;
    static bool autoDetectSwipes;
    static bool swipeEnded;
    static Swipe swipeDirection;
    static Vector2 firstPressPos;
    static Vector2 secondPressPos;

    private void Awake()
    {
        float dpi = (Screen.dpi == 0) ? defaultDPI : Screen.dpi;
        dpcm = dpi / dpcmFactor;
    }

    private void SwipeInput()
    {
        if (GetTouchInput() || GetMouseInput())
        {
            // Swipe already ended, don't detect until a new swipe has begun
            if (swipeEnded)
            {
                return;
            }

            Vector2 currentSwipe = secondPressPos - firstPressPos;
            float swipeCm = currentSwipe.magnitude / dpcm;

            // Check the swipe is long enough to count as a swipe (not a touch, etc)
            if (swipeCm < minSwipeLength)
            {
                // Swipe was not long enough, abort
                if (!triggerSwipeAtMinLength)
                {
                    if (Application.isEditor)
                    {
                        //Debug.Log("[SwipeManager] Swipe was not long enough.");
                        EventManager.OnSwipeFail.Invoke();
                    }

                    swipeDirection = Swipe.None;
                }

                return;
            }

            swipeEndTime = Time.time;
            swipeVelocity = currentSwipe * (swipeEndTime - swipeStartTime);
            swipeDirection = GetSwipeDirByTouch(currentSwipe);
            swipeEnded = true;

            if (Mathf.Abs(swipeStartTime - swipeEndTime) < 1.3f)
                EventManager.OnSwipeDetected.Invoke(swipeDirection, swipeVelocity.normalized);
            else EventManager.OnSwipeFail.Invoke();

            //Debug.Log("Swipe Detected " + swipeDirection + " " + swipeVelocity + " " + currentSwipe);
        }
        else
        {
            swipeDirection = Swipe.None;
        }
    }

    public static bool IsSwiping() { return swipeDirection != Swipe.None; }
    public static bool IsSwipingRight() { return IsSwipingDirection(Swipe.Right); }
    public static bool IsSwipingLeft() { return IsSwipingDirection(Swipe.Left); }
    public static bool IsSwipingUp() { return IsSwipingDirection(Swipe.Up); }
    public static bool IsSwipingDown() { return IsSwipingDirection(Swipe.Down); }
    public static bool IsSwipingDownLeft() { return IsSwipingDirection(Swipe.DownLeft); }
    public static bool IsSwipingDownRight() { return IsSwipingDirection(Swipe.DownRight); }
    public static bool IsSwipingUpLeft() { return IsSwipingDirection(Swipe.UpLeft); }
    public static bool IsSwipingUpRight() { return IsSwipingDirection(Swipe.UpRight); }

    #region Helper Functions

    static bool GetTouchInput()
    {
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);

            // Swipe/Touch started
            if (t.phase == TouchPhase.Began)
            {
                firstPressPos = t.position;
                swipeStartTime = Time.time;
                swipeEnded = false;
                // Swipe/Touch ended
            }
            else if (t.phase == TouchPhase.Ended)
            {
                secondPressPos = t.position;
                Instance.tapDuration = Mathf.Abs(Instance.tapInputDownTime - Time.time);

                return true;
                // Still swiping/touching
            }
            else
            {
                // Could count as a swipe if length is long enough
                if (Instance.triggerSwipeAtMinLength)
                {
                    return true;
                }
            }
        }

        return false;
    }

    static bool GetMouseInput()
    {
        // Swipe/Click started
        if (Input.GetMouseButtonDown(0))
        {
            firstPressPos = (Vector2)Input.mousePosition;
            swipeStartTime = Time.time;
            swipeEnded = false;
            // Swipe/Click ended
        }
        else if (Input.GetMouseButtonUp(0))
        {
            secondPressPos = (Vector2)Input.mousePosition;
            Instance.tapDuration = Mathf.Abs(Instance.tapInputDownTime - Time.time);
            return true;
            // Still swiping/clicking
        }
        else
        {
            // Could count as a swipe if length is long enough
            if (Instance.triggerSwipeAtMinLength)
            {
                return true;
            }
        }

        return false;
    }

    static bool IsDirection(Vector2 direction, Vector2 cardinalDirection)
    {
        var angle = Instance.useEightDirections ? eightDirAngle : fourDirAngle;
        return Vector2.Dot(direction, cardinalDirection) > angle;
    }

    static Swipe GetSwipeDirByTouch(Vector2 currentSwipe)
    {
        currentSwipe.Normalize();
        var swipeDir = cardinalDirections.FirstOrDefault(dir => IsDirection(currentSwipe, dir.Value));
        return swipeDir.Key;
    }

    static bool IsSwipingDirection(Swipe swipeDir)
    {
        Instance.SwipeInput();
        return swipeDirection == swipeDir;
    }

    #endregion
    #endregion
}


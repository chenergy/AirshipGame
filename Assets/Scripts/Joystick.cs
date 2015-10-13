using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Joystick : MonoBehaviour
{
    public InputHandler input;
    public RectTransform joystickTransform;
    public float maxDistance;

    /*private Vector3 curPosition;
    public Vector3 CurPosition { get { return this.curPosition; } }*/

    private bool isDown;
    public bool IsDown { get { return this.isDown; } }

    private Vector2 startPosition;

    //private Vector3 v1;
    //private Vector3 v2;


    // Use this for initialization
    void Start () {
        this.startPosition = this.joystickTransform.position;
    }

    // Update is called once per frame
    //void Update () {
    //}


    public void OnPointerDown(BaseEventData eventData)
    {
        PointerEventData ped = (PointerEventData)eventData;

        Vector2 direction = Vector2.ClampMagnitude(ped.position - this.startPosition, this.maxDistance);

        this.joystickTransform.position = this.startPosition + direction;
        /*
        this.lastLocation = ped.position;

        StopCoroutine("RotateToZero");

        this.input.StartRotateAirship();*/
        this.input.StartRotateAirship();
    }


    public void OnPointerUp(BaseEventData eventData)
    {
        this.joystickTransform.position = this.startPosition;
        /*this.lastLocation = Vector2.zero;
        this.v1 = Vector3.zero;
        this.v2 = Vector3.zero;

        //this.rectTransform.rotation = Quaternion.identity;

        // Follow realistic rotation mode.
        if (this.steeringMode == GameEnum.SteeringType.REALISTIC)
        {
            StartCoroutine("RotateToZero");
        }
        else if (this.steeringMode == GameEnum.SteeringType.UNREALISTIC)
        {
            this.input.SetRotationAirship(0);
        }

        this.input.EndRotateAirship();*/
        this.input.EndRotateAirship();
    }


    public void OnDrag(BaseEventData eventData)
    {
        PointerEventData ped = (PointerEventData)eventData;

        Vector2 direction = Vector2.ClampMagnitude (ped.position - this.startPosition, this.maxDistance);

        this.joystickTransform.position = this.startPosition + direction;

        direction = direction.normalized;

        this.input.SetHeadingAirship(new Vector3(direction.x, 0.0f, direction.y));
        /*PointerEventData ped = (PointerEventData)eventData;
        // Vector from center to last touch position.
        this.v1 = new Vector3(this.lastLocation.x, this.lastLocation.y) - this.rectTransform.position;

        // Vector from center to cur touch position.
        this.v2 = new Vector3(ped.position.x, ped.position.y) - this.rectTransform.position;

        // Get angle between the vectors, direction based on turn direction.
        float angleBetween = Vector3.Angle(v1, v2) * Mathf.Sign(Vector3.Cross(v1, v2).z);

        // Follow realistic rotation mode.
        if (this.steeringMode == GameEnum.SteeringType.REALISTIC)
        {
            // Add angle to start angle.
            this.curAngle += angleBetween;

            // Clamp angle between the min and max angles possible.
            this.curAngle = Mathf.Clamp(this.curAngle, this.minMaxRotation.x, this.minMaxRotation.y);

            // Rotate this image.
            //this.rectTransform.Rotate (0, 0, angleBetween);
            this.rectTransform.rotation = Quaternion.Euler(0, 0, this.curAngle);

            // Rotate the airship.
            //this.input.RotateAirship (angleBetween);
            this.input.SetRotationAirship(curAngle);

            // Save this cur touch position as last.
            this.lastLocation = ped.position;
        }
        else if (this.steeringMode == GameEnum.SteeringType.UNREALISTIC)
        {
            this.rectTransform.Rotate(0, 0, angleBetween);

            //this.input.AddRotationAirship (angleBetween);
            this.input.AddRotationAirship(angleBetween);

            // Save this cur touch position as last.
            this.lastLocation = ped.position;

            this.curAngle = 0.0f;
        }*/
    }


    /*IEnumerator RotateToZero()
    {
        while (Mathf.Abs(this.curAngle) > 0.01f)
        {
            yield return new WaitForEndOfFrame();
            //this.rectTransform.rotation = Quaternion.Lerp (this.rectTransform.rotation, Quaternion.identity, 
            //this.rectTransform.rotation = Quaternion.RotateTowards (this.rectTransform.rotation, Quaternion.identity, Time.deltaTime * 100);
            this.rectTransform.rotation = Quaternion.Euler(0, 0, this.curAngle);

            this.input.SetRotationAirship(this.curAngle);

            this.curAngle = Mathf.Lerp(this.curAngle, 0.0f, Time.deltaTime * 10);
        }

        this.rectTransform.rotation = Quaternion.identity;
    }*/
}

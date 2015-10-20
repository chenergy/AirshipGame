using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Joystick : MonoBehaviour
{
    public InputHandler input;
    public RectTransform joystickTransform;
    public float maxDistance;
	public bool changeSpeed = false;

    private bool isDown;
    public bool IsDown { get { return this.isDown; } }

    private Vector2 startPosition;


    // Use this for initialization
    void Start () {
        this.startPosition = this.joystickTransform.position;
    }


    public void OnPointerDown(BaseEventData eventData)
    {
        PointerEventData ped = (PointerEventData)eventData;

        Vector2 direction = Vector2.ClampMagnitude(ped.position - this.startPosition, this.maxDistance);

        this.joystickTransform.position = this.startPosition + direction;

        this.input.StartRotateAirship();
    }


    public void OnPointerUp(BaseEventData eventData)
    {
        this.joystickTransform.position = this.startPosition;

		if (this.changeSpeed)
			this.input.SetAirshipSpeed (0.0f);

        this.input.EndRotateAirship();
    }


    public void OnDrag(BaseEventData eventData)
    {
        PointerEventData ped = (PointerEventData)eventData;

        Vector2 direction = Vector2.ClampMagnitude (ped.position - this.startPosition, this.maxDistance);

        this.joystickTransform.position = this.startPosition + direction;

		if (this.changeSpeed)
			this.input.SetAirshipSpeed (direction.magnitude / 100);

        direction = direction.normalized;

        this.input.SetHeadingAirship(new Vector3(direction.x, 0.0f, direction.y));
    }

	public void ToggleChangeSpeed (){
		this.changeSpeed = !this.changeSpeed;

		float speed = (this.changeSpeed) ? 0.0f : GameManager.instance.InGameController.airship.baseMoveSpeed;
		//GameManager.instance.InGameController.airship.UpdateSpeed (speed);
		this.input.SetAirshipSpeed (speed);
	}
}

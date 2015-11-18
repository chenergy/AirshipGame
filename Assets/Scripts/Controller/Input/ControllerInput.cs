using UnityEngine;
using System.Collections;

public class ControllerInput : MonoBehaviour
{
    public InputHandler input;

    private bool firstDown = false;

    void Update()
    {
        Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (direction.sqrMagnitude > 0.0f)
        {
            //Vector2 direction = Vector2.ClampMagnitude(ped.position - this.startPosition, this.maxDistance);
            //this.joystickTransform.position = this.startPosition + direction;
            this.firstDown = true;

            this.input.StartRotateAirship();

            this.input.SetAirshipSpeed(direction.magnitude);

            direction = direction.normalized;

            this.input.SetHeadingAirshipAdjusted(new Vector3(direction.x, 0.0f, direction.y));
        }
        else
        {
            if (this.firstDown)
            {
                this.firstDown = false;

                this.input.SetAirshipSpeed(0.0f);

                this.input.EndRotateAirship();
            }
        }


        if (Input.GetAxis("Joystick0") > 0)
        {
            this.input.ActivateAbility(0);
        }
        if (Input.GetAxis("Joystick1") > 0)
        {
            this.input.ActivateAbility(1);
        }
        if (Input.GetAxis("Joystick2") > 0)
        {
            this.input.ActivateAbility(2);
        }
        if (Input.GetAxis("Joystick3") > 0)
        {
            this.input.ActivateAbility(3);
        }
    }
}
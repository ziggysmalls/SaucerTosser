using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(ShipPhysics))]
[RequireComponent(typeof(ShipInput))]
public class Ship : MonoBehaviour
{    
    public bool isPlayer = false;

    private ShipInput input;
    private ShipPhysics physics;    

    
    public static Ship PlayerShip { get { return playerShip; } }
    private static Ship playerShip;

    // Getters for external objects to reference things like input.
    public bool UsingMouseInput { get { return input.useMouseInput; } }
    public Vector3 Velocity { get { return physics.Rigidbody.velocity; } }
    public float Throttle { get { return input.throttle; } }

    private void Awake()
    {
        input = GetComponent<ShipInput>();
        physics = GetComponent<ShipPhysics>();
    }

    private void Update()
    {
        // Pass the input to the physics to move the ship.
        physics.SetPhysicsInput(new Vector3(input.strafe, 0.0f, input.throttle), new Vector3(input.pitch, input.yaw, input.roll));

        // If this is the player ship, then set the static reference. If more than one ship
        // is set to player, then whatever happens to be the last ship to be updated will be
        // considered the player. Don't let this happen.
        if (isPlayer)
            playerShip = this;
    }
}

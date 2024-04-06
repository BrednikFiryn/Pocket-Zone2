using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class UserInputSystem : ComponentSystem
{
    private EntityQuery inputQuery;

    private InputAction moveAction;
    private InputAction shootAction;

    private float2 moveInput;
    private float shootInput;

    protected override void OnCreate()
    {
        inputQuery = GetEntityQuery(ComponentType.ReadOnly<InputData>());
    }

    protected override void OnStartRunning()
    {
        moveAction = new InputAction("move", binding: "<Gamepad>/rightStick");

        shootAction = new InputAction("shoot", binding: "<Keyboard>/Space");

        moveAction.AddCompositeBinding("Dpad")
           .With("Up", "<Keyboard>/w")
           .With("Down", "<Keyboard>/s")
           .With("Left", "<Keyboard>/a")
           .With("Right", "<Keyboard>/d");

        moveAction.performed += context => { moveInput = context.ReadValue<Vector2>(); };
        moveAction.started += context => { moveInput = context.ReadValue<Vector2>(); };
        moveAction.canceled += context => { moveInput = context.ReadValue<Vector2>(); };
        moveAction.Enable();

        shootAction.performed += context => { shootInput = context.ReadValue<float>(); };
        shootAction.started += context => { shootInput = context.ReadValue<float>(); };
        shootAction.canceled += context => { shootInput = context.ReadValue<float>(); };
        shootAction.Enable();
    }

    protected override void OnStopRunning()
    {
        moveAction.Disable();
        shootAction.Disable();
    }

    protected override void OnUpdate()
    {
        Entities.With(inputQuery).ForEach(
          (Entity entity, ref ShootData shootData, ref InputData inputData) =>
          {
              inputData.move = moveInput;
              shootData.shoot = shootInput;
          });
    }
}


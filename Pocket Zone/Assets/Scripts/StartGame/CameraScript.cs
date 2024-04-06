using Cinemachine;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private CinemachineVirtualCamera _cinemachineVirtualCamera;
    private MoveAbility _player;

    private void Start()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        _cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
        _player = FindObjectOfType<MoveAbility>();
        _cinemachineVirtualCamera.Follow = _player.transform;
    }
}

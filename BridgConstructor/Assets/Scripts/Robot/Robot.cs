using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    private PlayerInput _playerInput;
    void Awake()
    {
        _playerInput = new PlayerInput();

        //_playerInput.Player.BridgBuilding.started += context => StartHold();
       //_playerInput.Player.BridgBuilding.canceled += context => StopHold();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable(){
        _playerInput.Enable();
    }

    private void OnDisable() {
        _playerInput.Disable();
    }

    private void StartHold()
    {
        Debug.Log("isDown");
    }

    private void StopHold()
    {
        Debug.Log("isUp");
    }
}

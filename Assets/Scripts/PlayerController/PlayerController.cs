using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Manual Refrences
    [SerializeField] private PlayerSettings playerSettings;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Transform groundCheckPosition;
    //Automatic Refrences
    private Rigidbody rb;
    //Awake
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("PlayerController: Rigidbody not found!");
        }
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

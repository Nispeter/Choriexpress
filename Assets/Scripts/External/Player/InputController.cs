using UnityEngine;

public class InputController : MonoBehaviour
{
    private FirstPersonMovement playerMovement;
    private PlayerPickup playerPickup;
    //public PlayerUI gameScreenManager;

    void Start()
    {
        playerPickup = GetComponent<PlayerPickup>();
        playerMovement = GetComponent<FirstPersonMovement>();
        //gameScreenManager.isGamePaused = false;
    }

    private void Update()
    {

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        bool isSprinting = Input.GetKey(KeyCode.LeftShift);
        bool isWalking = Input.GetKey(KeyCode.LeftControl);

        playerMovement.HandleMovement(horizontalInput, verticalInput, isSprinting, isWalking);

        if (Input.GetButtonDown("Jump"))
        {
            playerMovement.HandleJump();
        }
        {
            KeyCode keyPressed = ConvertToKeyCode(Input.inputString);
        }
        if (Input.GetMouseButtonDown(0))
        {

        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            playerPickup.Pickup();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {

        }
        if (Input.GetKeyDown(KeyCode.F))
        {

        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {

        }
    }

    KeyCode ConvertToKeyCode(string input)
    {
        if (input.Length == 1)
        {
            char character = input[0];
            if (char.IsDigit(character))
            {
                return (KeyCode)System.Enum.Parse(typeof(KeyCode), "Alpha" + character);
            }
            else if (char.IsLetter(character))
            {
                return (KeyCode)System.Enum.Parse(typeof(KeyCode), character.ToString().ToUpper());
            }
        }

        return KeyCode.None;
    }

}

using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour
{
    //gameobjects
    public GameObject lightningPrefab;
    public GameObject cloud;
    public Texture texCloud;

    // public reference objects
    public GameObject player;

    // Constants
    float CAMERA_DISTANCE;
    const float PLAYER_SPEED = 80;
    const float SCALE_MODIFIER = 1.7F;
    const int DIRECTIONRIGHT = 90; //direction = right.
    const int DIRECTIONLEFT = 270;
    const int CLOUD_HEIGHT = 200;

    void Start()
    {
        CAMERA_DISTANCE = GameObject.Find("Player").transform.position.z;
    }
    

    void Update()
    {
        WorldClick();
        Raycast();
    }

    void WorldClick()
    {
        // Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began
        // Input.GetTouch(0).position

        // Input.GetMouseButtonDown(0)
        // Input.mousePosition


        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("hej");
            // finds the cursor's position and store it in worldPos.
            Vector3 screenPos = Input.mousePosition;
            screenPos.z = CAMERA_DISTANCE;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
            worldPos = new Vector3(worldPos.x, worldPos.y, player.transform.position.z);

            //Stores the position of where the lightning should strike in InstancePos.
            Vector3 instancePos = new Vector3(worldPos.x, cloud.transform.position.y, cloud.transform.position.z);

            //Stores the object created in the scene to the variable lightning.
            GameObject lightning = (GameObject)GameObject.Instantiate(lightningPrefab, instancePos, Quaternion.identity);

            //Calculates the scale of the lightning so it strikes at where you click.
            float objectHeight = lightning.renderer.bounds.size.y;
            float desiredHeight = Mathf.Abs(cloud.transform.position.y - worldPos.y);
            float yScale = desiredHeight / objectHeight;


            //Checks the direction of the player and reverse it.
            if (worldPos.x > player.transform.position.x)
            {
                Vector3 rotateRight = player.transform.eulerAngles;
                rotateRight.y = DIRECTIONLEFT; //equals right in the game
                player.transform.rotation = Quaternion.Euler(new Vector3(
                    rotateRight.x,
                    rotateRight.y,
                    rotateRight.z));
            }
            else
            {
                Vector3 rotateLeft = player.transform.eulerAngles;
                rotateLeft.y = DIRECTIONRIGHT; //equals right in the game
                player.transform.rotation = Quaternion.Euler(new Vector3(
                    rotateLeft.x,
                    rotateLeft.y,
                    rotateLeft.z));

            }


           // Calculates and apply the actual scaling of the newly created lightning
            Vector3 localScale = lightning.transform.localScale / SCALE_MODIFIER;
            localScale.z *= -yScale;
            lightning.transform.localScale = localScale;

            float yOffset = lightning.renderer.bounds.size.z;
            Vector3 position = lightning.transform.position;
            position.y -= (yOffset);
            lightning.transform.position = position;

            lightning.transform.rotation = Quaternion.Euler(new Vector3(90, 180, 0));
        }
    }

    void Raycast()
    {
        // Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began
            // Input.GetTouch(0).position

        // Input.GetMouseButtonDown(0)
            // Input.mousePosition

        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousepos = camera.ScreenToWorldPoint(Input.mousePosition);

            if (Physics.Raycast(mousepos, Vector3.forward * 10, out hit))
            {
                switch (hit.collider.gameObject.name)
                {
                    case "ElevatorTrigger":
                        hit.collider.gameObject.GetComponent<ElevatorTrigger>().elevator.use = true;
                        break;
                    case "BridgeTrigger":
                        hit.collider.gameObject.GetComponent<BridgeTrigger>().bridge.use = true;
                        Destroy(hit.collider.gameObject);
                        break;
                    case "Destructable":
                        Destroy(hit.collider.gameObject);
                        break;
                    case "Player":
                        Application.LoadLevel(Application.loadedLevel);
                        break;
                    case "FallingBlockTrigger":
                        hit.collider.gameObject.GetComponent<FallingBlockTrigger>().fallingBlock.use = true;
                        break;
                }
            }

        }
    }

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, CLOUD_HEIGHT), texCloud);
    }
}
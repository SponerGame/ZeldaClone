using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Canvas inventory;
    private bool isOpen = false;
    [SerializeField] private Item item;
    [SerializeField] private CameraController cameraController;


    public bool IsOpen()
    {
        return isOpen;
    }

    private void Awake()
    {

        inventory = GetComponent<Canvas>();
    }

    public void Open(Vector2 mousePosition)
    {
        inventory.gameObject.SetActive(true);
        Camera camera = cameraController.getCharacterCamera();
        ScreenDiveded(camera);
        isOpen = true;
        Debug.Log(mousePosition);
    }
    public void Close()
    {
        inventory.gameObject.SetActive(false);
        isOpen = false;
    }

    private void ScreenDiveded(Camera camera)
    {
        int height = camera.pixelHeight;
        int widht = camera.pixelWidth;

        Debug.Log("height" + height);
        Debug.Log("widht" + widht);
    }

}

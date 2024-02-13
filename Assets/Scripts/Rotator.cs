using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Update() is called once per frame
    void Update()
    {
        // Rotate the Coin game object
        transform.Rotate(new Vector3(45, 0, 0) * Time.deltaTime);
    }
}

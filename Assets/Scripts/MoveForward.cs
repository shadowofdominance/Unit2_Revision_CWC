using UnityEngine;

public class Launch : MonoBehaviour
{
    private float _moveSpeed = 40;

    private void Update()
    {
        transform.Translate(Vector3.forward * (_moveSpeed * Time.deltaTime));
    }
}

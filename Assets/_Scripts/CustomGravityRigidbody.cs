using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CustomGravityRigidbody : MonoBehaviour
{
    Rigidbody body;
    Renderer objRenderer;
    Material material;
    Color originalColor;
    [SerializeField] bool floatToSleep = false;
    float floatDelay;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        objRenderer = GetComponent<Renderer>();
        material = objRenderer.material;
        originalColor = material.color;
        body.useGravity = false;
    }

    private void FixedUpdate()
    {
        if (floatToSleep)
        {
            if (body.IsSleeping())
            {
                material.color = Color.blue;
                floatDelay = 0f;
                return;
            }
            if (body.velocity.sqrMagnitude < 0.0001f)
            {
                material.color = Color.yellow;
                floatDelay += Time.deltaTime;
                if (floatDelay >= 1f) return;
            }
            else
            {
                floatDelay = 0f;
            }
        }
        material.color = originalColor;
        body.AddForce(CustomGravity.GetGravity(body.position), ForceMode.Acceleration);
    }
}

using UnityEngine;

public class TimedVisibility : MonoBehaviour
{
    [SerializeField] private float delay = 2.0f;
    // Start is called before the first frame update
    private void Start()
    {
        Destroy(gameObject, delay);
    }
}

using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class FloatingSandwich : MonoBehaviour
{
    private float initialY;

    private TweenerCore<Vector3, Vector3, VectorOptions> _tweenerCore;

    private void Awake()
    {
        initialY = transform.position.y;
    }

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

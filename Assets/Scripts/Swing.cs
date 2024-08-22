using UnityEngine;

public class Swing : MonoBehaviour
{
    [SerializeField] private float _pushForce;
    [SerializeField] private Rigidbody _swing;    

    public void Push()
    {
        _swing.AddForce(Vector3.forward * _pushForce, ForceMode.Impulse);
    }
}
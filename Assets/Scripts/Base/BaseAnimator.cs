using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BaseAnimator : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    public void Run(float velocity)
    {
        _animator.SetFloat("Velocity", velocity);
    }
}

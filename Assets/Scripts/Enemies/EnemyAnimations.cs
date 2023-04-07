using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    private Animator _enemyAnimator;

    private void Awake()
    {
        _enemyAnimator = GetComponent<Animator>();
    }

    public void SetMovingAnimation(bool newState)
    {
        _enemyAnimator.SetBool("IsMoving", newState);
    }

    public void StartAttack()
    {
        _enemyAnimator.SetTrigger("StartAttack");
    }
}

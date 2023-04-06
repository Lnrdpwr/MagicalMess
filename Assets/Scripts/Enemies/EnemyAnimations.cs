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

    public void SpawnBat()
    {
        _enemyAnimator.SetTrigger("StartSpawn");
    }
}

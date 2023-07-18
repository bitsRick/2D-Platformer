using UnityEngine;
using Random = UnityEngine.Random;


namespace Code.Mob
{
    public class EnemyPatrol : MonoBehaviour
    {
        private const string AnimationStateEnemySpeed = "Speed";
        private const float MinimDistance = 0.2f;

        [SerializeField] private Animator _animator;
        [SerializeField] private Transform[] _transforms;
        [SerializeField] private SpriteRenderer _renderer;
        [SerializeField] private float _speed;
        [SerializeField] private float _startWaitTime;

        private float _waitTime;
        private int _startPosition;

        private void Start()
        {
            _startPosition = Random.Range(0,_transforms.Length);
        }

        private void Update()
        {
            PatrolByPoints();
        }

        private void PatrolByPoints()
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                _transforms[_startPosition].position,
                _speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, _transforms[_startPosition].position) < MinimDistance)
            {
                WaitForTime();
                _animator.SetFloat(AnimationStateEnemySpeed, 0);
            }
            else
            {
                FlipXSprite();
                _animator.SetFloat(AnimationStateEnemySpeed, 1);
            }
        }

        private void WaitForTime()
        {
            if (_waitTime <= 0)
            {
                _waitTime = _startWaitTime;
                _startPosition = Random.Range(0, _transforms.Length);
            }
            else
            {
                _waitTime -= Time.deltaTime;
            }
        }

        private void FlipXSprite() => 
            _renderer.flipX = transform.position.x > _transforms[_startPosition].position.x;
    }
}

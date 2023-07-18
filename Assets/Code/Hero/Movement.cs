using UnityEngine;

namespace Code.Hero
{
    public class Movement : MonoBehaviour
    {
        private const string AnimationStateRun = "Run";
        private const string AnimationStateJump = "Jump";
        private const string LayerMaskGround = "Ground";

        [SerializeField] private Animator _animator;
        [SerializeField] private SpriteRenderer _renderer;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private float _jumpForse;
    
        private float _move = 1f;
        private float _animationTime = 8f;
        private float _animationStartValue = 0.2f;
        private bool _inAir;

        private void Update()
        {
            Input();
            JumpHero();
        }

        private void Input()
        {
            if (UnityEngine.Input.GetKey(KeyCode.D))
            {
                Move(false, _move);
            }
            else if (UnityEngine.Input.GetKey(KeyCode.A))
            {
                Move(true, -_move);
            }
            else
            {
                _animator.SetFloat(AnimationStateRun, 0f);

                if (_audioSource.isPlaying)
                {
                    _audioSource.Stop();
                }
            }
        }

        private void JumpHero()
        {
            if (UnityEngine.Input.GetKey(KeyCode.Space) && !_inAir)
            {
                _inAir = true;
                _animator.Play(AnimationStateJump);
                _rigidbody2D.AddForce(Vector2.up * _jumpForse);

                if (_audioSource.isPlaying)
                {
                    _audioSource.Stop();
                }
            }
        }

        private void Move(bool flipX,float move)
        {
            _renderer.flipX = flipX;
            _animator.SetFloat(AnimationStateRun, _animationStartValue);
            transform.Translate(_animationTime * Time.deltaTime * move, 0, 0);

            if (_audioSource.isPlaying == false && _inAir == false)
            {
                _audioSource.Play();
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer(LayerMaskGround))
                _inAir = false;
        }
    }
}
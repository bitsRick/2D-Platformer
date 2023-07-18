using UnityEngine;

namespace Code.Camera
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private GameObject _hero;

        private void Update()
        {
            Follow(_hero);
        }

        private void Follow(GameObject gameObject)
        {
            _transform.position = new Vector3(gameObject.transform.position.x, _transform.position.y, _transform.position.z);
        }
    }
}

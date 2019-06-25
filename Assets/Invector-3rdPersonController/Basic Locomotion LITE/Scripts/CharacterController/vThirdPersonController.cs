using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Invector.CharacterController
{
    public class vThirdPersonController : vThirdPersonAnimator
    {
        private AudioSource sound;
        public AudioClip sonido;
        public  static float salud = 100f;
        protected virtual void Start()
        {
            sound = GetComponent<AudioSource>();
#if !UNITY_EDITOR
                Cursor.visible = false;
#endif
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                EnemyFollow.salud -= 50f;
            }
        }
        private IEnumerator waiting()
        {
            sonido = (AudioClip)Resources.Load("Audio/PlayerDied", typeof(AudioClip));
            sound.PlayOneShot(sonido, 2f);
            yield return new WaitWhile(() => sound.isPlaying);
            Scene escena = SceneManager.GetActiveScene();
            SceneManager.LoadScene(escena.name);

            // Destroy(gameObject);
        }
        private void Update()
        {
            if (salud == 0)
            {
                DestroyObject(gameObject);
            
                StartCoroutine(waiting());
            }
        }

        public virtual void Sprint(bool value)
        {                                   
            isSprinting = value;            
        }

        public virtual void Strafe()
        {
            if (locomotionType == LocomotionType.OnlyFree) return;
            isStrafing = !isStrafing;
        }

        public virtual void Jump()
        {
            // conditions to do this action
            bool jumpConditions = isGrounded && !isJumping;
            // return if jumpCondigions is false
            if (!jumpConditions) return;
            // trigger jump behaviour
            jumpCounter = jumpTimer;            
            isJumping = true;
            // trigger jump animations            
            if (_rigidbody.velocity.magnitude < 1)
                animator.CrossFadeInFixedTime("Jump", 0.1f);
            else
                animator.CrossFadeInFixedTime("JumpMove", 0.2f);
        }

        public virtual void RotateWithAnotherTransform(Transform referenceTransform)
        {
            var newRotation = new Vector3(transform.eulerAngles.x, referenceTransform.eulerAngles.y, transform.eulerAngles.z);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(newRotation), strafeRotationSpeed * Time.fixedDeltaTime);
            targetRotation = transform.rotation;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFly : MonoBehaviour
{
    private Rigidbody2D rb;
    private AudioSource audioSource;
    public GameObject player;

    [SerializeField] private float thrustForce = 5f; // Lực đẩy chính
    [SerializeField] private float rotationSpeed = 200f; // Tốc độ xoay
    //[SerializeField] private AudioClip thrustSound; // Âm thanh lực đẩy

    //[SerializeField] private ParticleSystem mainThrustParticles; // Hiệu ứng hạt chính
    //[SerializeField] private ParticleSystem leftThrustParticles; // Hiệu ứng hạt trái
    //[SerializeField] private ParticleSystem rightThrustParticles; // Hiệu ứng hạt phải

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    private void StartThrusting()
    {
        rb.AddForce(transform.up * thrustForce);

        //// Hiệu ứng hạt
        //if (!mainThrustParticles.isPlaying)
        //{
        //    mainThrustParticles.Play();
        //}

        //// Âm thanh
        //if (!audioSource.isPlaying && thrustSound != null)
        //{
        //    audioSource.PlayOneShot(thrustSound);
        //}
    }

    private void StopThrusting()
    {
        // mainThrustParticles.Stop();
        audioSource.Stop();
    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A)) // Xoay trái
        {
            transform.rotation = Quaternion.Euler(0f, -180f, 0f);
            Rotate(rotationSpeed);
            
            //PlayLeftThruster();
        }
        else if (Input.GetKey(KeyCode.D)) // Xoay phải
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            Rotate(-rotationSpeed);
            
            // PlayRightThruster();
        }
        else
        {
            //StopSideParticles();
        }
    }

    private void Rotate(float rotationAmount)
    {
        rb.rotation += rotationAmount * Time.deltaTime;
    }

    //private void PlayLeftThruster()
    //{
    //    if (!leftThrustParticles.isPlaying)
    //    {
    //        leftThrustParticles.Play();
    //    }
    //}

    //private void PlayRightThruster()
    //{
    //    if (!rightThrustParticles.isPlaying)
    //    {
    //        rightThrustParticles.Play();
    //    }
    //}

    //private void StopSideParticles()
    //{
    //    leftThrustParticles.Stop();
    //    rightThrustParticles.Stop();
    //}
}

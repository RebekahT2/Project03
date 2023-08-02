using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class KillVolumeTool : MonoBehaviour
{
    public UnityEvent OnEnterTrigger;
    private Collider _collider;

    [SerializeField] private Color _color = Color.red;
    [SerializeField] private Material _material;
    [SerializeField] private ParticleSystem _particle;
    [SerializeField] private AudioClip _audio;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _collider.isTrigger = true;
        //_material = GetComponent<Material>();
        _material.color = _color;
        _particle.Pause();

        GameObject audioObject = new GameObject("2DAudio");
        AudioSource audioSource = audioObject.AddComponent<AudioSource>();

    }

    private void OnTriggerEnter (Collider other)
    {
        OnEnterTrigger.Invoke();
        particles(_particle);
        Audio(_audio, 1);
    }

    public void particles(ParticleSystem _particle)
    {
        if(_particle != null)
        {
            Debug.Log("particles");
            _particle.Play();
        }
    }

    public static AudioSource Audio(AudioClip _clip, float _volume)
    {
        GameObject audioObject = new GameObject("2DAudio");
        AudioSource audioSource = audioObject.AddComponent<AudioSource>();
        audioSource.clip = _clip;
        audioSource.volume = _volume;

        audioSource.Play();
        Object.Destroy(audioObject, _clip.length);

        return audioSource;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    private ParticleSystem particle;
    void Start()
    {
        particle = GetComponent<ParticleSystem>();
        ButtonVariant.StartClickEvent.AddListener(ShowParticle);
    }
    private void ShowParticle()
    {
        particle.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletDeSpawn : MonoBehaviour
{
    public GameObject impactEffect;
    public float torqueReductor;
    private float torqueMininum = 0F;
    public AudioClip[] impactSounds; // Matriz de clips de audio
    private AudioSource audioSource; // Componente AudioSource

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter(Collider other)
    {

        GameObject EffectIns = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(EffectIns, 1F);
        Destroy(gameObject, 1F);

        // Comprobación para reproducir sonido solo si se impacta al jugador o a la IA
        if (other.CompareTag("PlayerTBody") || other.CompareTag("PlayerOL") || other.CompareTag("PlayerOD") ||
            other.CompareTag("AITBody") || other.CompareTag("AIOL") || other.CompareTag("AIOD"))
        {
            // Reproducir un sonido aleatorio de impacto
            if (impactSounds.Length > 0)
            {
                int randomIndex = Random.Range(0, impactSounds.Length);
                audioSource.PlayOneShot(impactSounds[randomIndex]);
            }
        }

        checkPointAndPointSystem points = FindAnyObjectByType<checkPointAndPointSystem>();

        if (other.tag == "PlayerTBody")
            {
            points.AIPoints += 100F;
            points.AIDirectHits += 1;

        }

        if (other.tag == "PlayerOL")
            {
            points.AIPoints += 50F;
            points.AIHits += 1;
        }

        if (other.tag == "PlayerOD")
        {
            points.AIPoints += 50F;
            points.AIHits += 1;

        }

        if (other.tag == "AITBody")
        {
            points.playerPoints += 100F;
            points.playerDirectHits += 1;
        }

        if (other.tag == "AIOL")
        {
            points.playerPoints += 50F;
            points.playerHits +=1;
        }

        if (other.tag == "AIOD")
        {
            points.playerPoints += 50F;
            points.playerHits += 1;
        }

        TankDriverScript DamageControl = FindAnyObjectByType<TankDriverScript>();

        AIController AIDamageControl = FindAnyObjectByType<AIController>();

        if (other.tag == "PlayerTBody")
        {
            if (DamageControl.torqueLeft <= torqueMininum)
            {

            } 
            else
            {
                DamageControl.torqueLeft -= torqueReductor;
            }

            if (DamageControl.torqueRight <= torqueMininum)
            {
            }
            else
            {
                DamageControl.torqueRight -= torqueReductor;
            }
        }

        if (other.tag == "PlayerOL")
        {
            if (DamageControl.torqueLeft <= torqueMininum)
            {
            }
            else
            {
                DamageControl.torqueLeft -= torqueReductor;

            }
        }

        if (other.tag == "PlayerOD")
        {
            if (DamageControl.torqueRight <= torqueMininum)
            {
            }
            else
            {
                DamageControl.torqueRight -= torqueReductor;

            }
        }



        if (other.tag == "AITBody")
        {
            if (AIDamageControl.torqueLeft <= torqueMininum)
            {
            }
            else
            {
                AIDamageControl.torqueLeft -= torqueReductor;

            }

            if (AIDamageControl.torqueRight <= torqueMininum)
            {
            }
            else
            {
                AIDamageControl.torqueRight -= torqueReductor;

            }
        }

        if (other.tag == "AIOL")
        {
            if (AIDamageControl.torqueLeft <= torqueMininum)
            {
            }
            else
            {
                AIDamageControl.torqueLeft -= torqueReductor;
            }
        }

        if (other.tag == "AIOD")
        {
            if (AIDamageControl.torqueRight <= torqueMininum)
            {
            }
            else
            {
                AIDamageControl.torqueRight -= torqueReductor;
            }
        }
    }

}

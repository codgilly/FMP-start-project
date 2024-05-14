using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    AudioSource AudioSource;

    public AudioClip Unsheeth;
    public AudioClip Walk;
    public AudioClip Walk2;
    public AudioClip Run;
    public AudioClip Run2;
    public AudioClip Jump;
    public AudioClip SwingL;
    public AudioClip SwingH;
    public AudioClip Scream;
    public AudioClip Death;
    public AudioClip Hit;
    public AudioClip Drink;
    public AudioClip Roll;
    public AudioClip Block;

    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    void UnEquip()
    {
        AudioSource.PlayOneShot(Unsheeth);
    }
    void Walking()
    {
        AudioSource.PlayOneShot(Walk);
    }
    void Walking2()
    {
        AudioSource.PlayOneShot(Walk2);
    }
    void Running()
    {
        AudioSource.PlayOneShot(Run);
    }
    void Running2()
    {
        AudioSource.PlayOneShot(Run2);
    }
    void Jumpped()
    {
        AudioSource.PlayOneShot(Jump);
    }
    void LightSFX()
    {
        AudioSource.PlayOneShot(SwingL);
    }
    void HeavySFX()
    {
        AudioSource.PlayOneShot(SwingH);
    }
    void PowerUp()
    {
        AudioSource.PlayOneShot(Scream);
    }
    void Dead()
    {
        AudioSource.PlayOneShot(Death);
    }
    void Damaged()
    {
        AudioSource.PlayOneShot(Hit);
    }
    void Drunk()
    {
        AudioSource.PlayOneShot(Drink);
    }
    void rolled()
    {
        AudioSource.PlayOneShot(Roll);
    }
    void Blocked()
    {
        AudioSource.PlayOneShot(Block);
    }
}

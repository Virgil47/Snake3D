using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource mainTrack;

    void Start ()
    {
        mainTrack = GetComponent<AudioSource>();
    }
}

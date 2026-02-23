using UnityEngine; // Guarda todo lo de unity
using System.Collections.Generic; // Guarda todo lo de logica para listas

public class AudioManager : MonoBehaviour, IaudioManager //I de interfaz
{
    public static AudioManager Instance { get; private set; } // para usar scripts universales

    [SerializeField] private List<SoundData> sounds; //lista de sonidos

    private Dictionary<string, SoundData> soundDictionary;

    private void Awake() 
    { // un paso antes del start
        //todo objeto de auydio siempre que se inice el juego, elementos iguales sean destruidos para que solo haya uno
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnload(gameObject);

        soundDictionary = new Dictionary<string, SoundData>();

        foreach(var sound in sounds)
        {
            soundDictionary.Add(sound.id, sound);
        }
    }

    public void Play2D(string soundID)
    {
        if (!soundDictionary.TryGetValue(soundID, out var sound))
        {
            return;
        }
            
        Play(sound, Vector3.zero, false);
    }

    public void Play3D(string soundID, Vector3 position)
    {
        if (!soundDictionary.TryGetValue(soundID, out var sound))
            return;

        Play(sound, position, true);
    }

    private void Play(SoundData sound, Vector3 position, bool is3D) //reproducir audios
    {
        GameObject go = new GameObject("Audio_" + sound.id);
        go.transform.position = position;

        AudioSource sour = go.AddComponent<AudioSource>();
        source.clip = sound.clip;
        source.volume = sound.volume;
        source.loop = sound.loop;
        source.spatialBlend = is3D ? 1f : 0f;

        source.Play();

        if (!sound.loop)
        {
            Destroy(go, sound.clip.length);
        } 
    }
}

public interface IaudioManager // Es el identificador del audio (El id)
{
    void Play2D(string id); //Sonido persibido en los audifinos
    void Play3D(string id, Vector3 location); //Sonido del ambiente
}
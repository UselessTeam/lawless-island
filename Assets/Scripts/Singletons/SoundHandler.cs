using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : Singleton<SoundHandler>
{
    public Dictionary<string, AudioClip> musics = new Dictionary<string, AudioClip>();
    public Dictionary<string, AudioClip> sounds = new Dictionary<string, AudioClip>();

    public AudioClip[] musicClips;
    public AudioClip[] soundClips;

    public int parrallelAudioSources = 5;
    private int currentAudioSource = 0;

    private AudioSource[] audioSources;
    private AudioSource musicAudioSource;

    public void Start() {
        foreach(AudioClip music in musicClips) {
            musics[music.name] = music;
        }

        foreach (AudioClip sound in soundClips) {
            sounds[sound.name] = sound;
        }

        musicAudioSource = newSource();
        audioSources = new AudioSource[parrallelAudioSources];
        for(int i = 0; i<parrallelAudioSources; i++) {
            AudioSource source = newSource();
            audioSources[i] = source;
        }
    }

    private AudioSource newSource() {
        AudioSource source = gameObject.AddComponent<AudioSource>();
        source.bypassEffects = true;
        source.bypassListenerEffects = true;
        source.bypassReverbZones = true;
        return source;
    }

    public AudioClip FindSound(string name) {
        name = name.Clean();
        try {
            return sounds[name];
        } catch {
            Debug.LogWarning("The audio sound clip named '" + name + "' was not found");
        }
        return null;
    }

    public void PlaySound(string name, float pitchVariation = 0f, float volume = 1f) {
        if(name == "") {
            return;
        }
        AudioClip sound = FindSound(name);
        if(sound == null) {
            return;
        }
        audioSources[currentAudioSource].clip = sound;
        audioSources[currentAudioSource].volume = volume;
        float pitch = pitchVariation == 0f ? 1f : 1f + Random.Range(1f - pitchVariation, 1f / (1f - pitchVariation));
        audioSources[currentAudioSource].pitch = pitch;
        audioSources[currentAudioSource].Play();
        currentAudioSource = (currentAudioSource + 1) % parrallelAudioSources;
    }

    public AudioClip FindMusic(string name) {
        name = name.Clean();
        try {
            return musics[name];
        }
        catch {
            Debug.LogWarning("The audio music named '" + name + "' was not found");
        }
        return null;
    }

    public const float MUSIC_REDUCTION = 0.6f;

    public void PlayMusic(string name, float volume = 1f) {
        if(name == "") {
            return;
        }
        AudioClip sound = FindMusic(name);
        if (sound == null) {
            return;
        }
        musicAudioSource.clip = sound;
        musicAudioSource.volume = MUSIC_REDUCTION*volume;
        musicAudioSource.loop = true;
        musicAudioSource.Play();
    }
}

public static class StringCleanerExtension {
    private static readonly string BUGGY_CHARACTER = ((char)(19)).ToString();

    public static string Clean(this string s){
        if(s.Contains(BUGGY_CHARACTER)) {
            return s.Replace(BUGGY_CHARACTER, string.Empty);
        }
        return s;
    }
}
/*
*	
*	Title:JeroChan的框架
*		[副标题]
*
*	Description:
*		[描述]
*
*	Data:2018
*
*	Version:0.1
*
*	Modify Recoder:JeroChan
*
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


namespace JRFrameWork
{
    public class AudioManager : Singleton<AudioManager>
    {
        private AudioListener mAudioListener;

        void CheckAudioListener()
        {
            mAudioListener = FindObjectOfType<AudioListener>();
            if (!mAudioListener)
            {
                mAudioListener = gameObject.AddComponent<AudioListener>();
            }
        }

        public void PlaySound(string soundName)
        {
            CheckAudioListener();

            var coinClip = Resources.Load<AudioClip>(soundName);
            var audioSource = gameObject.AddComponent<AudioSource>();

            audioSource.clip = coinClip;
            audioSource.Play();
        }

        private AudioSource mMusicSource;

        public void PlayMusic(string musicName, bool loop)
        {
            CheckAudioListener();

            if (!mMusicSource)
            {
                mMusicSource = gameObject.AddComponent<AudioSource>();
            }

            var coinClip = Resources.Load<AudioClip>(musicName);

            mMusicSource.clip = coinClip;
            mMusicSource.loop = loop;
            mMusicSource.Play();
        }

        public void StopMusic()
        {
            mMusicSource.Stop();
        }

        public void PauseMusic()
        {
            mMusicSource.Pause();
        }

        public void ResumeMusic()
        {
            mMusicSource.UnPause();
        }

        public void MusicOff()
        {
            mMusicSource.Pause();
            mMusicSource.mute = true;
        }

        public void SoundOff()
        {
            var soundSources = this.GetComponents<AudioSource>();

            foreach (var soundSource in soundSources)
            {
                if (soundSource != mMusicSource)
                {
                    soundSource.Pause();
                    soundSource.mute = true;
                }
            }
        }

        public void MusicOn()
        {
            mMusicSource.UnPause();
            mMusicSource.mute = false;
        }

        public void SoundOn()
        {
            var soundSources = this.GetComponents<AudioSource>();

            foreach (var soundSource in soundSources)
            {
                if (soundSource != mMusicSource)
                {
                    soundSource.UnPause();
                    soundSource.mute = false;
                }
            }
        }
    }
}
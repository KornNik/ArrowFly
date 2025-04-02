using Data;
using Helpers;
using System.Collections.Generic;
using UnityEngine;

namespace Behaviours
{
    sealed class AudioSourcePool
    {
        private readonly AudioSource _prefab;

        private readonly Queue<AudioSource> _audioSources = new Queue<AudioSource>();
        private readonly LinkedList<AudioSource> _inuse = new LinkedList<AudioSource>();
        private readonly Queue<LinkedListNode<AudioSource>> _nodePool = new Queue<LinkedListNode<AudioSource>>();

        private int _lastCheckFrame = -1;

        public AudioSourcePool()
        {
            _prefab = Services.Instance.DatasBundle.ServicesObject.
                GetData<DataResourcePrefabs>().GetAudioPrefab
                (AudioTypes.PoolableSourcePrefab).GetComponent<AudioSource>();
        }
        public AudioSourcePool(AudioSource prefab)
        {
            _prefab = prefab;
        }

        private void CheckInUse()
        {
            var node = _inuse.First;
            while (node != null)
            {
                var current = node;
                node = node.Next;

                if (!current.Value.isPlaying)
                {
                    _audioSources.Enqueue(current.Value);
                    _inuse.Remove(current);
                    _nodePool.Enqueue(current);
                }
            }
        }

        private AudioSource CreateAndCheckSource()
        {
            AudioSource source;

            if (_lastCheckFrame != Time.frameCount)
            {
                _lastCheckFrame = Time.frameCount;
                CheckInUse();
            }

            if (_audioSources.Count == 0)
                source = GameObject.Instantiate(_prefab);
            else
                source = _audioSources.Dequeue();

            if (_nodePool.Count == 0)
                _inuse.AddLast(source);
            else
            {
                var node = _nodePool.Dequeue();
                node.Value = source;
                _inuse.AddLast(node);
            }
            source.volume = 1f;
            return source;
        }
        public void PlayAtPoint(AudioClip clip, Vector3 point)
        {
            var source = CreateAndCheckSource();

            source.transform.position = point;
            source.clip = clip;
            source.Play();
        }
        public void PlayAtPoint(AudioClip clip, Vector3 point, float volume)
        {

            var source = CreateAndCheckSource();

            source.volume = volume;
            source.transform.position = point;
            source.clip = clip;
            source.Play();
        }
        public void PlayAtPointOneShot(AudioClip clip, Vector3 point, float volume)
        {

            var source = CreateAndCheckSource();

            source.transform.position = point;
            source.PlayOneShot(clip, volume);
        }
        public void PlatAtPointSheduled(AudioClip clip, Vector3 point, float volume, float time)
        {
            var source = CreateAndCheckSource();

            source.transform.position = point;
            source.clip = clip;
            source.PlayScheduled(time);
        }
    }
}
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Views
{
	public interface ILinkable
	{
		int Hash { get; }
		Transform Transform { get; }
		int UnityInstanceId { get; }
		void Link(EcsEntity entity);
	}
	
	public abstract class LinkableView : MonoBehaviour, ILinkable
	{
		protected EcsEntity Entity;
		public int Hash => transform.GetHashCode();
		public Transform Transform => transform;
		public int UnityInstanceId => gameObject.GetInstanceID();

		public virtual void Link(EcsEntity entity)
		{
			Entity = entity;
		}

		protected virtual void DestroyObject()
		{
#if UNITY_EDITOR
			if (UnityEditor.EditorApplication.isPlaying)
				Destroy(gameObject);
			else
				DestroyImmediate(gameObject);
#else
			Destroy(gameObject);
#endif
		}
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace AmmoStackClone.BulletCollisions
{
	public class BulletCollisionHandler : MonoBehaviour
	{
		public Material[] bulletMaterials;
		public void Initialize()
		{

		}


		private void OnTriggerEnter(Collider other)
		{
			if (!other.CompareTag("Untagged"))
			{
				int materialIndex = GetMaterialIndexByTag(other.tag);
				if (materialIndex != -1)
				{
					ChangeMaterial(bulletMaterials[materialIndex], gameObject);
				}
			}
		}

		private void ChangeMaterial(Material newMaterial, GameObject obj)
		{
			Renderer renderer = obj.GetComponent<Renderer>();
			if (renderer != null)
			{
				renderer.material = newMaterial;
			}
		}

		private int GetMaterialIndexByTag(string tag)
		{

			switch (tag)
			{
				case "Red":
					return 0;
				case "Blue":
					return 1;
				case "Yellow":
					return 2;
				case "Green":
					return 3;
				default:
					return -1;
			}
		}
	}
}


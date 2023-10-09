using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
				Debug.Log("1");
				int materialIndex = GetMaterialIndexByTag(other.tag);
				if (materialIndex != -1)
				{
					Debug.Log("2");
					ChangeMaterial(bulletMaterials[materialIndex], gameObject);
				}
			}
			
		}

		private void ChangeMaterial(Material newMaterial, GameObject obj)
		{
			Renderer renderer = obj.GetComponent<Renderer>();
			if (renderer != null)
			{
				Debug.Log("3");
				renderer.material = newMaterial;
			}
		}

		private int GetMaterialIndexByTag(string tag)
		{

			switch (tag)
			{
				case "Red":
					Debug.Log("Red");
					return 0;
				case "Blue":
					Debug.Log("Blue");
					return 1;
				case "Yellow":
					Debug.Log("Yellow");
					return 2;
				case "Green":
					Debug.Log("Green");
					return 3;
				default:
					return -1;
			}
		}
	}
}


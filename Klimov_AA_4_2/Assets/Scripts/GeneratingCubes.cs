using UnityEngine;

namespace Arkanoid
{
	internal class GeneratingCubes : MonoBehaviour
	{
		[SerializeField] private GameObject _prefab;
		[SerializeField] private int _numCubes;
		[SerializeField] private Material[] colorMaterials;
		[SerializeField] private Transform _parent;


		private void Start()
		{
			Generate();
		}

		internal void Generate()
		{
			System.Random random = new();

			for (int i = 0; i <= _numCubes; i ++)
			{
				var cube = Instantiate(_prefab,  new Vector3(random.Next(-12, 13), random.Next(-50, 50), random.Next(19, 44)), Quaternion.Euler((float)random.Next(0, 360), (float)random.Next(0, 360), (float)random.Next(0, 360)), _parent);
				cube.GetComponent<Renderer>().material = colorMaterials[random.Next(0, colorMaterials.Length)];
			}
			Debug.Log($"{_numCubes} cubes have been generated");
			Loger.WriteLog($"{_numCubes} cubes have been generated");
		}
	}
}

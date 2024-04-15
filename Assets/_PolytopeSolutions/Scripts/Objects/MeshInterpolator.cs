#define DEBUG
//#undef DEBUG
//#define DEBUG2
#undef DEBUG2

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

namespace PolytopeSolutions.Toolset.GlobalTools.Geometry {
    [ExecuteAlways]
	[RequireComponent(typeof(MeshFilter))]
	[RequireComponent(typeof(MeshRenderer))]
	public class MeshInterpolator : MonoBehaviour {
		[SerializeField] private Mesh startingMesh;
		[SerializeField] private Mesh endMesh;
		[HideInInspector][SerializeField] private Mesh currentMesh;
		[Range(0f, 1f)]
		[SerializeField] private float time;
		[SerializeField] private Slider slider;

        [HideInInspector][SerializeField] private MeshFilter mFilter;
        [HideInInspector][SerializeField] private MeshRenderer mRenderer;

        [HideInInspector][SerializeField] private Vector3[] points;
        [HideInInspector][SerializeField] private List<Vector3> startPoints;
        [HideInInspector][SerializeField] private List<Vector3> endPoints;

		private bool IsValid {
			get { 
				return this.startingMesh != null && this.endMesh != null;
			}
		}


        private void Start(){
			if (this.slider != null) { 
				this.slider.onValueChanged.AddListener((value) => {
                    this.time = value;
                });
			}
			if (this.IsValid) {
				this.mFilter = GetComponent<MeshFilter>();
				this.mRenderer = GetComponent<MeshRenderer>();
				PrepareMesh();
			}
		}
		#if UNITY_EDITOR
		private void OnValidate() {
			if (this.IsValid && !Application.isPlaying) {
				this.mFilter = GetComponent<MeshFilter>();
				this.mRenderer = GetComponent<MeshRenderer>();
                if (this.currentMesh == null)
                    PrepareMesh();
			}
		}
		#endif

		private void PrepareMesh(){
			this.currentMesh = new Mesh();
			this.points = new Vector3[this.startingMesh.vertexCount];
			this.currentMesh.SetVertices(this.points);
			Vector2[] uvs = new Vector2[this.startingMesh.uv.Length];
			for (int i = 0; i < uvs.Length; i++)
				uvs[i] = this.startingMesh.uv[i];
			this.currentMesh.SetUVs(0, uvs);
			int[] triangles = new int[this.startingMesh.triangles.Length];
			for (int i = 0; i < triangles.Length; i++)
				triangles[i] = this.startingMesh.triangles[i];
			this.currentMesh.SetTriangles(triangles, 0);
            
			this.mFilter.mesh = this.currentMesh;
			this.startPoints = new List<Vector3>();
			this.startingMesh.GetVertices(this.startPoints);
			this.endPoints = new List<Vector3>();
			this.endMesh.GetVertices(this.endPoints);
		}
        
		private void UpdateMesh(){
			for(int i = 0; i < this.points.Length; i++) {
				this.points[i] = Vector3.Lerp(this.startPoints[i], this.endPoints[i], this.time);
			}
			this.currentMesh.SetVertices(this.points);
			this.currentMesh.RecalculateNormals();
			this.currentMesh.RecalculateBounds();
			this.currentMesh.UploadMeshData(false);
		}

        private void Update(){
			if (this.IsValid) { 
				UpdateMesh();
			}
		}
	}
}
using System;
using Microsoft.MixedReality.Toolkit.UI.BoundsControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneUIHandler : MonoBehaviour
{
    public GameObject abstractDataViz;
    [Serializable]
    public struct MeshScalePair {
        public Mesh mesh;
        public Vector3 scaleVector;
    }
    public List<MeshScalePair> meshScaleList = new List<MeshScalePair>();

    public void ToggleObject() {
        abstractDataViz.SetActive(!abstractDataViz.activeSelf);
    }

    public void SwitchMesh(int meshScalePairIndex) {
        Mesh newMesh =meshScaleList[meshScalePairIndex].mesh;
        abstractDataViz.transform.GetComponent<MeshFilter>().mesh = newMesh;
        abstractDataViz.transform.localScale = meshScaleList[meshScalePairIndex].scaleVector;

        BoxCollider dataVizBoxCollider = abstractDataViz.GetComponent<BoxCollider>();
        dataVizBoxCollider.size = newMesh.bounds.size;
        dataVizBoxCollider.center = newMesh.bounds.center;
        abstractDataViz.GetComponent<BoundsControl>().UpdateBounds();
    }
}

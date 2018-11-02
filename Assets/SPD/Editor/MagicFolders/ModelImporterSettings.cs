using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SPD.MagicFolders
{
    [CreateAssetMenu(fileName = "ModelImporterSettings")]
    public class ModelImporterSettings : ScriptableObject
    {
        [Header("Edit in Folder Menu")]
        public float fileScale = 1f;
        public bool useFileScale = true;
        public ModelImporterMeshCompression meshCompressionType = ModelImporterMeshCompression.Off;
        public bool readWriteEnabled = true;
        public bool optimizeMesh = true;
        public bool importBlendshapes = true;
        public bool generateColliders = false;
        //TODO find where this goes     public bool keepQuads = false; 
        public bool swapUvs = false;
        public bool lightmapUvs = false;

        public ModelImporterNormals importerNormals = ModelImporterNormals.Import;
        public int smoothingAngle = 60;
        public ModelImporterTangents importerTangents = ModelImporterTangents.Import;

        public bool importMaterials = true;
        public ModelImporterMaterialName materialNameMode = ModelImporterMaterialName.BasedOnMaterialName;
        public ModelImporterMaterialSearch materialSearch = ModelImporterMaterialSearch.RecursiveUp;

        public ModelImporterAnimationType animationType = ModelImporterAnimationType.Generic;
        public bool optimzeGameObjects = true;

        public bool importAnimation = true;

    }
}

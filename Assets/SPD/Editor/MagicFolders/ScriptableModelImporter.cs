using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;

namespace SPD.MagicFolders
{
    public class CustomModelImporter : AssetPostprocessor
    {
        void OnPreprocessModel()
        {
            string filePath = System.IO.Path.GetDirectoryName(assetPath.ToLower());

            ModelImporterSettings settings = AssetDatabase.LoadAssetAtPath(filePath + "/ModelImporterSettings.asset", typeof(ModelImporterSettings)) as ModelImporterSettings;
            if (settings == null) return;
            ModelImporter modelImporter = (ModelImporter)assetImporter;

            modelImporter.globalScale = settings.fileScale;
            modelImporter.useFileUnits = settings.useFileScale;
            modelImporter.meshCompression = settings.meshCompressionType;
            modelImporter.isReadable = settings.readWriteEnabled;
            modelImporter.optimizeMesh = settings.optimizeMesh;
            modelImporter.importBlendShapes = settings.importBlendshapes;
            modelImporter.addCollider = settings.generateColliders;
            modelImporter.swapUVChannels = settings.swapUvs;
            modelImporter.generateSecondaryUV = settings.lightmapUvs;
            modelImporter.importNormals = settings.importerNormals;
            modelImporter.normalSmoothingAngle = settings.smoothingAngle;
            modelImporter.importTangents = settings.importerTangents;
            modelImporter.importMaterials = settings.importMaterials;
            modelImporter.materialName = settings.materialNameMode;
            modelImporter.materialSearch = settings.materialSearch;
            modelImporter.animationType = settings.animationType;
            modelImporter.optimizeGameObjects = settings.optimzeGameObjects;
            modelImporter.importAnimation = settings.importAnimation;
        }
    }
}
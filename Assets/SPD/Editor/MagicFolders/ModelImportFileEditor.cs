using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.IO;

namespace SPD.MagicFolders
{
    [CustomEditor(typeof(UnityEngine.Object), true)]
    public class ModelImportFileEditor : Editor
    {
        bool isValid = false;
        bool settingsExist = false;
        bool settingsLoaded = false;
        string assetPath = ""; 

        public void OnEnable()
        {
            UnityEngine.Object[] objs = Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.Assets);
            foreach(UnityEngine.Object obj in objs)
            {
                string[] guids = Selection.assetGUIDs;
                assetPath = AssetDatabase.GUIDToAssetPath(guids[0]);

                if (Path.GetExtension(assetPath).Length == 0)
                {
                    DirectoryInfo info = new DirectoryInfo(assetPath);
                    FileInfo[] files = info.GetFiles();
                    foreach (FileInfo file in files)
                    {
                        if (file.Name == "ModelImporterSettings.asset")
                        {
                            settingsExist = true;
                        }
                        if (file.Extension == ".fbx" | file.Extension == ".obj")
                        {
                            isValid = true;
                        }
                    }
                }
            }
        }

        private void LoadSettings()
        {
            ModelImporterSettings settings = (ModelImporterSettings)AssetDatabase.LoadAssetAtPath(assetPath + "/ModelImporterSettings.asset",  typeof(ModelImporterSettings));

            globalScale = settings.fileScale;
            useFileScale = settings.useFileScale;
            meshCompressionType = settings.meshCompressionType;
            readWriteEnabled = settings.readWriteEnabled;
            optimizeMesh = settings.optimizeMesh;
            importBlendshapes = settings.importBlendshapes;
            generateColliders = settings.generateColliders;
            swapUVs = settings.swapUvs;
            lightmapUVs = settings.lightmapUvs;
            importerNormals = settings.importerNormals;
            smoothingAngle = settings.smoothingAngle;
            importerTangents = settings.importerTangents;
            importMaterials = settings.importMaterials;
            materialNameMode = settings.materialNameMode;
            materialSearch = settings.materialSearch;
            animationType = settings.animationType;
            optimzeGameObjects = settings.optimzeGameObjects;
            importAnimation = settings.importAnimation;
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            if (!isValid) return;
            GUI.enabled = true;

            DisplayGUI();

            string createButtonText = "Create Settings";
            if (settingsExist)
            {
                if(!settingsLoaded) LoadSettings();
                createButtonText = "Update Settings";
                settingsLoaded = true;
            }

            if (GUILayout.Button(createButtonText))
            {
                ModelImporterSettings asset = ScriptableObject.CreateInstance<ModelImporterSettings>();
                GenerateScriptableObject(asset);
                asset.hideFlags = HideFlags.NotEditable;
                AssetDatabase.CreateAsset(asset, assetPath + "/ModelImporterSettings.asset");
            }
            if (settingsExist)
            {
                if (GUILayout.Button("Delete Settings"))
                {
                    AssetDatabase.DeleteAsset(assetPath + "/ModelImporterSettings.asset");
                    settingsExist = false;
                }
            }
            if (GUILayout.Button("Reload All"))
            {
                DirectoryInfo info = new DirectoryInfo(assetPath);
                FileInfo[] files = info.GetFiles();
                foreach (FileInfo file in files)
                {
                    if (file.Extension != ".meta")
                        AssetDatabase.ImportAsset(assetPath + "/" + file.Name, ImportAssetOptions.ForceUpdate | ImportAssetOptions.ImportRecursive);
                }
            }
        }

        void GenerateScriptableObject(ModelImporterSettings asset)
        {
            asset.fileScale = globalScale;
            asset.useFileScale = useFileScale;
            asset.meshCompressionType = meshCompressionType;
            asset.readWriteEnabled = readWriteEnabled;
            asset.optimizeMesh = optimizeMesh;
            asset.importBlendshapes = importBlendshapes;
            asset.generateColliders = generateColliders;
            asset.swapUvs = swapUVs;
            asset.lightmapUvs = lightmapUVs;
            asset.importerNormals = importerNormals;
            asset.smoothingAngle = smoothingAngle;
            asset.importerTangents = importerTangents;
            asset.importMaterials = importMaterials;
            asset.materialNameMode = materialNameMode;
            asset.materialSearch = materialSearch;
            asset.animationType = animationType;
            asset.optimzeGameObjects = optimzeGameObjects;
            asset.importAnimation = importAnimation;
        }

        public float globalScale = 1f;
        public bool useFileScale = true;
        public ModelImporterMeshCompression meshCompressionType = ModelImporterMeshCompression.Off;
        public bool readWriteEnabled = false;
        public bool optimizeMesh = true;
        public bool importBlendshapes = false;
        public bool generateColliders = false;
        public bool keepQuads = false; //TODO find where this goes
        public bool swapUVs = false;
        public bool lightmapUVs = true;
        public ModelImporterNormals importerNormals = ModelImporterNormals.Import;
        public int smoothingAngle = 60;
        public ModelImporterTangents importerTangents = ModelImporterTangents.Import;
        public bool importMaterials = false;
        public ModelImporterMaterialName materialNameMode = ModelImporterMaterialName.BasedOnMaterialName;
        public ModelImporterMaterialSearch materialSearch = ModelImporterMaterialSearch.RecursiveUp;
        public ModelImporterAnimationType animationType = ModelImporterAnimationType.Generic;
        public bool optimzeGameObjects = true;
        public bool importAnimation = false;

        public void DisplayGUI()
        {
            GUILayout.Label("Model Import Settings", EditorStyles.boldLabel);
            DisplayBaseSettings();
            DisplayNormalSettings();
            DisplayMaterialSettings();
            DisplayRigSettings();
            DisplayAnimationSettings();
        }

        private void DisplayNormalSettings()
        {
            importerNormals = (ModelImporterNormals)EditorGUILayout.EnumPopup("Normals", importerNormals);
            smoothingAngle = EditorGUILayout.IntSlider("Smoothing Angle", smoothingAngle, 0, 180);
            importerTangents = (ModelImporterTangents)EditorGUILayout.EnumPopup("Tangents", importerTangents);
        }

        private void DisplayMaterialSettings()
        {
            GUILayout.Label("Material Settings", EditorStyles.miniBoldLabel);
            importMaterials = EditorGUILayout.Toggle("Import Materials", importMaterials);
            materialNameMode = (ModelImporterMaterialName)EditorGUILayout.EnumPopup("Material Naming", materialNameMode);
            materialSearch = (ModelImporterMaterialSearch)EditorGUILayout.EnumPopup("Material Search", materialSearch);
        }

        private void DisplayRigSettings()
        {
            GUILayout.Label("Rig Settings", EditorStyles.miniBoldLabel);
            animationType = (ModelImporterAnimationType)EditorGUILayout.EnumPopup("Animation Type", animationType);
            optimzeGameObjects = EditorGUILayout.Toggle("Optimize Game Objects", optimzeGameObjects);
        }

        private void DisplayAnimationSettings()
        {
            GUILayout.Label("Animation Settings", EditorStyles.miniBoldLabel);
            importAnimation = EditorGUILayout.Toggle("Import Animation", importAnimation);
        }

        private void DisplayBaseSettings()
        {
            GUILayout.Label("Base Settings", EditorStyles.miniBoldLabel);
            globalScale = EditorGUILayout.FloatField("Scale Factor", globalScale);
            useFileScale = EditorGUILayout.Toggle("Use File Scale", useFileScale);
            meshCompressionType = (ModelImporterMeshCompression)EditorGUILayout.EnumPopup("Mesh Compression", meshCompressionType);
            readWriteEnabled = EditorGUILayout.Toggle("Read/Write Enabled", readWriteEnabled);
            optimizeMesh = EditorGUILayout.Toggle("Optimze Mesh", optimizeMesh);
            importBlendshapes = EditorGUILayout.Toggle("Import BlendShapes", importBlendshapes);
            generateColliders = EditorGUILayout.Toggle("Generate Colliders", generateColliders);
            //TODO find where this goes
            //keepQuads = EditorGUILayout.Toggle("Keep Quads", keepQuads);
            swapUVs = EditorGUILayout.Toggle("Swap UVs", swapUVs);
            lightmapUVs = EditorGUILayout.Toggle("Generate Lightmap UVs", lightmapUVs);
        }
    }
}
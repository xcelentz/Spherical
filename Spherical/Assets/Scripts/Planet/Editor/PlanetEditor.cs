using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(Planet))]
    public class PlanetEditor : UnityEditor.Editor
    {
        private Planet planet;
        private UnityEditor.Editor shapeEditor;
        private UnityEditor.Editor colourEditor;
        
        public override void OnInspectorGUI()
        {
            using var check = new EditorGUI.ChangeCheckScope();
            base.OnInspectorGUI();
            if (check.changed)
            {
                planet.GeneratePlanet();
            }

            if (GUILayout.Button("Generate Planet"))
            {
                planet.GeneratePlanet();
            }
            
            DrawSettingsEditor(planet.shapeSettings, planet.OnShapeSettingsUpdated, ref planet.shapeSettingsFoldout, ref shapeEditor);
            DrawSettingsEditor(planet.colourSettings, planet.OnColourSettingsUpdated, ref planet.colourSettingsFoldout, ref colourEditor);
        }

        void DrawSettingsEditor(Object settings, System.Action onSettingUpdated, ref bool foldout, ref UnityEditor.Editor editor)
        {
            if (settings != null)
            {
                foldout = EditorGUILayout.InspectorTitlebar(foldout, settings);
            }
            using var check = new EditorGUI.ChangeCheckScope();
            
            if (!foldout) return;
            CreateCachedEditor(settings, null, ref editor);
            editor.OnInspectorGUI();
            
            if (!check.changed) return;
            onSettingUpdated?.Invoke();
        }

        private void OnEnable()
        {
            planet = (Planet) target;
        }
    }
}

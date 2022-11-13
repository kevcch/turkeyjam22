using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(PathFollower))]
public class PathFollowerEditor : Editor
{
    private PathFollower targetComponent;

    private void OnSceneGUI() {
        targetComponent = (PathFollower) target;

        Handles.color = Color.cyan;

        var positions = targetComponent.path;

        for(int i=0; i<positions.Length-1; ++i) {
            var currPoint = positions[i];
            var nextPoint = positions[i+1];

            Handles.DrawDottedLine(currPoint, nextPoint, 4f);
        }

        for(int i=0; i<positions.Length; ++i) {
            positions[i] = Handles.PositionHandle(positions[i], Quaternion.identity);

        }

        if(GUI.changed) {
            EditorUtility.SetDirty(targetComponent);
            EditorSceneManager.MarkSceneDirty(targetComponent.gameObject.scene);
        }
    }
}

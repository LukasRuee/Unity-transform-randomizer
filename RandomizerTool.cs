using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(Transform))]
public class RandomizerTool : Editor
{
    bool enableRandomization = false;

    bool randomizePosition = false;
    bool randomizeRotation = false;
    bool randomizeScale = false;

    bool randomizePosX = true, randomizePosY = true, randomizePosZ = true;
    bool randomizeRotX = true, randomizeRotY = true, randomizeRotZ = true;
    bool randomizeScaleX = true, randomizeScaleY = true, randomizeScaleZ = true;

    float minPosX = -10f, maxPosX = 10f;
    float minPosY = -10f, maxPosY = 10f;
    float minPosZ = -10f, maxPosZ = 10f;

    float minRotX = -180f, maxRotX = 180f;
    float minRotY = -180f, maxRotY = 180f;
    float minRotZ = -180f, maxRotZ = 180f;

    float minScaleX = 0.5f, maxScaleX = 2f;
    float minScaleY = 0.5f, maxScaleY = 2f;
    float minScaleZ = 0.5f, maxScaleZ = 2f;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        enableRandomization = EditorGUILayout.Toggle("Enable Randomization", enableRandomization);
        if (!enableRandomization) return;

        randomizePosition = EditorGUILayout.Toggle("Randomize Position", randomizePosition);
        if (randomizePosition)
        {
            randomizePosX = EditorGUILayout.Toggle("Randomize X", randomizePosX);
            if (randomizePosX)
            {
                minPosX = EditorGUILayout.FloatField("Min X", minPosX);
                maxPosX = EditorGUILayout.FloatField("Max X", maxPosX);
            }
            randomizePosY = EditorGUILayout.Toggle("Randomize Y", randomizePosY);
            if (randomizePosY)
            {
                minPosY = EditorGUILayout.FloatField("Min Y", minPosY);
                maxPosY = EditorGUILayout.FloatField("Max Y", maxPosY);
            }
            randomizePosZ = EditorGUILayout.Toggle("Randomize Z", randomizePosZ);
            if (randomizePosZ)
            {
                minPosZ = EditorGUILayout.FloatField("Min Z", minPosZ);
                maxPosZ = EditorGUILayout.FloatField("Max Z", maxPosZ);
            }
        }

        randomizeRotation = EditorGUILayout.Toggle("Randomize Rotation", randomizeRotation);
        if (randomizeRotation)
        {
            randomizeRotX = EditorGUILayout.Toggle("Randomize X", randomizeRotX);
            if (randomizeRotX)
            {
                minRotX = EditorGUILayout.FloatField("Min X", minRotX);
                maxRotX = EditorGUILayout.FloatField("Max X", maxRotX);
            }
            randomizeRotY = EditorGUILayout.Toggle("Randomize Y", randomizeRotY);
            if (randomizeRotY)
            {
                minRotY = EditorGUILayout.FloatField("Min Y", minRotY);
                maxRotY = EditorGUILayout.FloatField("Max Y", maxRotY);
            }
            randomizeRotZ = EditorGUILayout.Toggle("Randomize Z", randomizeRotZ);
            if (randomizeRotZ)
            {
                minRotZ = EditorGUILayout.FloatField("Min Z", minRotZ);
                maxRotZ = EditorGUILayout.FloatField("Max Z", maxRotZ);
            }
        }

        randomizeScale = EditorGUILayout.Toggle("Randomize Scale", randomizeScale);
        if (randomizeScale)
        {
            randomizeScaleX = EditorGUILayout.Toggle("Randomize X", randomizeScaleX);
            if (randomizeScaleX)
            {
                minScaleX = EditorGUILayout.FloatField("Min X", minScaleX);
                maxScaleX = EditorGUILayout.FloatField("Max X", maxScaleX);
            }
            randomizeScaleY = EditorGUILayout.Toggle("Randomize Y", randomizeScaleY);
            if (randomizeScaleY)
            {
                minScaleY = EditorGUILayout.FloatField("Min Y", minScaleY);
                maxScaleY = EditorGUILayout.FloatField("Max Y", maxScaleY);
            }
            randomizeScaleZ = EditorGUILayout.Toggle("Randomize Z", randomizeScaleZ);
            if (randomizeScaleZ)
            {
                minScaleZ = EditorGUILayout.FloatField("Min Z", minScaleZ);
                maxScaleZ = EditorGUILayout.FloatField("Max Z", maxScaleZ);
            }
        }

        if (GUILayout.Button("Apply Randomization"))
        {
            foreach (var obj in targets)
            {
                Transform t = obj as Transform;
                if (t != null)
                {
                    Undo.RecordObject(t, "Randomized Transform");

                    if (randomizePosition)
                    {
                        t.position = new Vector3(
                            randomizePosX ? Random.Range(minPosX, maxPosX) : t.position.x,
                            randomizePosY ? Random.Range(minPosY, maxPosY) : t.position.y,
                            randomizePosZ ? Random.Range(minPosZ, maxPosZ) : t.position.z
                        );
                    }

                    if (randomizeRotation)
                    {
                        t.eulerAngles = new Vector3(
                            randomizeRotX ? Random.Range(minRotX, maxRotX) : t.eulerAngles.x,
                            randomizeRotY ? Random.Range(minRotY, maxRotY) : t.eulerAngles.y,
                            randomizeRotZ ? Random.Range(minRotZ, maxRotZ) : t.eulerAngles.z
                        );
                    }

                    if (randomizeScale)
                    {
                        t.localScale = new Vector3(
                            randomizeScaleX ? Random.Range(minScaleX, maxScaleX) : t.localScale.x,
                            randomizeScaleY ? Random.Range(minScaleY, maxScaleY) : t.localScale.y,
                            randomizeScaleZ ? Random.Range(minScaleZ, maxScaleZ) : t.localScale.z
                        );
                    }
                }
            }
        }
    }
}

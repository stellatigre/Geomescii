using UnityEditor;
using UnityEngine;
using System.Linq;
using MIDI;
using System.Reflection;
using System.Collections.Generic;

public class MidiBehaviorEditor : EditorWindow {

    MidiManager manager;
    List<MidiCcRecieverBase> midiCcListeners;

    int[] componentIndexes = new int[40];
    int[] objectIndexes = new int[40];


    [MenuItem("Window/Midi Behavior Editor")]
    static void Init() {
        ShowWindow();
    }

    static void ShowWindow () {
        EditorWindow.GetWindow<MidiBehaviorEditor>();
        Debug.Log("showed window");
    }

    void OnEnable () {
        Debug.Log("enabled editor window");
        midiCcListeners = 
            GameObject.FindGameObjectsWithTag("Midi Reactive")
                .SelectMany(g => g.GetComponents<MidiCcRecieverBase>()).ToList();

        Debug.Log(midiCcListeners.Count);
    }

    void displayBehavior (MidiCcRecieverBase behavior, int index) {

        Component[] componentArray = null;
        Component selectedComponent = null;
        GameObject selectedObject = behavior.gameObject;
        
        selectedObject = (GameObject)EditorGUILayout.ObjectField(selectedObject, typeof(GameObject), true);

        EditorGUILayout.EnumPopup(behavior.nanoKontrol);

        if (behavior != null) {
            componentArray = behavior.gameObject.GetComponents<Component>();
            if (componentArray != null) {
                string[] components = componentArray.Select(p => p.ToString()).ToArray();
                componentIndexes[index] = EditorGUILayout.Popup(componentIndexes[index], components);
                selectedComponent = componentArray[componentIndexes[index]];

                var props = selectedComponent.GetType().GetProperties()
                            .Where(prop => prop.PropertyType.ToString() != "UnityEngine.Component")
                            .Select(p => p.ToString()).ToArray();

                /*foreach (var p in props) {
                    Debug.Log(p);
                }*/

                EditorGUILayout.Popup(0, props);
            }
        }

        EditorGUILayout.Separator();
    }

    void OnGUI() {
        for (int i=0 ; i<midiCcListeners.Count; i++) {
            displayBehavior(midiCcListeners[i], i);
        }
    }
}

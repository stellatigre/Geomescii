using UnityEditor;
using UnityEngine;
using System.Linq;
using MIDI;
using System.Reflection;
using System.Collections.Generic;

public class MidiBehaviorEditor : EditorWindow {

    MidiManager manager;
    List<MidiCcRecieverBase> midiCcListeners;

    int[] componentIndexes = new int[100];
    int[] objectIndexes = new int[100];
    int[] propertyIndexes = new int[100];
    int[] subPropertyIndexes = new int[100];


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

        Debug.Log("reciever count:" + midiCcListeners.Count);
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
                                .Select(p => p).ToArray();

                var propLabels = props.Select(p => p.ToString()).ToArray();

                propertyIndexes[index] = EditorGUILayout.Popup(propertyIndexes[index], propLabels);
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

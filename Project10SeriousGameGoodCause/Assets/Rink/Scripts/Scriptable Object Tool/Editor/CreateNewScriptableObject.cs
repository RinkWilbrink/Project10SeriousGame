using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/* -----> References, Work progress and TODO <-----
 * 
 * How to create a new SO file
 * https://stackoverflow.com/questions/50564577/creating-a-scriptable-object-in-the-unity-editor
*/

namespace ScriptableObjectTool
{
    public enum SelectedScriptableObjectType {
        ObjectBubble = 0, ObjectPerson = 1
    }

    [InitializeOnLoad, ExecuteInEditMode]
    public class CreateNewScriptableObject : EditorWindow
    {
        // Variables
        private SelectedScriptableObjectType selectedType;
        private List<List<Object>> messageList = new List<List<Object>>();
        // new ObjectName
        string newScriptableObjectName = null;

        // personality traits
        private byte intelligence;
        private byte buisinessOrientedness;
        private byte Caringness;
        private byte HealthandStrength;

        private const int maxCollectiveTraits = 100;

        // ObjectBubble Variables
        private byte roundNumber;
        private byte indexNumber;

        private string newTextMessage;

        private List<List<Object>> roundList;

        // ObjectPerson Variables
        private string PersonName = null;
        // Sprite information for this character
        private Object PersonFace = null;
        private Object PersonBody = null;

        // Layout variables
        const int PersonalityTraitsStartingPos = 101;
        const int IntFieldStartPos = 150;

        // Initialize the window
        [MenuItem("Create Scriptable Object/Open Tool")]
        static void CreateScriptableObjectWindow()
        {
            GetWindow<CreateNewScriptableObject>("Create Scriptable Object");
        }

        // GUI window code, buttons and other items need to be set here.
        private void OnGUI()
        {
            GUILayout.Label("Create new Scriptable Object", EditorStyles.boldLabel);

            GUILayout.Space(2);

            GUILayout.Label("Select Scriptable Object type you want to create!", EditorStyles.boldLabel);

            GUILayout.Space(1);

            selectedType = (SelectedScriptableObjectType)EditorGUILayout.EnumPopup(selectedType);

            GUILayout.Space(5);

            GUILayout.Label("Scriptabel Object Specific Values and Variables", EditorStyles.boldLabel);

            GUILayout.Space(5);

            /*
            if (GUILayout.Button("Test Width"))
            {
                Debug.Log(Screen.width);
            }
            */
            #region Personality Traits

            #region Intelligence
            GUILayout.BeginHorizontal();

            GUILayout.Label("Intelligence");

            Rect IRect = new Rect(IntFieldStartPos, getRectPos(1), getPropperScreenWidth(), 15);
            intelligence = (byte)EditorGUI.IntSlider(IRect, intelligence, 0, 100);

            GUILayout.EndHorizontal();
            #endregion

            GUILayout.Space(2);

            #region BuisinessOrientedness
            GUILayout.BeginHorizontal();

            GUILayout.Label("BuisinessOrientedness");

            Rect BORect = new Rect(IntFieldStartPos, getRectPos(2), getPropperScreenWidth(), 15);
            buisinessOrientedness = (byte)EditorGUI.IntSlider(BORect, buisinessOrientedness, 0, 100);

            //buisinessOrientedness = (byte)EditorGUI.IntField(BORect, buisinessOrientedness);
            //buisinessOrientedness = (byte)EditorGUILayout.IntSlider(buisinessOrientedness, 0, 100);
            //buisinessOrientedness = (byte)EditorGUILayout.IntField(buisinessOrientedness);

            GUILayout.EndHorizontal();
            #endregion

            GUILayout.Space(2);

            #region Caringness
            GUILayout.BeginHorizontal();

            GUILayout.Label("Caringness");

            Rect CRect = new Rect(IntFieldStartPos, getRectPos(3), getPropperScreenWidth(), 15);
            Caringness = (byte)EditorGUI.IntSlider(CRect, Caringness, 0, 100);

            GUILayout.EndHorizontal();
            #endregion

            GUILayout.Space(2);

            #region HealthandStrenght
            GUILayout.BeginHorizontal();

            GUILayout.Label("HealthandStrength");

            Rect HaSRect = new Rect(IntFieldStartPos, getRectPos(4), getPropperScreenWidth(), 15);
            HealthandStrength = (byte)EditorGUI.IntSlider(HaSRect, HealthandStrength, 0, 100);

            GUILayout.EndHorizontal();
            #endregion

            #endregion

            GUILayout.Space(1);

            GUILayout.Label(string.Format("Personality traits collective total = {0} / {1}", intelligence + buisinessOrientedness + HealthandStrength + Caringness, maxCollectiveTraits));

            GUILayout.Space(10);

            GUILayout.Label("Scriptable Object specific values", EditorStyles.boldLabel);

            GUILayout.Space(4);

            if (selectedType == SelectedScriptableObjectType.ObjectBubble)
            {
                EditorGUILayout.BeginHorizontal();
                // Input the round that the user wants to add a new
                GUILayout.Space(80);
                GUILayout.Label(new GUIContent("New Object Name = ", "This number can't be 0, Round 0 doesn't exist"));

                // Prevent the Round from being 0, there is no Round 0. It's quite a simple spell but unbreakable
                if (roundNumber < 1) {
                    roundNumber = 1;
                }
                roundNumber = (byte)EditorGUILayout.IntField(roundNumber);

                roundList = null;
                roundList = getAllScriptableObjects();

                indexNumber = (byte)(roundList.ToArray()[roundNumber - 1].Count + 1);

                GUILayout.Label(string.Format("_ {0}", indexNumber.ToString()));

                GUILayout.Space(70);
                EditorGUILayout.EndHorizontal();

                GUILayout.Space(5);

                newTextMessage = EditorGUILayout.TextField("Text Message", newTextMessage);
            }
            if (selectedType == SelectedScriptableObjectType.ObjectPerson)
            {
                PersonName = EditorGUILayout.TextField("Person Name", PersonName);

                GUILayout.Space(10);

                // Set the Face of the person
                PersonFace = EditorGUILayout.ObjectField(PersonFace, typeof(Sprite), false);

                GUILayout.Space(2);

                // Set the body of the person
                PersonFace = EditorGUILayout.ObjectField(PersonFace, typeof(Sprite), false);
            }

            GUILayout.Space(10);

            if (GUILayout.Button("Create new Scriptable Object"))
            {
                if ((intelligence + buisinessOrientedness + HealthandStrength + Caringness) <= maxCollectiveTraits)
                {
                    ScriptableObjectsTypes newScriptableObject = new ScriptableObjectsTypes()
                    {
                        Intelligence = 1,
                        BuisinessOrientedness = 2,
                        HealthandStrength = 3,
                        Caringness = 4
                    };

                    if (selectedType == SelectedScriptableObjectType.ObjectBubble)
                    {
                        newScriptableObject.TextMessage = newTextMessage;

                        CreateFile(new ObjectBubble(), "TestFolder");
                    }
                    if (selectedType == SelectedScriptableObjectType.ObjectPerson)
                    {

                        //CreateFile(new ObjectPerson(), "TestFolder");
                    }

                    if (!string.IsNullOrEmpty(newScriptableObjectName) && !string.IsNullOrWhiteSpace(newScriptableObjectName))
                    {
                        ObjectBubble newBubble = new ObjectBubble()
                        {
                            Intelligence = 1,
                            BuisinessOrientedness = 2,
                            Caringness = 3,
                            HealthandStrength = 4,
                            TextMessage = "Test Text Bubble"
                        };

                        // Create new Scriptable Object
                        //CreateFile(newBubble, "TestFolder");
                    }
                }
                else
                {
                    Debug.Log("Personality traits exceted the maximum total amount, lower some settings to stay under the collective limit");
                }
            }
        }

        /// <summary></summary>
        /// <param name="newBubble">The Object Bubble</param>
        /// <param name="FilePath"></param>
        private void CreateFile(ObjectBubble newBubble, string FilePath)
        {
            // Save the new Asset File
            AssetDatabase.CreateAsset(newBubble, string.Format("{0}/{1}.asset", FilePath, newScriptableObjectName));
            AssetDatabase.SaveAssets();

            Selection.activeObject = newBubble;
            AssetDatabase.Refresh();
        }
        private void CreateFile(ObjectPerson newBubble, string FilePath)
        {
            // Save the new Asset File
            AssetDatabase.CreateAsset(newBubble, string.Format("{0}/{1}.asset", FilePath, newScriptableObjectName));
            AssetDatabase.SaveAssets();

            Selection.activeObject = newBubble;
            AssetDatabase.Refresh();
        }

        private List<List<Object>> getAllScriptableObjects()
        {
            List<List<Object>> MessageList = new List<List<Object>>();

            Object[] people = Resources.LoadAll("DialogSystemObjects", typeof(ObjectPerson));
            Object[] messages = Resources.LoadAll("DialogSystemObjects", typeof(ObjectBubble));

            // Go through all objects and at them to their appropriate List in the Global List
            for (int round = 1; round <= messages.Length; round++)
            {
                List<Object> roundList = new List<Object>();
                for (int i = 0; i < messages.Length; i++)
                {
                    string[] name = messages[i].name.Split('_');
                    // Check current message object if it should be added to this round
                    if (name[0] == round.ToString())
                    {
                        roundList.Add(messages[i]);
                    }

                    // Cleanup memory from local variables
                    name = null;
                }

                // Check if the list has any content, if so add it to the global list
                if (roundList.Count > 0)
                {
                    MessageList.Add(roundList);
                }

                // Cleanup local variable
                roundList = null;
            }
            people = null;
            messages = null;

            return MessageList;
        }

        private int getRectPos(byte instance) {
            if(instance > 0) { instance -= 1; }
            return PersonalityTraitsStartingPos + ((instance) * 15) + (instance * 4);
        }

        private int getPropperScreenWidth()
        {
            return (int)(EditorGUIUtility.currentViewWidth - (IntFieldStartPos + 7));
        }
    }

    public class ScriptableObjectsTypes : PersonalityTraits
    {
        // ObjectBubble variables and values
        public string TextMessage;

        // ObjectPerson variables and values
        public Sprite Face;
        public Sprite Body;
        private ObjectBubble bubble;

        public ScriptableObjectsTypes()
        {

        }
    }

    // where T: PersonalityTraits
    public class genericSriptableObject<T> :PersonalityTraits
    {
        private T memberValue;

        // ObjectBubble variables and values
        public string TextMessage;

        // ObjectPerson variables and values
        public Sprite Face;
        public Sprite Body;
        private ObjectBubble bubble;

        public genericSriptableObject(T value)
        {
            memberValue = value;
        }

        public T genericMethod(T genericValue)
        {
            return genericValue;
        }

        public T value { get; set; }
    }
}
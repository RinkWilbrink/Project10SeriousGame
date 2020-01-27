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
        private SelectedScriptableObjectType selectedType, lastType;
        private List<List<Object>> messageList = new List<List<Object>>();
        // new ObjectName
        string newScriptableObjectName = null;

        // personality traits
        private byte m_intelligence;
        private byte m_buisinessOrientedness;
        private byte m_caringness;
        private byte m_healthandStrength;

        private const int maxCollectiveTraits = 100;

        // Scriptable Object paths
        private const string PersonSavePath = "Assets/Resources/DialogSystemObjects/PersonObjects";
        private const string BubbleSavePath = "Assets/Resources/DialogSystemObjects/BubbleMessages";

        // ObjectBubble Variables
        private byte m_roundNumber;
        private byte m_indexNumber;

        private string m_newTextMessage;

        private List<List<Object>> roundList;

        // ObjectPerson Variables
        private string m_personName = null;
        // Sprite information for this character
        private Object m_PersonFace = null;
        private Object m_PersonBody = null;

        // Layout variables
        const int PersonalityTraitsStartingPos = 101;
        const int IntFieldStartPos = 150;

        // Initialize the window
        [MenuItem("Create Scriptable Object/Open Tool")]
        static void CreateScriptableObjectWindow()
        {
            // Initialize the GUI window
            CreateNewScriptableObject createNewScriptableObject = GetWindow<CreateNewScriptableObject>("Create Scriptable Object");
            // Call the start function
            createNewScriptableObject.start();
        }

        public void start()
        {

        }

        // GUI window code, buttons and other items need to be set here.
        private void OnGUI()
        {
            GUILayout.Label("Create new Scriptable Object", EditorStyles.boldLabel);

            GUILayout.Space(2);

            GUILayout.Label("Select Scriptable Object type you want to create!", EditorStyles.boldLabel);

            GUILayout.Space(1);

            selectedType = (SelectedScriptableObjectType)EditorGUILayout.EnumPopup(selectedType);

            if(selectedType != lastType)
            {
                newScriptableObjectName = "";
                lastType = selectedType;
            }

            GUILayout.Space(5);

            GUILayout.Label("Scriptabel Object Specific Values and Variables", EditorStyles.boldLabel);

            GUILayout.Space(5);
            
            #region Personality Traits

            #region Intelligence
            GUILayout.BeginHorizontal();

            GUILayout.Label("Intelligence");

            Rect IRect = new Rect(IntFieldStartPos, getRectPos(1), getPropperScreenWidth(), 15);
            m_intelligence = (byte)EditorGUI.IntSlider(IRect, m_intelligence, 0, 100);

            GUILayout.EndHorizontal();
            #endregion

            GUILayout.Space(2);

            #region BuisinessOrientedness
            GUILayout.BeginHorizontal();

            GUILayout.Label("BuisinessOrientedness");

            Rect BORect = new Rect(IntFieldStartPos, getRectPos(2), getPropperScreenWidth(), 15);
            m_buisinessOrientedness = (byte)EditorGUI.IntSlider(BORect, m_buisinessOrientedness, 0, 100);

            GUILayout.EndHorizontal();
            #endregion

            GUILayout.Space(2);

            #region Caringness
            GUILayout.BeginHorizontal();

            GUILayout.Label("Caringness");

            Rect CRect = new Rect(IntFieldStartPos, getRectPos(3), getPropperScreenWidth(), 15);
            m_caringness = (byte)EditorGUI.IntSlider(CRect, m_caringness, 0, 100);

            GUILayout.EndHorizontal();
            #endregion

            GUILayout.Space(2);

            #region HealthandStrenght
            GUILayout.BeginHorizontal();

            GUILayout.Label("HealthandStrength");

            Rect HaSRect = new Rect(IntFieldStartPos, getRectPos(4), getPropperScreenWidth(), 15);
            m_healthandStrength = (byte)EditorGUI.IntSlider(HaSRect, m_healthandStrength, 0, 100);

            GUILayout.EndHorizontal();
            #endregion

            #endregion

            GUILayout.Space(1);

            GUILayout.BeginHorizontal();

            GUILayout.Label("Personality traits collective total = ");

            GUILayout.Space(-84);

            // Set the color for the text
            short statCount = (short)(m_intelligence + m_buisinessOrientedness + m_healthandStrength + m_caringness);
            if (statCount >= 0 && statCount <= 100) {
                GUI.color = Color.green;
            }
            else {
                GUI.color = Color.red;
            }

            GUILayout.Label(string.Format("{0} / {1}", m_intelligence + m_buisinessOrientedness + m_healthandStrength + m_caringness, maxCollectiveTraits));

            // Reset The Layout
            GUI.color = Color.white;
            GUILayout.EndHorizontal();

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
                if (m_roundNumber < 1) {
                    m_roundNumber = 1;
                }

                // Set roundList
                roundList = null;
                roundList = getAllScriptableObjects();

                if (m_roundNumber > roundList.Count + 1) {
                    GUI.color = Color.red;
                } else if (m_roundNumber == roundList.Count + 1) {
                    GUI.color = Color.white;
                } else {
                    GUI.color = Color.green;
                }
                // Set roundList
                roundList = null;
                roundList = getAllScriptableObjects();

                // set the Round number
                m_roundNumber = (byte)EditorGUILayout.IntField(m_roundNumber);

                GUI.color = Color.white;

                // Set index number and check if the round exists, if not set Index to 1.
                try {
                    m_indexNumber = (byte)(roundList.ToArray()[m_roundNumber - 1].Count + 1);
                }
                catch {
                    m_indexNumber = 1;
                }

                GUILayout.Label(string.Format("_ {0}", m_indexNumber.ToString()));

                // Set the name of the new Scriptable Object.
                newScriptableObjectName = string.Format("{0}_{1}", m_roundNumber, m_indexNumber);

                GUILayout.Space(70);
                EditorGUILayout.EndHorizontal();

                GUILayout.Space(5);

                m_newTextMessage = EditorGUILayout.TextField("Text Message", m_newTextMessage);
            }
            if (selectedType == SelectedScriptableObjectType.ObjectPerson)
            {
                newScriptableObjectName = EditorGUILayout.TextField("Person Name", newScriptableObjectName);

                GUILayout.Space(10);

                // Set the Face of the person
                m_PersonFace = EditorGUILayout.ObjectField(m_PersonFace, typeof(Sprite), false);

                GUILayout.Space(2);

                // Set the body of the person
                m_PersonFace = EditorGUILayout.ObjectField(m_PersonFace, typeof(Sprite), false);
            }

            GUILayout.Space(10);

            if (GUILayout.Button("Create new Scriptable Object"))
            {
                if ((m_intelligence + m_buisinessOrientedness + m_healthandStrength + m_caringness) <= maxCollectiveTraits)
                {
                    if (!string.IsNullOrEmpty(newScriptableObjectName) && !string.IsNullOrWhiteSpace(newScriptableObjectName))
                    {
                        // Create a new Scriptable Object
                        if (selectedType == SelectedScriptableObjectType.ObjectBubble)
                        {
                            if(string.IsNullOrEmpty(m_newTextMessage) || string.IsNullOrWhiteSpace(m_newTextMessage)) {
                                Debug.LogErrorFormat("Error with Text Message! message: {0}.", m_newTextMessage);
                                return;
                            }
                            ObjectBubble newBubble = new ObjectBubble() {
                                Intelligence = m_intelligence,
                                BuisinessOrientedness = m_buisinessOrientedness,
                                Caringness = m_caringness,
                                HealthandStrength = m_healthandStrength,
                                // Object Specific values
                                TextMessage = m_newTextMessage
                            };

                            CreateFile(newBubble);
                        }
                        if (selectedType == SelectedScriptableObjectType.ObjectPerson)
                        {
                            ObjectPerson newPerson = new ObjectPerson()
                            {
                                Intelligence = m_intelligence,
                                BuisinessOrientedness = m_buisinessOrientedness,
                                Caringness = m_caringness,
                                HealthandStrength = m_healthandStrength,
                                // Object Specific values
                                PersonName = m_personName,
                                Face = (Sprite)m_PersonFace,
                                Body = (Sprite)m_PersonBody
                            };

                            CreateFile(newPerson);
                        }
                    }
                    else {
                        Debug.LogErrorFormat("Error with newScriptableObjectName! name: {0}.", newScriptableObjectName);
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
        private void CreateFile(ObjectBubble newBubble)
        {
            // Save the new Asset File
            AssetDatabase.CreateAsset(newBubble, string.Format("{0}/{1}.asset", BubbleSavePath, newScriptableObjectName));
            AssetDatabase.SaveAssets();

            Selection.activeObject = newBubble;
            AssetDatabase.Refresh();
        }
        private void CreateFile(ObjectPerson newBubble)
        {
            // Save the new Asset File
            AssetDatabase.CreateAsset(newBubble, string.Format("{0}/{1}.asset", PersonSavePath, m_personName));
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
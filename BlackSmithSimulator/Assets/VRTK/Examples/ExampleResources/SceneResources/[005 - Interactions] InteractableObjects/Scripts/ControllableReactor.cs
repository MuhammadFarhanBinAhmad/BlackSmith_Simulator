namespace VRTK.Examples
{
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.SceneManagement;
    using VRTK.Controllables;

    public class ControllableReactor : MonoBehaviour
    {
        public VRTK_BaseControllable controllable;
        public Text displayText;
        public string outputOnMax = "Maximum Reached";
        public string outputOnMin = "Minimum Reached";
        Scene current_Scene;

        private void Start()
        {
            current_Scene = SceneManager.GetActiveScene();
        }

        protected virtual void OnEnable()
        {
            controllable = (controllable == null ? GetComponent<VRTK_BaseControllable>() : controllable);
            controllable.ValueChanged += ValueChanged;
            controllable.MaxLimitReached += MaxLimitReached;
            controllable.MinLimitReached += MinLimitReached;
        }

        protected virtual void ValueChanged(object sender, ControllableEventArgs e)
        {
            if (displayText != null)
            {
                displayText.text = e.value.ToString("F1");
            }
        }

        protected virtual void MaxLimitReached(object sender, ControllableEventArgs e)
        {
            if (outputOnMax != "")
            {
                //BUTTON PRESSED
                if(CustomerSpawner.Customer_Already_Serve == 3)
                {
                    SceneManager.LoadScene("EndOfDay");
                }
                else
                {
                    if(FindObjectOfType<CustomerAI>() !=null)
                    {
                        FindObjectOfType<CustomerAI>().CollectingWeapon();//customer collect weapon
                    }
                }
            }
            if (current_Scene.name == "EndOfDay")
            {
                SceneManager.LoadScene("Pause_Main_Menu");
            }
            if (current_Scene.name == "Pause_Main_Menu")
            {
                SceneManager.LoadScene("Game_Level");
            }
        }
        protected virtual void MinLimitReached(object sender, ControllableEventArgs e)
        {
            if (outputOnMin != "")
            {
                Debug.Log(outputOnMin);
            }
        }
    }
}
using UnityEngine;
using UnityEngine.UI;
namespace StarForceDemo
{
    public class UpdateResourceForm : MonoBehaviour
    {   
        [SerializeField]
        private Text m_DescriptionText = null;

        [SerializeField]
        private Slider m_ProgressSlider = null;

        private 
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SetProgress(float progress, string description){
            m_ProgressSlider.value = progress;
            m_DescriptionText.text = description;
        }
    }
}


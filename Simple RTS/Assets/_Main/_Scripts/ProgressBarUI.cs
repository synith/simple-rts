using UnityEngine;
using UnityEngine.UI;

namespace Synith
{
    /// <summary>
    /// ProgressBarUI
    /// </summary>
    public class ProgressBarUI : MonoBehaviour
    {
        [SerializeField] CameraMover cameraMover;
        [SerializeField] Image fill;
        void Start()
        {
            cameraMover.OnZoomDistanceChanged += CameraMover_OnZoomLevelChanged;
        }

        void CameraMover_OnZoomLevelChanged(object sender, float e)
        {
            SetProgressBarFillAmount(e);
        }

        public void SetProgressBarFillAmount(float fillAmount)
        {
            fill.fillAmount = fillAmount;
        }
    }
}

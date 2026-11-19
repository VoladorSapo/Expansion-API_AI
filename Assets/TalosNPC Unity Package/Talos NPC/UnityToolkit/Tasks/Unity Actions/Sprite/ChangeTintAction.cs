using TalosNPC.Core;
using UnityEngine;

namespace TalosNPC.UnityToolkit
{
    /// <summary>
    /// Change the sprite of the renderer component. 
    /// If time is bigger that 0, the action will end when the time passes and
    /// revert the sprite value. Otherwise the action will end inmediatly.
    /// </summary>
    [SelectionGroup("SPRITE")]
    [System.Serializable]

    public class ChangeTintAction : UnityAction
    {
        [SerializeField] Color tintColor;

        [SerializeField] float time = 1f;

        [SerializeField] bool succes = true;

        private Color _previousColor;
        private float _currentTime;

        public override void Start()
        {
            _previousColor = context.Renderer.Tint;
            context.Renderer.Tint = tintColor;
            _currentTime = 0;
        }

        public override Status Update()
        {
            _currentTime += Time.deltaTime;
            if (_currentTime > time)
            {
                if(succes)
                return Status.Success;
                else return Status.Failure;
            }
            else
            {
                return Status.Running;
            }
        }

        public override void Stop()
        {
            if (time > 0f)
            {
                context.Renderer.Tint = _previousColor;
            }
        }

        public override string ToString()
        {
            var colorTag = $"#{ColorUtility.ToHtmlStringRGB(tintColor)}";
            string color =  $"<color={colorTag}>color</color>";
            if (time > 0f)
            {
                return $"Change renderer tint color to {color} by {time} second(s)";
            }
            else
            {
                return $"Change renderer tint color to {color}";
            }
        }
    }

    public class SuccesFailAction : UnityAction
    {

        [SerializeField] float time = 1f;

        [SerializeField] bool succes = true;
        private float _currentTime;

        public override void Start()
        {
            _currentTime = 0;
        }

        public override Status Update()
        {
            _currentTime += Time.deltaTime;
            if (_currentTime > time)
            {
                if (succes)
                    return Status.Success;
                else return Status.Failure;
            }
            else
            {
                return Status.Running;
            }
        }
    }
}

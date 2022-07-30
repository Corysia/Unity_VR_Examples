using UnityEngine.XR.Interaction.Toolkit;

// @author Jattier (jattier 'at' hotmail.com)
namespace Scenes.ControllerButtonPress.Scripts
{
    public class XxlGrabInteractable : XRGrabInteractable
    {
        private bool _bHeld;

        public enum HoldingHand
        {
            None = 0,
            Right = 1,
            Left = 2
        }

        private HoldingHand _hand = HoldingHand.None;

        public bool IsHeld()
        {
            return _bHeld;
        }

        public HoldingHand WhichHand()
        {
            return _hand;
        }

        protected override void OnSelectEntered(SelectEnterEventArgs args)
        {
            base.OnSelectEntered(args);
            _hand = args.interactorObject.transform.name.Contains(HoldingHand.Left.ToString()) ? HoldingHand.Left : HoldingHand.Right;
            _bHeld = true;
        }

        protected override void OnSelectExited(SelectExitEventArgs args)
        {
            base.OnSelectExited(args);
            _hand = HoldingHand.None;
            _bHeld = false;
        }
    }
}

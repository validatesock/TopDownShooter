namespace VldateSck
{
    namespace Input
    {
        public enum InputType
        {
            KB_MOUSE = 0,
            XBOX_CONTROLLER,
            PS4_CONTROLLER,
            CUSTOM_CONTROLLER
        }

        public enum InputLogical
        {
            None = -1,
            PRIMARY_ACTION = 0,
            CONFIRM,
            SECONDARY_ACTION,
            MENU,
            CANCEL,
            BACK,
            DPAD_FORWARD,
            DPAD_BACK,
            DPAD_LEFT,
            DPAD_RIGHT,
        }
    }
}

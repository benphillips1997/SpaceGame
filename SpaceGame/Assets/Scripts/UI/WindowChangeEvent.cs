namespace UI
{
    public struct WindowChangeEvent
    {
        public GameWindowType type;
        public WindowChangeEvent(GameWindowType t)
        {
            type = t;
        }
    }
}
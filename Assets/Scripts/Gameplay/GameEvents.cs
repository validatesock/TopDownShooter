namespace VldateSck
{
    public class HealthChangedEvent : VSGameEvent
    {
        public Character Character;
        public float Health;

        public HealthChangedEvent(Character character, float health)
        {
            this.Health = health;
            this.Character = character;
        }
    }

    public class StaminaChangedEvent : VSGameEvent
    {
        public Character Character;
        public float Stamina;

        public StaminaChangedEvent(Character character, float stamina)
        {
            this.Character = character;
            this.Stamina = stamina;
        }
    }
}


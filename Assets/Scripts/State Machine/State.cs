namespace State_Machine
{
    public abstract class State
    {
        protected float Time { get; set; }

        public StateMachine StateMachine;
        
        public virtual void OnEnter(StateMachine stateMachine)
        {
            stateMachine = StateMachine;
        }
        
        public virtual void OnUpdate()
        {
            
        }
        
        public virtual void OnExit()
        {
            
        }
    }
}
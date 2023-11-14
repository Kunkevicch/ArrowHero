namespace ArrowHero.Core
{
    public abstract class State
    {
        protected readonly FSM _FSM;

        public State(FSM FSM)
        {
            _FSM = FSM;
        }

        public virtual void Enter()
        { }

        public virtual void Update()
        { }

        public virtual void FixedUpdate()
        { }

        public virtual void Exit()
        { }
    }
}
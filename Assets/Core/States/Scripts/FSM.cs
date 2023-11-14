using System;
using System.Collections.Generic;

namespace ArrowHero.Core
{
    public sealed class FSM
    {
        private State StateCurrent { get; set; }

        private Dictionary<Type, State> _states = new Dictionary<Type, State>();

        public void AddState(State state)
        {
            _states.Add(state.GetType(), state);
        }

        public void SetState<T>() where T : State
        {
            var type = typeof(T);

            if ( StateCurrent != null && StateCurrent.GetType() == type ) return;

            if ( _states.TryGetValue(type, out var newState) )
            {
                StateCurrent?.Exit();

                StateCurrent = newState;

                StateCurrent.Enter();
            }
        }

        public void Update()
        {
            StateCurrent?.Update();
        }

        public void FixedUpdate()
        {
            StateCurrent?.FixedUpdate();
        }
    }
}
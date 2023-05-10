# State Meachine
  - state
    ```  c#
      public abstract class State {
        public State(PlayerSystem player)
        public virtual IEnumerator Start()
        public virtual IEnumerator DrawCard()
        public virtual IEnumerator DiscardCard()
        public virtual IEnumerator PlayCard()
        public virtual IEnumerator GiveHints()
        public virtual IEnumerator End()
      }
      
      
      public class PlayerTurn : State 
      {
          public PlayerTurn(PlayerSystem player) : base(player)
          public override IEnumerator DrawCard()
          public override IEnumerator PlayCard()
      }
      
      public class EndTurn : State
      {
          public EndTurn(PlayerSystem player) : base(player)
          public override IEnumerator End()
      }
      
      public class EnemyTurn : State 
      {
          public EnemyTurn(PlayerSystem player) : base(player) 
      }
      
      public class EndTurn : State
      {
          public EndTurn(PlayerSystem player) : base(player) 
          public override IEnumerator End()
      }


    ```
    
   - statemeachine
     ``` c#

         public abstract class StateMeachine : MonoBehaviour
        {
            [SerializeField] protected State state_;
            public void SetState(State state)
            public State GetState()
        }
        
        public class PlayerSystem : StateMeachine{
          public bool PlayCard()
          public bool Discard()
          public void EndTurn()
          public bool DrawCard()
        }

     ```

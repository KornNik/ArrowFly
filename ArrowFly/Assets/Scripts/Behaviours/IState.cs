namespace Behaviours
{
    interface IState
    {
        void EnterState();
        void ExitState();
        void LogicUpdate();
        void LogicFixedUpdate();
        void LogicLateUpdate();
    }
}

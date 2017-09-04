using System;

namespace MVVM.Messenger
{
    //ToDo comment this
    public class WeakReferenceAction
    {
        private Action _action;

        public WeakReferenceAction(object target, Action action)
        {
            Target = new WeakReference(target);
            _action = action;
        }

        public WeakReference Target { get; private set; }

        public void Execute()
        {
            if (_action != null && Target != null && Target.IsAlive)
                _action.Invoke();
        }

        public void Unload()
        {
            Target = null;
            _action = null;
        }
    }
    //ToDo comment this
    public class WeakReferenceAction<T> : WeakReferenceAction, IActionParameter
    {
        public WeakReferenceAction(object target, Action<T> action)
            : base(target, null)
        {
            Action = action;
        }

        public new void Execute()
        {
            if (Action != null && Target != null && Target.IsAlive)
                Action(default(T));
        }

        public void Execute(T parameter)
        {
            if (Action != null && Target != null && Target.IsAlive)
                Action(parameter);
        }

        public Action<T> Action { get; }

        #region IActionParameter Members
        public void ExecuteWithParameter(object parameter)
        {
            Execute((T)parameter);
        }
        #endregion
    }
}
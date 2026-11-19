using System;
using UnityEngine;

namespace TalosNPC.UnityToolkit.GUIDesigner.Framework
{
    using Core;
    using System.Reflection;
    using UnityToolkit;

    /// <summary>
    /// Data class to serialize a component method call.
    /// </summary>
    [Serializable]

    public class SerializedContextMethod : ICloneable
    {
        /// <summary>
        /// The name of the component. If is empty, the used component will be the behaviour runner.
        /// </summary>
        public string componentName;

        /// <summary>
        /// The name of the method called.
        /// </summary>
        public string methodName;



        public object Clone()
        {
            return MemberwiseClone();
        }

        public Delegate GetDelegate(Component defaultComponent, Type[] arguments, Type delegateType)
        {
            if (string.IsNullOrWhiteSpace(methodName) || defaultComponent == null)
            {
                return null;
            }
            if (!delegateType.IsSubclassOf(typeof(Delegate))) return null;

            Component component = string.IsNullOrWhiteSpace(componentName) ? defaultComponent : defaultComponent.gameObject.GetComponent(componentName);
            Action error = () => Debug.LogError($"No valid action found for method {methodName} in component {componentName}", defaultComponent.gameObject);

            if (component == null)
            {
                Debug.LogWarning($"BUILD ERROR: The specified component ({componentName}) does not exist or is not attached to runner.", defaultComponent.gameObject);
                return error;
            }

            MethodInfo methodInfo = component.GetType().GetMethod(methodName, arguments);

            if (methodInfo == null)
            {
                Debug.LogWarning($"BUILD ERROR: The method called {methodName} was not found. Can't create a delegate.", defaultComponent.gameObject);

            
                return error;
            }

            try
            {
                Debug.Log("create delegate");

                var del = methodInfo.CreateDelegate(delegateType, component);
                return del;
            }
            catch
            {
                Debug.LogWarning("BUILD ERROR: The method don't match the required parameters. Can't create a delegate.", defaultComponent.gameObject);
                return error;
            }
            
        }

        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(methodName)) return "";
            return $"{(string.IsNullOrEmpty(componentName) ? "$runner" : componentName)}.{methodName}";
        }
    }

    /// <summary>
    /// Serialized method data that uses their fields to generate a delegate of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of the delegate that stores the method.</typeparam>
    [Serializable]
    public class SerializedContextMethod<T> : SerializedContextMethod where T : Delegate
    {
        protected virtual Type[] FunctionArgs => new Type[0];
       
        public T CreateDelegate(Component runner, T actionIfEmpty = null)
        {
            var del = GetDelegate(runner, FunctionArgs, typeof(T));
            if(del is T typedDelegate)
            {

                return typedDelegate;
            }
            else
            {

                return actionIfEmpty;
            }
        }
    }

    /// <summary>
    /// Serialized method for void events.
    /// </summary>
    [Serializable]
    public class ContextualSerializedAction : SerializedContextMethod<Action>
    {
    }

    /// <summary>
    /// Serialized method for action update event.
    /// </summary>
    [Serializable]
    public class ContextualSerializedStatusFunction : SerializedContextMethod<Func<Status>>
    {
    }

    /// <summary>
    /// Serialized method for PerceptionReference check event.
    /// </summary>
    [Serializable]
    public class ContextualSerializedBoolFunction : SerializedContextMethod<Func<bool>>
    {
    }

    public class NonExistentActionException : Exception
    {
      public  string componentName;
      public  string methodName;
        public NonExistentActionException(string message, string componentName, string methodName)
        { 
        this.componentName = componentName;
            this.methodName = methodName;
        }
      

    }
}
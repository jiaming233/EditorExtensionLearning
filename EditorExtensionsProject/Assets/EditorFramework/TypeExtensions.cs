using System;
using System.Collections.Generic;
using System.Linq;

namespace EditorExtensions
{
    public static class TypeExtensions
    {
        public static IEnumerable<Type> GetSubTypesInAssembly(this Type self)
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                //ÓÅ»¯ËÑË÷
             .Where(assembly => assembly.FullName.StartsWith("Assembly"))
             //.Select(assembly =>
             //{
             //    UnityEngine.Debug.Log(assembly.FullName);
             //    return assembly;
             //})
             .SelectMany(assembly => assembly.GetTypes())
             .Where(type => type.IsSubclassOf(self));
        }

        public static IEnumerable<Type> GetSubTypesWithClassAttributeInAssembly<T>(this Type self) where T : Attribute
        {
            return AppDomain.CurrentDomain.GetAssemblies()
             .Where(assembly => assembly.FullName.StartsWith("Assembly"))
             .SelectMany(assembly => assembly.GetTypes())
             .Where(type => type.GetCustomAttributes(typeof(T), true).Length > 0);
        }
    }
}
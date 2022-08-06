using System;
using System.Collections.Generic;
using Morpeh;
using UnityEngine.UI;

namespace Code.Utility
{
    public static class UiExtension
    {
        public static void OnClickAdd<T>(this Button button, Entity entity) where T : struct, IComponent
        {
            button.onClick.AddListener(() =>
            {
                if (entity.IsNullOrDisposed())
                {
                    throw new Exception("OnClickAdd(Button, entity): Entity is null or disposed");
                }
                
                entity.AddComponent<T>();
            });
        }
        
        public static void OnClickAdd<T>(this IEnumerable<Button> buttons, Entity entity) where T : struct, IComponent
        {
            foreach (var button in buttons)
            {
                button.onClick.AddListener(() =>
                {
                    if (entity.IsNullOrDisposed())
                    {
                        throw new Exception("OnClickAdd(Button, entity): Entity is null or disposed");
                    }
                
                    entity.AddComponent<T>();
                });
            }
        }
    }
}
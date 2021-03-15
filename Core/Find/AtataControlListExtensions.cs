using System;

namespace Atata
{
    public static class AtataControlListExtensions
    {
        public static TItem FindByKey<TItem, TOwner>(
            this ControlList<TItem, TOwner> control,
            string key
        ) where TItem : Control<TOwner>
            where TOwner : PageObject<TOwner>
        {
            return control.GetByXPathCondition(
                $"@data-key='{key}'"
            );
        }

        public static TItem FindByClientId<TItem, TOwner>(
            this ControlList<TItem, TOwner> control,
            string clientId
        ) where TItem : Control<TOwner>
            where TOwner : PageObject<TOwner>
        {
            return control.GetByXPathCondition(
                $"@data-client-id='{clientId}'"
            );
        }

        public static TOwner AssertByAction<TItem, TOwner>(
            this TItem item,
            Action<TItem> action
        ) where TItem : Control<TOwner>
            where TOwner : PageObject<TOwner>
        {
            action(item);
            return item.Owner;
        }
    }
}

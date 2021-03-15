namespace Atata
{
    public class FindBySelectorAttribute
        : FindByAttributeAttribute
    {
        public FindBySelectorAttribute(string selector)
            : base("data-selector", selector)
        { }
    }
}

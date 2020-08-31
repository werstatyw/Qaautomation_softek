using System;
namespace Qaautomation_softek.Framework.UI
{
    [AttributeUsage(AttributeTargets.Field)]
    public class FindByAttribute : Attribute
    {
        private readonly String locator;
        public String Locator
        {
            get
            {
                return locator;
            }
        }
        public FindByAttribute(String locatorString)
        {
        }
    }
}

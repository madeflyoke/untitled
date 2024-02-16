using System;
using Units.Enums;

namespace Factories.Units.SubFactories.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class UnitVariantAttribute : Attribute
    {
        public UnitVariant UnitVariant;
    }
}
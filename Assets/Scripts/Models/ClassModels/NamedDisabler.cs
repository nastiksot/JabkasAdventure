using System;
using Disablers;

namespace Models.ClassModels
{
    [Serializable]
    public class NamedDisabler : Named<string, BaseObjectDisabler>
    {
    }
}
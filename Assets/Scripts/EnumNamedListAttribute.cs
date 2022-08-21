 using UnityEngine;
 
namespace LyeJam
{
    public class EnumNamedListAttribute : PropertyAttribute
    {
        public string[] Names;
        public EnumNamedListAttribute(System.Type namesEnumType)
        {
            Names = System.Enum.GetNames(namesEnumType);
        }
    }
}

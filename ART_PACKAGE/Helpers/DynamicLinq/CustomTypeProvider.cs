using System.Reflection;
using System.Linq.Dynamic.Core.CustomTypeProviders;
namespace ART_PACKAGE.Helpers.DynamicLinq
{
    public class CustomTypeProvider : IDynamicLinkCustomTypeProvider
    {
        public HashSet<Type> GetCustomTypes()
        {
            throw new NotImplementedException();
        }

        public Dictionary<Type, List<MethodInfo>> GetExtensionMethods()
        {
            throw new NotImplementedException();
        }

        public Type? ResolveType(string typeName)
        {
            throw new NotImplementedException();
        }

        public Type? ResolveTypeBySimpleName(string simpleTypeName)
        {
            throw new NotImplementedException();
        }
    }
}

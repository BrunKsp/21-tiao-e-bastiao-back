using System.Reflection;
using data.Infra.Documents.Mappings;

namespace data.Infra.Documents;

public static class RegisterDocumentsMappings
{
    public static void RegisterDocumentsMapping()
    {
        var assembly = Assembly.GetAssembly(typeof(RegisterDocumentsMappings));

        var classMaps = assembly.GetTypes()
              .Where(t => t.BaseType != null && t.BaseType.IsGenericType &&
                t.BaseType.GetGenericTypeDefinition() == typeof(DocumentMapping<>));

        foreach (var classMap in classMaps)
            Activator.CreateInstance(classMap);
    }
}
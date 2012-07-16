using System;
using System.CodeDom.Compiler;
using System.Text;
using Microsoft.CSharp;

namespace Euh.Crm.Core
{
    public class EntityClassBuilder
    {
        public static Type BuildEntityClass(Entity entity)
        {
            var classCode = new StringBuilder();
            classCode.AppendFormat("public class {0} {{ ", entity.Name);
            foreach (Field field in entity.Fields)
            {
                classCode.AppendFormat("public {0} {1} {{ get; set; }}", field.BaseType, field.Name);
            }
            classCode.Append("}");

            CompilerResults result = CompileScript(classCode.ToString());
            return result.CompiledAssembly.GetType();
        }

        private static CompilerResults CompileScript(string source)
        {
            var compilerParameters = new CompilerParameters
                                         {
                                             GenerateExecutable = false,
                                             GenerateInMemory = true,
                                             IncludeDebugInformation = true
                                         };

            var compiler = CSharpCodeProvider.CreateProvider("CSharp");
            return compiler.CompileAssemblyFromSource(compilerParameters, source);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace emapper.net;

[Generator]
public class CodeGenerator : ISourceGenerator
{
    private const string MAPPER_ATTRIBUTE_NAME = "emapper.net.MapperAttribute";

    private static MapperDescriptor CreateMapperDescriptor(SemanticModel semanticModel, InterfaceDeclarationSyntax intf, AttributeSyntax attribute)
    {
        var args = attribute.ArgumentList!.Arguments.ToImmutableList();

        // source type is arg 0 and target type is arg 1
        var sourceTypeOfExpression = (TypeOfExpressionSyntax)args[0].Expression;
        var sourceType = semanticModel.GetTypeInfo(sourceTypeOfExpression.Type);

        var targetTypeOfExpression = (TypeOfExpressionSyntax)args[1].Expression;
        var targetType = semanticModel.GetTypeInfo(targetTypeOfExpression.Type);

        return new MapperDescriptor(semanticModel.GetDeclaredSymbol(intf)!, sourceType, targetType);
    }

    private static List<MapperDescriptor> FindMappers(GeneratorExecutionContext context)
    {
        var compilation = context.Compilation;
        var attributeSymbol = compilation.GetTypeByMetadataName(MAPPER_ATTRIBUTE_NAME)!;

        var allClasses = compilation.SyntaxTrees
            .SelectMany(syntaxTree => syntaxTree.GetRoot().DescendantNodes())
                .Where(x => x is ClassDeclarationSyntax)
                .Cast<ClassDeclarationSyntax>()
                .ToImmutableList();

        var allInterfaces = compilation.SyntaxTrees
            .SelectMany(syntaxTree => syntaxTree.GetRoot().DescendantNodes())
                .Where(x => x is InterfaceDeclarationSyntax)
                .Cast<InterfaceDeclarationSyntax>()
                .ToImmutableList();

        var interfacesWithAttributes = allInterfaces
            .Where(p => p.DescendantNodes().OfType<AttributeSyntax>().Any())
            .ToImmutableList();

        var result = new List<MapperDescriptor>();
        foreach (InterfaceDeclarationSyntax interfaceDeclaration in interfacesWithAttributes)
        {
            var semanticModel = compilation.GetSemanticModel(interfaceDeclaration.SyntaxTree);
            if (semanticModel == null) continue;

            foreach (var attributeList in interfaceDeclaration.AttributeLists)
            {
                foreach (var attribute in attributeList.Attributes)
                {
                    if (semanticModel.GetTypeInfo(attribute).Type!.Name != attributeSymbol.Name) continue;
                    result.Add(CreateMapperDescriptor(semanticModel, interfaceDeclaration, attribute));
                }
            }
        }
        return result;
    }

    public void Execute(GeneratorExecutionContext context)
    {
        var mappers = FindMappers(context);
    }

    public void Initialize(GeneratorInitializationContext context)
    {
        throw new NotImplementedException();
    }
}
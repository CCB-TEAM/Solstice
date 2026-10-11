// Concept sketch only — not yet wired to UAssetAPI.
// This models high-level intent. A separate compiler must translate it into
// actual expression objects using APIs verified for the selected UAssetAPI version.

namespace Solstice.Snippets;

public sealed record FunctionDescription(
    string FunctionName,
    FunctionSignature Signature,
    IReadOnlyList<LocalVariableDeclaration> Locals,
    IReadOnlyList<Statement> Statements);

public sealed record FunctionSignature(
    string OwnerType,
    IReadOnlyList<ParameterSignature> Parameters,
    string? ReturnType);

public sealed record ParameterSignature(string Name, string TypeName);

public sealed record LocalVariableDeclaration(string Name, string TypeName);

public abstract record Statement;

public sealed record CallStatement(
    FunctionReference Function,
    IReadOnlyList<Argument> Arguments) : Statement;

public sealed record IfStatement(
    Argument Condition,
    IReadOnlyList<Statement> Then,
    IReadOnlyList<Statement> Else) : Statement;

public sealed record ReturnStatement(Argument? Value) : Statement;

public abstract record Argument;

public sealed record ConstantArgument(object? Value) : Argument;

public sealed record LocalVariableArgument(string Name) : Argument;

public sealed record CallArgument(
    FunctionReference Function,
    IReadOnlyList<Argument> Arguments) : Argument;

public sealed record FunctionReference(
    string PackagePath,
    string OwnerType,
    string FunctionName,
    string? SignatureFingerprint = null);

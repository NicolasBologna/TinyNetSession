# MSBuild

The Microsoft Build Engine is a platform for building applications. This engine, also known as MSBuild, provides an XML schema for a project file that controls how the build platform processes and builds software. Visual Studio uses MSBuild, but MSBuild can run without Visual Studio. By invoking msbuild.exe on your project or solution file, you can orchestrate and build products in environments where Visual Studio isn't installed.

MSBuild 15 introduced a pretty cool feature: implicit imports (I don’t know if it’s the official name, but I’ll use it anyway). Basically, you can create a file named Directory.Build.props anywhere in your repo, and it will be automatically imported by any project under the directory containing this file. This makes it very easy to share common properties and items across projects.

## Directory.Build.props

Es un archivo XML que va a aplicar ciertas configuraciones al build de manera global. No hace falta especificar nada, poniendo solo ese nombre MSBuild lo va a tomar por defecto para esa carpeta y todas sus dependientes.

For instance, if you want to share some metadata across multiple projects, just write a

```XML
    <Project>
        <PropertyGroup>
            <Version>1.2.3</Version>
            <Authors>John Doe</Authors>
        </PropertyGroup>
    </Project>
```

### MyRules

    MyRules.ruleset
    <Rule Id="CA1802" Action="Error" />

    <PropertyGroup>
    	<CodeAnalysisRuleset>$(MSBuildThisFileDirectory)MyRules.ruleset</CodeAnalysisRuleset>
    </PropertyGroup>

    Con eso si creamos la clase

    public static class ExampleClass {
        static readonly string hola = "hola";
    }
    no nos va a dejar compilar

### stlecop.json

    dotnet format --severity error
    dotnet format --severity info

# Links

<https://github.com/DotNetAnalyzers/StyleCopAnalyzers/tree/master/StyleCop.Analyzers>

<https://roundwide.com/dotnet-format-and-stylecop-analyzers/>

<https://learn.microsoft.com/en-us/visualstudio/msbuild/msbuild-reserved-and-well-known-properties?view=vs-2022>

<https://garywoodfine.com/what-is-this-directory-build-props-file-all-about/>

[Repo Donde usa esto](https://github.com/FakeItEasy/FakeItEasy/blob/master/Directory.Build.props)

[Como usarlo con dependabot](https://dev.to/askpt/directorybuildprops-and-dependabot-behaviour-4cb3)

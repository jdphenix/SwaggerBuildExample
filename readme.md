# Swagger example - Generating new client at build time

This repo serves as an example of generating a new client for a Web API 
at build time of the service. WebApplication1 is the service and W
WebApplication2 is the consumer. 

In WebApplication1.csproj, this configuration creates a new Swagger spec
after each build. 

    <Target Name="PostBuild" AfterTargets="PostBuildEvent">
        <Exec Command="swagger tofile --output ..\specs\WebApplication1.swagger.json .\bin\$(Configuration)\net6.0\WebApplication1.dll v1" />
    </Target>

    <Target Name="PreBuild" BeforeTargets="PreBuildEvent">
        <Exec Command="del ..\specs\WebApplication1.swagger.json" />
    </Target>

In WebApplication2.csproj, a reference to the Swagger spec exists as normal. 

    <ItemGroup>
        <OpenApiReference Include="..\specs\WebApplication1.swagger.json" Namespace="WebApplication2" ClassName="WebApplication1Client">
            <CodeGenerator>NSwagCSharp</CodeGenerator>
        </OpenApiReference>
    </ItemGroup>

# How to run 
To run this example, clone the repo locally and run both projects at once. No 
external dependencies exist. 
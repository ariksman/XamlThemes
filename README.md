# XamlThemes
[![Build status](https://ci.appveyor.com/api/projects/status/393mxd1q08wie4ds/branch/master?svg=true)](https://ci.appveyor.com/project/ariksman/xamlthemes/branch/master)
[![CodeFactor](https://www.codefactor.io/repository/github/ariksman/xamlthemes/badge)](https://www.codefactor.io/repository/github/ariksman/xamlthemes)

Solution demonstrates how to create reusable WPF style libraries which can be easily used in other projects as a dll or direct reference.

## Third party libraries

- Font Awesome [https://fontawesome.com]
- Microsoft Xaml Behaviors [https://www.nuget.org/packages/Microsoft.Xaml.Behaviors.Wpf]

## How to use xaml vector graphics - SVG to XAML 

Steps to use vector graphics within xaml:
* Find the desired image in .svg fileformat
* Open svg-file in raw format and copy width, height and data into the below xaml syntax.

```xaml
<ControlTemplate x:Key="Icon_Theme" TargetType="{x:Type gui:XamlImage}">
        <Viewbox>
            <Canvas
                Width="32"
                Height="32"
                SnapsToDevicePixels="False"
                UseLayoutRounding="False">
                <Path
                    Data="M16,6A10,10,0,1,0,26,16,10,10,0,0,0,16,6Zm0,18H14v-.25a8,8,0,0,1,0-15.5V8h2Z"
                    Fill="{TemplateBinding Foreground}" />
            </Canvas>
        </Viewbox>
    </ControlTemplate>
```
* If needed, the image created by the path can be oriented differently

```xaml
<Canvas>
    <Canvas.LayoutTransform>
        <ScaleTransform ScaleX="1" ScaleY="-1" CenterX=".5" CenterY=".5" />
    </Canvas.LayoutTransform>
</Canvas>
```
    
## How to use use code-behind on a resource dictionary
Resource dictionary can also have a code-behind file. To create the code-behind file in visual studio, lets assume we have an existing ```CustomWindowStyle.xaml``` resource dictionary. 
* Next step is to create a normal class within the same namespace named: ```CustomWindowStyle.xaml.cs```
* After the class has been created, it needs some modification. The class needs to extend ```ResourceDictionary```, be declared as ```partial``` and call ```ÌnitializeComponent()``` in its constructor. After these edits, the class should be in the following format:
```csharp
namespace ReusableTheme.UI.WPF.Themes.Styles
{
  public partial class CustomWindow : ResourceDictionary
  {
    public CustomWindow()
    {
      InitializeComponent();
    }
```
* Additionally, the resource dictionary also needs to be aware that it has a code-behind class. This can be achieved by defining the ```x:Class``` for the resource dictionary. Definition is in following format ```class namespace```.```class name```:
```xaml
<ResourceDictionary
    x:Class="ReusableTheme.UI.WPF.Themes.Styles.CustomWindow"
```

## Nuget package
This theme project can be distributed as a nuget package. To create a nuget package, first download ```nuget.exe``` and for convenience add it to the environment path. After these steps, run command: ```nuget spec``` on the command promt in the project folder. This will create the ```project.nuspec``` file. Finally, by adding the following post-build event, the nuget package will be created on release builds and copied into the given folder path.  
```
if $(ConfigurationName) == Release (
    nuget pack "$(ProjectPath)" -Properties Configuration=Release
    xcopy "$(TargetDir)*.nupkg" "C:\NuGet" /C /Y
)
```

## Sources

Original idea from a Pluralsight course _Advanced reusable styles and themes in WPF_ [https://app.pluralsight.com/library/courses/wpf-advanced-reusable-styles-themes/table-of-contents]

#

*If debugging is the process of removing software bugs, then programming must be the process of putting them in.*

# XamlThemes

Solution demonstrates how to create reusable WPF style libraries which can be easily used in other projects as a dll or direct reference.

## Frameworks

- Font Awesome [https://fontawesome.com]

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
* The resource dictionary also needs to be aware that it has code-behind class and this can be achieved by defining the ```x:Class```. Definition is in following format ```class namespace```.```class name```:
```xaml
<ResourceDictionary
    x:Class="ReusableTheme.UI.WPF.Themes.Styles.CustomWindow"
```

## Sources

Original idea from a Pluralsight course _Advanced reusable styles and themes in WPF_ [https://app.pluralsight.com/library/courses/wpf-advanced-reusable-styles-themes/table-of-contents]

#

*If debugging is the process of removing software bugs, then programming must be the process of putting them in.*

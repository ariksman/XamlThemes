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
    
## Sources

Original idea from a Pluralsight course _Advanced reusable styles and themes in WPF_ [https://app.pluralsight.com/library/courses/wpf-advanced-reusable-styles-themes/table-of-contents]

#

*If debugging is the process of removing software bugs, then programming must be the process of putting them in.*

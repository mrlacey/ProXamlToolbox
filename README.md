# Pro XAML Toolbox

It's like the standard Visual Studio Toolbox but **much** better.

![Screenshot showing the Pro XAML Toolbox in light and dark themes](.//art/screenshot-darkandlight.png)

**Currently supporting .NET MAUI**. _[WPF](https://github.com/mrlacey/ProXamlToolbox/issues/2), & [WinUI](https://github.com/mrlacey/ProXamlToolbox/issues/1) support coming soon - maybe._

:alembic: A [Rapid XAML Toolkit](https://github.com/mrlacey/rapid-xaml-toolkit) experiment. If/when this ships beyond an experiment/preview, it will be moved to that project and repository.

---

## What?

A Visual Studio extension that adds a new tool window.

It's a cross between Visual Studio's Toolbox and the ability to use smart snippets.

There are 2 ways of using it:

You can **drag items onto the editor** and get a much richer snippet.

**Or**, you can **double-click on an item**, and it will be added in the editor where the cursor is positioned.  
**But** if you add an element that is (or can be) a container for other elements, the cursor is moved inside the added element.  
This means that if you want two `Button`s inside a `Grid` you can double-click the `Grid` item and then double-click the `Button` item twice and you'll get all this:

```xml
<Grid
    x:Name="Grid9870"
    ColumnDefinitions="*,*"
    RowDefinitions="Auto,Auto,*">
    <Button
        x:Name="Button7240"
        Command="{Binding CommandName}"
        SemanticProperties.Hint="Add a description of what happens when clicked"
        Text="click me" />
    <Button
        x:Name="Button4139"
        Command="{Binding CommandName}"
        SemanticProperties.Hint="Add a description of what happens when clicked"
        Text="click me" />

</Grid>
```

Not bad for **only 3 [double-]clicks**. Just imagine how many keystrokes that saves you!

### It doesn't (& cant) do everything

Look at the above code and you'll see that it's not 100% how you'd want in your code. This is intentional. It doesn't know what name you might want to give your `Grid` or what the `Text` or `Hint` should be on each `Button`.

However, it's easier to change placeholder values than to have to write everything from scratch. It's also easier for people who don't know what properties are available (or should be set).

### It's configurable!

Yes, you can choose between common preferences for coding style and requirements.

Options:

- Include an `x:Name` attribute for each added element.
- Prefer the use of **Events** or **Commnads**.
- Include common accessibility-related properties.

### Only does what's necessary

The XAML it adds to the file isn't ideally formatted. This is by design.

There are other tools ([XAML Styler](https://marketplace.visualstudio.com/items?itemName=TeamXavalon.XAMLStyler) is recommended) that can format your code how you want it. Recreating this functionality wouldn't be a good use of my time. Just like it isn't a good use of your time to type all of your XAML.

## Why?

Because you should have better uses for your time than typing all your XAML!

## Feedback wanted

This extension is being released as a preview. Please [open issues](https://github.com/mrlacey/ProXamlToolbox/issues) with comments, feedback, suggestions, etc.

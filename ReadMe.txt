Go create your DB tables, ensure you copy the database brief.
Connrect your FK's
Enter 2 lines of data for each table

From Nuget:
Install Material Design (Themes - 4.25 Million) into the solution
* Also note that it should also add the colours

Install Entity Framework nto the solution
https://learn.microsoft.com/en-us/ef/efcore-and-ef6/

In app.xaml add resources dictionaries
<ResourceDictionary>
      <ResourceDictionary.MergedDictionaries>
        <ResourceDictionary Source="pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml" />
        <ResourceDictionary Source="pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml" />
        <ResourceDictionary Source="pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.DeepPurple.xaml" />
        <ResourceDictionary Source="pack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Lime.xaml" />
      </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>

Update any window/frame/view that wants to use Material Design content,
with the following NS

xmlns:materialDesign="http://materialdesigninxaml.net/winfx/xaml/themes"

WPF differs from web method for sdetting start page
For WPF, we specify a start page in app.xaml

    StartupUri="MainWindow.xaml">

Add folders for images

If you want to add a custom font, it is the same process as how we added images.
In the main window.xaml, lets start to configure the main window. We do this at the top size of the windows, start location, its width, its  heught and if it is resizable.

Open up the exe example for material desaign, and we are going to grab a nav rail

Add a new foldewr and clal it MainViews - MVVM

Add a new window, call it LoadingScreen

Add a new page, call it DemoPage

Develop the front end for the Loading Screen
Develop the back end for the Loading Screen

The new login window will not be found, so go ahead and add Login.xaml

Code the front end for the login
Code the back end for the login
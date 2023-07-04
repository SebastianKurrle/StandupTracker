namespace StandupTracker.Menu;

public class MenuItem
{
    public string Name { get; set; }
    public string PanelName { get; set; } // unique value to change to view

    public MenuItem(string name, string panelName)
    {
        Name = name;
        PanelName = panelName;
    }
}

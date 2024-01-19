class Module{

    public Module(){
        ModuleContent = new List<ContentItem>(){};
    }
    public string? ModuleName
    {
        get;
        set;
    } 
    public string? ModuleDesc{
        get;
        set;
    }
    // Module Content List
    private List<ContentItem> ModuleContent;
}
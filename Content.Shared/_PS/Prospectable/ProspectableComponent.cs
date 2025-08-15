namespace Content.Shared._PS.Prospectable;

[RegisterComponent]
public sealed partial class ProspectableComponent : Component
{
    [DataField, ViewVariables]
    public int Level = 1;
}

namespace Content.Server._PS.Prospectable;

[ByRefEvent]
public record struct RandomItemSpawnedEvent
{
    public EntityUid EntityUid;

    public RandomItemSpawnedEvent(EntityUid entity)
    {
        EntityUid = entity;
    }
}

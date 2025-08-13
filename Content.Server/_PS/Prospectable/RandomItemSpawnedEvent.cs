namespace Content.Server._PS.Prospectable;

[ByRefEvent]
public record struct RandomItemSpawnedEvent(EntityUid entity)
{
    public EntityUid EntityUid = entity;
}

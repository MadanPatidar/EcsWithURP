using Unity.Entities;
public class LevelSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref LevelComponent levelComponent) => {
            levelComponent.LevenNumber += 1f * Time.DeltaTime;
        });
    }
}
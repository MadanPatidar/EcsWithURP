using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
public class MoveSystem : ComponentSystem
{
    protected override void OnUpdate()
    {        
        Entities.ForEach((ref Translation translation, ref MoveSpeedComponent moveSpeedComponent) => {
            translation.Value.y += Time.DeltaTime * moveSpeedComponent.moveSpeed;

            if (translation.Value.y > 12)
            {
                moveSpeedComponent.moveSpeed = -math.abs(moveSpeedComponent.moveSpeed);
            }
            else if (translation.Value.y < -12)
            {
                moveSpeedComponent.moveSpeed = +math.abs(moveSpeedComponent.moveSpeed);
            }
        });        
    }
}
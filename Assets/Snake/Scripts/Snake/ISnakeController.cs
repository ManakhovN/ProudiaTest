public interface ISnakeController
{
    IBody Body { get; }
    IWayProcessor WayProcessor { get; }
    ICollisionChecker[] CollisionCheckers { get; }
    bool Pause { get; set; }
}
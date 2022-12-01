using Components.Interfaces;

namespace Controllers.Interfaces
{
    public interface ICollisionObserver
    {
        public void AttachObject(ITriggerTwoColliderEventsComponent collisionTrigger);

        public void DeAttachObject(ITriggerTwoColliderEventsComponent collisionTrigger);

    }
}
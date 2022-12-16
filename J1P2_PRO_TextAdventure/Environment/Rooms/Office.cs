namespace J1P2_PRO_TextAdventure.Environment.Rooms
{
    internal class Office : Room
    {
        public readonly int locks;
        private int unlockedLocks;
        private bool locked;

        public Office(int _locks, int _unlockedLocks = 0)
        {
            if (_unlockedLocks > _locks)
                throw new ArgumentException("the amount of unlocked locks cannot be more than the amount of locks");

            locks = _locks;
            unlockedLocks = _unlockedLocks;
            locked = true;
        }

        public void UnlockLock()
        {
            if (unlockedLocks >= locks)
                throw new Exception("The door is already unlocked");

            unlockedLocks++;

            if (unlockedLocks == locks)
            {
                locked = false;
            }
        }

        public override void Enter(Guid _playerEntityGuid)
        {
            //starts boss battle
        }

        public override bool IsLocked
        {
            get { return locked; }
        }
    }
}

namespace RPG_Game.Characters
{
    #region

    using RPG_Game.Interfaces;

    #endregion

    internal struct GameObject : IGameObject
    {
        public GameObject(int x, int y)
            : this()
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }
    }
}
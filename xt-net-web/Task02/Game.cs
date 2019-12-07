using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class Game
    {
        public void Play()
        {
        }

        protected void Display()
        {
        }
    }

    interface ILocatable
    {
        float X
        {
            get;
        }

        float Y
        {
            get;
        }
    }

    interface IPrintable
    {
        string Name
        {
            get;
        }
    }

    abstract class Entity : ILocatable, IPrintable
    {
        protected Entity(float x, float y)
        {
            X = x;
            Y = y;
        }

        public float X
        {
            get;
            protected set;
        }

        public float Y
        {
            get;
            protected set;
        }

        public string Name => "Entity";
    }

    class Player : Entity
    {
        public Player(float x, float y)
            : base(x, y)
        {
        }

        public int Lives
        {
            get; private set;
        }

        public void Move()
        {
        }
    }

    class Field
    {
        public Field(float width, float height)
        {
            Width = width;
            Height = height;
        }

        public float Width
        {
            get;
            private set;
        }

        public float Height
        {
            get;
            private set;
        }

        public Player player
        {
            get; private set;
        }

        public List<Monster> monsters
        {
            get; private set;
        }

        public List<Obstacle> obstacles
        {
            get; private set;
        }
    }

    abstract class Bonus : Entity
    {
        protected Bonus(float x, float y)
            : base(x, y)
        {
        }

        public abstract void Affect(Player player);

        public new string Name => "Bonus";
    }

    class Cherry : Bonus
    {
        protected Cherry(float x, float y)
            : base(x, y)
        {
        }

        public override void Affect(Player player)
        {
        }

        public new string Name => "Cherry";
    }

    abstract class Monster : Entity
    {
        protected Monster(float x, float y)
            : base(x, y)
        {
        }

        public abstract void Move();

        public new string Name => "Monster";
    }

    abstract class Obstacle : Entity
    {
        protected Obstacle(float x, float y)
            : base(x, y)
        {
        }

        public new string Name => "Obstacle";
    }
}

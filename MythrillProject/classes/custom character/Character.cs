using MythrillProject.interfaces;

namespace MythrillProject.classes.custom_character
{
    public class Character : ICharacter
    {
        #region Protected Attributes

        protected string _name;
        protected int _health;
        protected int _maxHealth;
        protected int _speed;
        protected int _level;
        protected int _exp;
        protected int _maxExp;
        protected int _strength;
        protected int _intelligence;
        protected int _wisdom;
        protected int _dexterity;
        protected int _constitution;
        protected int _charisma;

         #endregion

        #region Public Properties

        public string Name {
            get {
                return _name;
            }
            set {
                _name = value;
            }
        }

        public int Health {
            get {
                return _health;
            }
            set {
                _health = value;
            }
        }

        public int MaxHealth {
            get {
                return _maxHealth;
            }
            set {
                _maxHealth = value;
            }
        }

        public int Speed {
            get {
                return _speed;
            }
            set {
                _speed = value;
            }
        }

        public int Level {
            get {
                return _level;
            }
            set {
                _level = value;
            }
        }

        public int Exp {
            get {
                return _exp;
            }
            set {
                _exp = value;
            }
        }

        public int MaxExp {
            get {
                return _maxExp;
            }
            set {
                _maxExp = value;
            }
        }

        public int Strength {
            get {
                return _strength;
            }
            set {
                _strength = value;
            }
        }

        public int Intelligence {
            get {
                return _intelligence;
            }
            set {
                _intelligence = value;
            }
        }

        public int Wisdom {
            get {
                return _wisdom;
            }
            set {
                _wisdom = value;
            }
        }

        public int Dexterity {
            get {
                return _dexterity;
            }
            set {
                _dexterity = value;
            }
        }

        public int Constitution {
            get {
                return _constitution;
            }
            set {
                _constitution = value;
            }
        }

        public int Charisma {
            get {
                return _charisma;
            }
            set {
                _charisma = value;
            }
        }

        #endregion
    }
}
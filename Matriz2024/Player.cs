using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matriz2024
{
    internal class Player
    {
        //Atributos
        private string _name;
        private int _score;
        private TimeSpan _gameTime;

        public Player(string name) { 
            Name = name;
            Score = 0;
            GameTime = TimeSpan.FromSeconds(0);
        }

        public string Name
        {
            get { return _name; }
            set { 
                if(!string.IsNullOrEmpty(value))
                    _name = value; 
            }
        }

        public int Score
        {
            get { return _score; }
            set
            {
                if (value >= 0)
                    _score += value;
            }
        }

        public TimeSpan GameTime
        {
            get { return _gameTime; }
            set
            {
                _gameTime += value;
            }
        }

        public override string ToString()
        {
            return "Nome: " + Name +
            "\nPontuação: " + Score +
            $"\nTempo de Partida: {GameTime:hh\\:mm\\:ss}" ;
        }
    }
}

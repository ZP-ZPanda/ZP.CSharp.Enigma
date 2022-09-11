﻿using System;
using System.Linq;
using ZP.CSharp.Enigma;
namespace ZP.CSharp.Enigma
{
    public class Enigma
    {
        public Rotor[] _Rotors;
        public Rotor[] Rotors {get => this._Rotors; set => this._Rotors = value;}
        public Reflector _Reflector;
        public Reflector Reflector {get => this._Reflector; set => this._Reflector = value;}
        public Enigma(Reflector reflector, params Rotor[] rotors)
        {
            this.Rotors = rotors;
            this.Reflector = reflector;
        }

        public virtual char RunOn(char c)
        {
            var input = c;
            this.Rotors.ToList().ForEach(rotor => input = rotor.FromEntryWheel(input));
            input = this.Reflector.Reflect(input);
            this.Rotors.Reverse().ToList().ForEach(rotor => input = rotor.FromReflector(input));
            return input;
        }
    }
}
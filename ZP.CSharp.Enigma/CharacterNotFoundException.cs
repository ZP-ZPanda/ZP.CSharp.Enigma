using System;
using System.Runtime.Serialization;
using ZP.CSharp.Enigma;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>Represents the situation where no character could be found.</summary>
    <seealso cref="IRotor{TRotor, TRotorPair}.FromEntryWheel(char)" />
    <seealso cref="IRotor{TRotor, TRotorPair}.FromReflector(char)" />
    */
    [Serializable]
    public class CharacterNotFoundException : Exception
    {
        /**
        <summary>The error message.</summary>
        */
        public const string ErrorMessage = "Character not found.";
        /**
        <seealso cref="Exception.Exception(string)" />
        */
        public CharacterNotFoundException() : base(ErrorMessage)
        {}
        /**
        <seealso cref="Exception.Exception(string, Exception)" />
        */
        public CharacterNotFoundException(Exception inner) : base(ErrorMessage, inner)
        {}
        /**
        <seealso cref="Exception.Exception(SerializationInfo, StreamingContext)" />
        */
        protected CharacterNotFoundException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {}
    }
}
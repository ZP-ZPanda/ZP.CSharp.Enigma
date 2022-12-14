using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using ZP.CSharp.Enigma.Implementations;
using ZP.CSharp.Enigma.Helpers;
namespace ZP.CSharp.Enigma.Implementations
{
    /**
    <summary>The reflector.</summary>
    */
    public class AlphabeticalReflector : IReflector<AlphabeticalReflector, AlphabeticalReflectorPair>
    {
        private AlphabeticalReflectorPair[] _Pairs = Array.Empty<AlphabeticalReflectorPair>();
        /**
        <summary>The reflector pairs this reflector has.</summary>
        */
        public required AlphabeticalReflectorPair[] Pairs {get => this._Pairs; set => this._Pairs = value;}
        /**
        <inheritdoc cref="AlphabeticalReflector.New(AlphabeticalReflectorPair[])" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        protected AlphabeticalReflector(params AlphabeticalReflectorPair[] pairs)
        #pragma warning restore CS8618
        {
            ArgumentNullException.ThrowIfNull(pairs);
            pairs.ToList().ForEach(pair => ArgumentNullException.ThrowIfNull(pair));
            this.Setup(pairs);
        }
        /**
        <inheritdoc cref="IReflector{TReflector, TReflectorPair}.New(TReflectorPair[])" />
        */
        public static AlphabeticalReflector New(params AlphabeticalReflectorPair[] pairs) => new(pairs);
        /**
        <inheritdoc cref="Reflector.New(string[])" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        protected AlphabeticalReflector(params string[] maps)
        #pragma warning restore CS8618
        {
            ArgumentNullException.ThrowIfNull(maps);
            maps.ToList().ForEach(map => ArgumentException.ThrowIfNullOrEmpty(map));
            this.Setup(ReflectorPairHelpers.GetPairsFrom<AlphabeticalReflectorPair>(maps));
        }
        /**
        <summary>Creates a reflector with reflector pairs created from two-character-long mappings.</summary>
        <param name="maps">The reflector pair mappings.</param>
        */
        public static AlphabeticalReflector New(params string[] maps) => new(maps);
        /**
        <inheritdoc cref="AlphabeticalReflector.New(string)" />
        */
        [SetsRequiredMembers]
        #pragma warning disable CS8618
        protected AlphabeticalReflector(string map)
        #pragma warning restore CS8618
        {
            ArgumentException.ThrowIfNullOrEmpty(map);
            this.Setup(ReflectorPairHelpers.GetPairsFrom<AlphabeticalReflectorPair>(map));
        }
        /**
        <summary>Creates a reflector with reflector pairs created from a mapping.</summary>
        <param name="map">The mapping.</param>
        */
        public static AlphabeticalReflector New(string map) => new(map);
    }
}
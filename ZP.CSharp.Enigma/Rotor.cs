using System;
using ZP.CSharp.Enigma;
namespace ZP.CSharp.Enigma
{
    /**
    <summary>The rotor.</summary>
    */
    public class Rotor
    {
        /**
        <summary>The rotor pairs this rotor has.</summary>
        */
        public RotorPair[] Pairs;
        /**
        <summary>Creates a rotor with zero rotor pairs.</summary>
        */
        public Rotor()
        {
            this.Pairs = new RotorPair[0];
        }
        /**
        <summary>Creates a rotor with the rotor pairs provided.</summary>
        <param name="pairs">The rotor pairs.</param>
        */
        public Rotor(params RotorPair[] pairs)
        {
            this.Pairs = pairs;
        }
        /**
        <summary>Creates a rotor with rotor pairs created from two-character-long mappings.</summary>
        <param name="maps">The rotor pair mappings.</param>
        */
        public Rotor(params string[] maps)
        {
            if (!maps.All(map => map.Length == 2))
            {
                throw new ArgumentException("Mappings are not two characters long. Expected mappings: \"{EntryWheelSide}{ReflectorSide}\"");
            }
            var pairs = new List<RotorPair>();
            maps.ToList().ForEach(map => pairs.Add(new RotorPair(map)));
            this.Pairs = pairs.ToArray();
        }
        /**
        <summary>Creates a rotor with rotor pairs created from a Entrywheel-side and a reflector-side mapping.</summary>
        <param name="e">The Entrywheel-side mapping.</param>
        <param name="r">The reflector-side mapping.</param>
        */
        public Rotor(string e, string r)
        {
            if (e.Length != r.Length)
            {
                throw new ArgumentException("Mappings are not of same length. Expected mappings: \"{EntryWheelSide}\", \"{ReflectorSide}\"");
            }
            var pairs = new List<RotorPair>();
            for (int i = 0; i < e.Length; i++)
            {
                pairs.Add(new RotorPair(e[i], r[i]));
            }
            this.Pairs = pairs.ToArray();
        }
    }
}
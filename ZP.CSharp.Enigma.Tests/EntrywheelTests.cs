using System;
using Xunit;
using System.Linq;
using ZP.CSharp.Enigma;
using ZP.CSharp.Enigma.Helpers;
using ZP.CSharp.Enigma.Tests;
namespace ZP.CSharp.Enigma.Tests
{
    public class EntrywheelTests
    {
        [Fact]
        public void EntrywheelPairsCanBeAddedToEntrywheel()
        {
            var pair1 = EntrywheelPair.New('a', 'z');
            var pair2 = EntrywheelPair.New('z', 'a');
            var entrywheel = Entrywheel.New(pair1, pair2);
            Assert.Contains(pair1, entrywheel.Pairs);
            Assert.Contains(pair2, entrywheel.Pairs);
        }
        [Theory]
        [InlineData("abcd", "cdab", new char[]{'a', 'b', 'c', 'd'}, new char[]{'c', 'd', 'a', 'b'})]
        [InlineData("你我他大熊貓", "大熊貓你我他", new char[]{'你', '我', '他', '大', '熊', '貓'}, new char[]{'大', '熊', '貓', '你', '我', '他'})]
        public void EntrywheelPairsCanBeMassConstructedFromTwoMappings(string p, string r, char[] pChars, char[] rChars)
        {
            var entrywheel = Entrywheel.New(p, r);
            var i = 0;
            Assert.All(entrywheel.Pairs, pair => {
                Assert.Equal(pair, EntrywheelPair.New(pChars[i], rChars[i]));
                i++;
            });
        }
        [Theory]
        [InlineData(new char[]{'a', 'b', 'c', 'd'}, new char[]{'c', 'd', 'a', 'b'}, "ac", "bd", "ca", "db")]
        [InlineData(new char[]{'你', '我', '他', '大', '熊', '貓'}, new char[]{'大', '熊', '貓', '你', '我', '他'}, "你大", "我熊", "他貓", "大你", "熊我", "貓他")]
        public void EntrywheelPairsCanBeMassConstructedFromTwoCharLongMappings(char[] pChars, char[] rChars, params string[] maps)
        {
            var entrywheel = Entrywheel.New(maps);
            var i = 0;
            Assert.All(entrywheel.Pairs, pair => {
                Assert.Equal(pair, EntrywheelPair.New(pChars[i], rChars[i]));
                i++;
            });
        }
        [Theory]
        [InlineData(true, true, new[]{"aa", "bb", "cc"})]
        [InlineData(false, true, new[]{"abc", "abc"})]
        [InlineData(true, true, new[]{"ac", "bb", "ca"})]
        [InlineData(false, true, new[]{"abc", "cba"})]
        [InlineData(true, true, new[]{"ab", "bc", "ca"})]
        [InlineData(false, true, new[]{"abc", "bca"})]
        [InlineData(true, false, new[]{"aa", "ba", "cc"})]
        [InlineData(false, false, new[]{"abc", "aac"})]
        [InlineData(true, false, new[]{"aa", "ab", "cc"})]
        [InlineData(false, false, new[]{"aac", "abc"})]
        [InlineData(true, false, new[]{"aa", "ab", "cc", "dc"})]
        [InlineData(false, false, new[]{"aacd", "abcc"})]
        public void EntrywheelCanBeValidated(bool twoStrings, bool isValid, string[] maps)
        {
            var action = () => {var entrywheel = twoStrings ? Entrywheel.New(maps) : Entrywheel.New(maps[0], maps[1]);};
            if (isValid)
            {
                action();
            }
            else
            {
                var ex = Record.Exception(action);
                Assert.IsType<ArgumentException>(ex);
            }
        }
        [Theory]
        [InlineData("abcde", "bcdea", 'c', 'd')]
        [InlineData("abcde", "bcdea", 'f', null)]
        [InlineData("大熊貓可愛", "可愛熊貓大", '貓', '熊')]
        [InlineData("大熊貓可愛", "可愛熊貓大", '人', null)]
        public void EntrywheelCanPassCharacterFromPlugboard(string p, string r, char input, char? expected)
        {
            var action = () => Assert.Equal(expected, Entrywheel.New(p, r).FromPlugboard(input));
            if (expected is not null)
            {
                action();
            }
            else
            {
                var ex = Record.Exception(action);
                Assert.IsType<CharacterNotFoundException>(ex);
            }
        }
        [Theory]
        [InlineData("bcdea", "abcde", 'c', 'd')]
        [InlineData("bcdea", "abcde", 'f', null)]
        [InlineData("可愛熊貓大", "大熊貓可愛", '貓', '熊')]
        [InlineData("可愛熊貓大", "大熊貓可愛", '人', null)]
        public void EntrywheelCanPassCharacterFromReflector(string p, string r, char input, char? expected)
        {
            var action = () => Assert.Equal(expected, Entrywheel.New(p, r).FromReflector(input));
            if (expected is not null)
            {
                action();
            }
            else
            {
                var ex = Record.Exception(action);
                Assert.IsType<CharacterNotFoundException>(ex);
            }
        }
    }
}
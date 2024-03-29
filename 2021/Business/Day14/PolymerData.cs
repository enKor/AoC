﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Day14
{
    public class PolymerData : IData
    {
        public PolymerData()
        {
            Source = TestData;
        }

        public string Source { get; set; }

        public string GetFormula() =>
            Source
                .Split("\r\n", StringSplitOptions.RemoveEmptyEntries)
                .First();

        public IDictionary<string,string> GetDictionary() =>
            Source
                .Split("\r\n", StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .Select(a => a.Split(" -> ", StringSplitOptions.RemoveEmptyEntries))
                .ToDictionary(k => k[0], v => v[1]);

        private const string TestData = @"NNCB

CH -> B
HH -> N
CB -> H
NH -> C
HB -> C
HC -> B
HN -> C
NN -> C
BH -> H
NC -> B
NB -> B
BN -> B
BB -> N
BC -> B
CC -> N
CN -> C";

        private const string SampleData = @"HHKONSOSONSVOFCSCNBC

OO -> N
VK -> B
KS -> N
PK -> H
FB -> H
BF -> S
BB -> V
KO -> N
SP -> K
HK -> O
PV -> K
BP -> O
VO -> V
OP -> C
BS -> V
OK -> V
KN -> H
KC -> N
PP -> F
NB -> V
CH -> V
HO -> K
PN -> H
SS -> O
CK -> P
VV -> K
FN -> O
BH -> B
SC -> B
HH -> P
FO -> O
CC -> H
OS -> H
FP -> S
HC -> F
BO -> F
CF -> S
NC -> S
HS -> V
KF -> O
ON -> C
CN -> K
VF -> F
NO -> K
CP -> N
HF -> K
CV -> N
HN -> K
VH -> B
KK -> P
CS -> O
VS -> P
NH -> F
CB -> S
BV -> P
FK -> F
NV -> O
OV -> K
SB -> N
NF -> O
VN -> S
OH -> O
PS -> N
HB -> H
SV -> V
CO -> H
SO -> P
FV -> N
PF -> O
NN -> S
KB -> P
NP -> F
OC -> S
FS -> P
FH -> P
VP -> K
BN -> O
NS -> H
VB -> V
PO -> K
KP -> N
SN -> O
BC -> H
SF -> V
PC -> O
NK -> F
BK -> V
KH -> S
SH -> S
SK -> H
OB -> V
PH -> N
PB -> C
HV -> N
HP -> V
FF -> B
OF -> P
VC -> S
KV -> C
FC -> F";

    }
}
﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace WeightCore.Zpl
{
    public static class ZplSamples
    {
        public static string GetSampleFull => @"
^XA

^CI28
^CWK,E:COURB.TTF
^CWL,E:COURBI.TTF
^CWM,E:COURBD.TTF
^CWN,E:COUR.TTF
^CWZ,E:ARIAL.TTF
^CWW,E:ARIALBI.TTF
^CWE,E:ARIALBD.TTF
^CWR,E:ARIALI.TTF

^LH0,10
^FWR

^FO820,30
^CFZ,24,20
^FB1100,4,0,C,0
^FH^FDИзготовитель: ООО ""Владимирский стандарт"" Россия, 600910 Владимирская обл. г.Радужный квартал 13/13 дом 20^FS

^FO510,50
^CFE,44,34
^FB910,4,0,J,0
^FH^FDКолбасные изделия вареные куриные 1 сорта, Колбаса вареная ""Докторская стандарт"" охлажденная ТУ 10,13,14-005-91005552-2016, ц/ф (500г)^FS

^FO350,50
^CFZ,36,20
^FB800,4,0,J,0
^FH^FDСрок годности: 30 суток при температуре от 0°С до +6°С и относительной влажности воздуха 75%-78%. Упаковано под вакуумом,^FS

^FO320,50
^CFZ,25,20
^FB170,1,0,L,0
^FH^FDДата изгот.: ^FS

^FO270,50
^CFK,56,40
^FB300,1,0,L,0
^FH^FD21.05.2021^FS

^FO320,360
^CFZ,25,20
^FB170,1,0,L,0
^FH^FDГоден до: ^FS

^FO270,360
^CFK,56,40
^FB300,1,0,L,0
^FH^FD20.06.2021^FS

^FO320,720
^CFZ,25,20
^FB100,1,0,L,0
^FH^FDКол-во:^FS

^FO270,720
^CFK,56,40
^FB150,1,0,L,0
^FH^FD15^FS

^FO270,800
^CFM,42,38
^FB100,1,0,L,0
^FH^FDШТ^FS

^FO200,200
^CFZ,25,20
^FB200,1,0,L,0
^FH^FDЗамес: 1^FS

^FO200,500
^CFZ,25,20
^FB450,1,0,L,0
^FH^FDЦех/Линия: Весы разработчика^FS

^BY2
^FO200,1000
^BCN,120,Y,N,N
^FD2990000400000413^FS

^BY3
^FO765,25
^B2R,120,Y,N,Y,Y
^FD298000040000041321052116332400100000001^FS

^BY3
^FO70,100
^BCR,120,Y,N,Y,D
^FD(01)4607100234500(37)15>8(11)210521(10)0521>8^FS

^FO200,883
[EAC_107x109_090]
^FS

^FO315,888
[FISH_94x115_000]
^FS

^FO435,883
[TEMP6_116x113_090]
^FS

^PQ1

^XZ
                    ".TrimStart('\r', ' ', '\n', '\t').TrimEnd('\r', ' ', '\n', '\t');

        public static string GetSample1 => @"
^FO820,30
^CFZ,24,20
^FB1100,4,0,C,0
^FH^FDИзготовитель: ООО ""Владимирский стандарт"" Россия, 600910 Владимирская обл. г.Радужный квартал 13/13 дом 20^FS
                    ".TrimStart('\r', ' ', '\n', '\t').TrimEnd('\r', ' ', '\n', '\t');

        public static string GetSample2 => @"
^FO510,50
^CFE,44,34
^FB910,4,0,J,0
^FH^FDКолбасные изделия вареные куриные 1 сорта, Колбаса вареная ""Докторская стандарт"" охлажденная ТУ 10,13,14-005-91005552-2016, ц/ф (500г)^FS
                    ".TrimStart('\r', ' ', '\n', '\t').TrimEnd('\r', ' ', '\n', '\t');

        public static string GetSample3 => @"
^FO350,50
^CFZ,36,20
^FB800,4,0,J,0
^FH^FDСрок годности: 30 суток при температуре от 0°С до +6°С и относительной влажности воздуха 75%-78%. Упаковано под вакуумом,^FS
                    ".TrimStart('\r', ' ', '\n', '\t').TrimEnd('\r', ' ', '\n', '\t');

        public static string GetEac => @"
^GFA,1498,1498,14,
FFFFFFFFFFFFFFFFFFFFFFFFFFF0
FFFFFFFFFFFFFFFFFFFFFFFFFFF0
FFFFFFFFFFFFFFFFFFFFFFFFFFF0
FFFFFFFFFFFFFFFFFFFFFFFFFFF0
FFFFFFFFFFFFFFFFFFFFFFFFFFF0
FFFFFFFFFFFFFFFFFFFFFFFFFFF0
FFFFFFFFFFFFFFFFFFFFFFFFFFF0
FFFFFFFFFFFFFFFFFFFFFFFFFFF0
FFFFFFFFFFFFFFFFFFFFFFFFFFF0
FFFFFFFFFFFFFFFFFFFFFFFFFFF0
FFFFFFFFFFFFFFFFFFFFFFFFFFF0
FFFFFFFFFFFFFFFFFFFFFFFFFFF0
FFF800000000FFF000000001FFF0
FFF800000000FFF000000001FFF0
FFF800000000FFF000000001FFF0
FFF800000000FFF000000001FFF0
FFF800000000FFF000000001FFF0
FFF800000000FFF000000001FFF0
FFF800000000FFF000000001FFF0
FFF800000000FFF000000001FFF0
FFF800000000FFF000000001FFF0
FFF800000000FFF000000001FFF0
FFF800000000FFF000000001FFF0
FFF800000000FFF000000001FFF0
0000000000000000000000000000
0000000000000000000000000000
0000000000000000000000000000
0000000000000000000000000000
0000000000000000000000000000
0000000000000000000000000000
0000000000000000000000000000
0000000000000000000000000000
0000000000000000000000000000
0000000000000000000000000000
0000000000000000000000000000
FFFFFFFFFFFFFFFFFFFFFFFFFFF0
FFFFFFFFFFFFFFFFFFFFFFFFFFF0
FFFFFFFFFFFFFFFFFFFFFFFFFFF0
FFFFFFFFFFFFFFFFFFFFFFFFFFF0
FFFFFFFFFFFFFFFFFFFFFFFFFFF0
FFFFFFFFFFFFFFFFFFFFFFFFFFF0
FFFFFFFFFFFFFFFFFFFFFFFFFFF0
FFFFFFFFFFFFFFFFFFFFFFFFFFF0
FFFFFFFFFFFFFFFFFFFFFFFFFFF0
FFFFFFFFFFFFFFFFFFFFFFFFFFF0
FFFFFFFFFFFFFFFFFFFFFFFFFFF0
FFFFFFFFFFFFFFFFFFFFFFFFFFF0
FFFFFFFFFFFFFFFFFFFFFFFFFFF0
000000000000FFF000000001FFF0
000000000000FFF000000001FFF0
000000000000FFF000000001FFF0
000000000000FFF000000001FFF0
000000000000FFF000000001FFF0
000000000000FFF000000001FFF0
000000000000FFF000000001FFF0
000000000000FFF000000001FFF0
000000000000FFF000000001FFF0
000000000000FFF000000001FFF0
000000000000FFF000000001FFF0
FFFFFFFFFFFFFFFFFFFFFFFFFFF0
FFFFFFFFFFFFFFFFFFFFFFFFFFF0
FFFFFFFFFFFFFFFFFFFFFFFFFFF0
FFFFFFFFFFFFFFFFFFFFFFFFFFF0
FFFFFFFFFFFFFFFFFFFFFFFFFFF0
FFFFFFFFFFFFFFFFFFFFFFFFFFF0
FFFFFFFFFFFFFFFFFFFFFFFFFFF0
FFFFFFFFFFFFFFFFFFFFFFFFFFF0
FFFFFFFFFFFFFFFFFFFFFFFFFFF0
FFFFFFFFFFFFFFFFFFFFFFFFFFF0
FFFFFFFFFFFFFFFFFFFFFFFFFFF0
FFFFFFFFFFFFFFFFFFFFFFFFFFF0
0000000000000000000000000000
0000000000000000000000000000
0000000000000000000000000000
0000000000000000000000000000
0000000000000000000000000000
0000000000000000000000000000
0000000000000000000000000000
0000000000000000000000000000
0000000000000000000000000000
0000000000000000000000000000
0000000000000000000000000000
FFFFFFFFFFFFFFFFFFFFFFFFFFF0
FFFFFFFFFFFFFFFFFFFFFFFFFFF0
FFFFFFFFFFFFFFFFFFFFFFFFFFF0
FFFFFFFFFFFFFFFFFFFFFFFFFFF0
FFFFFFFFFFFFFFFFFFFFFFFFFFF0
FFFFFFFFFFFFFFFFFFFFFFFFFFF0
FFFFFFFFFFFFFFFFFFFFFFFFFFF0
FFFFFFFFFFFFFFFFFFFFFFFFFFF0
FFFFFFFFFFFFFFFFFFFFFFFFFFF0
FFFFFFFFFFFFFFFFFFFFFFFFFFF0
FFFFFFFFFFFFFFFFFFFFFFFFFFF0
FFFFFFFFFFFFFFFFFFFFFFFFFFF0
FFFFFFFFFFFFFFFFFFFFFFFFFFF0
FFF800000000000000000001FFF0
FFF800000000000000000001FFF0
FFF800000000000000000001FFF0
FFF800000000000000000001FFF0
FFF800000000000000000001FFF0
FFF800000000000000000001FFF0
FFF800000000000000000001FFF0
FFF800000000000000000001FFF0
FFF800000000000000000001FFF0
FFF800000000000000000001FFF0
FFF800000000000000000001FFF0
FFF800000000000000000001FFF0
                    ".TrimStart('\r', ' ', '\n', '\t').TrimEnd('\r', ' ', '\n', '\t');

        public static string GetFish => @"
^GFA,1410,1410,15,
FFFFFFFFFFFFFF9FFFFFFFFFFFFFE0
FFFFFFFFFFFFFF9FFFFFFFFFFFFFE0
FFFFFFFFFFFFFF9FFFFFFFFFFFFFE0
FFFFFFFFFFFFFF9FFFFFFFFFFFFFE0
FFFFFFFFFFFFFF9FFFFFFFFFFFFFE0
FFFFFFFFFFFFFF9FFFFFFFFFFFFFE0
FFFFFFFFFFFFFF9FFFFFFFFFFFFFE0
FFFFFFFFFFFFFF9FFFFFFFFFFFFFE0
FF8000000000000000000000003FE0
FF80030000000C0000000000003FE0
FF80078000001E0000000000003FE0
FF8007C000007E0000000000003FE0
FF8007E00000FE0000000000003FE0
FF8007F0001FFE0000003F80003FE0
FF8007F803FFFE0000007FC0003FE0
FF8007FC0FFFFC0000007FC0003FE0
FF8007BC1FFFFC0000007FC0003FE0
FF8007FE1FFFFC0000007FC0003FE0
FF8007DE3FFFF8000000FFC0003FE0
FF8007EE3FFFF8000000FFE0003FE0
FF8003FE3FFFF8000001FFE0003FE0
FF8003FE3FFFFC000001FFF0003FE0
FF8001FE7FFFFE000003FFF0003FE0
FF8001FEFFFFFF000003FFF8003FE0
FF807FFFFFFFFF000007FFF8003FE0
FF81FFFFFFFFFF800007FFF8003FE0
FF83FFFFFFFFFF800007FFFC003FE0
FF87FFFF8FFFFF80000FFFFC003FE0
FF87FFFF07FFFF80000FFFFC003FE0
FF8FFFFC03FE0780000FFDFC003FE0
FFEFFFF000000180001FFFFC003FE0
FFFFFFE000007C00001FFFFC003FE0
FFFFFFF80003FFC0001FFFFE003FE0
FFFFFFFFFC07FFFBC03FFFFE003FE0
FF9FFFFFFF8FFFFFE03FFFFE003FE0
FF8FFFFFFFFFFFFFE07FFFFF003FE0
FF87FFFFFFFFFFFBC07FFFFFC03FE0
FF87FFFFE7FFFFF9C0FFFFFFE03FE0
FF83FFFFF03FFFFDC1FFFFFFE03FE0
FF81FFFFF81FFFFDE3FFFFFFE03FE0
FF807FFFFC1FFFF8E3FFFFFFE03FE0
FF800FFFFC1FFFE0E3FFFFFFE03FE0
FF80003FFE1FFFE1E1FFFFFFE03FE0
FF80003FFE0FFFF3C03FFFFFE03FE0
FF80003FFE07FFFB801FFFFFE03FE0
FF80003FFE03FFFBC01FFFFFC03FE0
FF80003FFC01FFFFC01FFFFFC03FE0
0000003FF0001FFFC01FFFFFC00000
0000003FE00000FFC00FFFFFC00000
FF00003FC0003B3FC00FFFFFC03FE0
FF00003F8003FF8E000FFFFFC03FE0
FF00001F8107FFC0000FFFFFC03FE0
FF00001F3FFFFFF8000FFFFF803FE0
FF00001E3FFFFFF8000FFFFF803FE0
FF00000FFFFFFFFC000FFFFF803FE0
FF000001FFFFFFFE0007FFFF003FE0
FF000001FFFFFFFF0007FFFE003FE0
FF000007FFFFFFFF0007FFFE003FE0
FF00003FFFFFFFFF0007FFFC003FE0
FF00007FFFFFFFFF000FFFF0003FE0
FF0003FFFFFFFFFF000FFFFC003FE0
FF003FFFFFFFFFFF801FFFFC003FE0
FF007FFFFFFEFFFF801FFFFC003FE0
FF01FFFFFFFFFFFF801FFFFC003FE0
FF07FFFFFFEFFFFF800FFFF8003FE0
FF0FFFEFFFFFFFFF0001FFF8003FE0
FF3FFFFFFFFFFFFFE000FF90003FE0
FF7FFFFFFFFFFFFEE000FF80003FE0
FF7FFFFFFFEFEFFFE0007F80003FE0
FF7FFFFFFFFFEFFBC0007F80003FE0
FF3FFFFFFFFFE7FFC0007F80003FE0
FF1FFFFFFFFEEFFFC000FF80003FE0
FF0FFFFFFFFFEFFF8000FF80003FE0
FF07FFFFFBFFEEFF8000FFC0003FE0
FF001FFFFBFFFEFE0001FFE0003FE0
FF000FFFFFFFFCE00003FFF0003FE0
FF0007FFFFFFFFE00007FFF8003FE0
FF0000FFFFFFFFF0001FFFFC003FE0
FF00001FFFFFFFFE001FFFFC003FE0
FF000007FFFFFBFE001FFFFC003FE0
FF000003FFFE67FE001FFFFC003FE0
FF0000000FFC0FBE0007E1F0003FE0
FF00000007800F0E00000000003FE0
FF00000000000E0000000000003FE0
FF0000000000000000000000003FE0
FFFFFFFFFFFFFF8000000000003FE0
FFFFFFFFFFFFFF9FFFFFFFFFFFFFE0
FFFFFFFFFFFFFF9FFFFFFFFFFFFFE0
FFFFFFFFFFFFFF9FFFFFFFFFFFFFE0
FFFFFFFFFFFFFF9FFFFFFFFFFFFFE0
FFFFFFFFFFFFFF9FFFFFFFFFFFFFE0
FFFFFFFFFFFFFF9FFFFFFFFFFFFFE0
FFFFFFFFFFFFFF9FFFFFFFFFFFFFE0
FC0000000000001FFFFFFFFFFFFFE0
                    ".TrimStart('\r', ' ', '\n', '\t').TrimEnd('\r', ' ', '\n', '\t');

        public static string GetTemp6 => @"
^GFA,1695,1695,15,
00000001F800000000000000000000
00000007FF00000000000000000000
0000001FFF80000000000000000000
0000001F8FC0000000000000000000
0000003800C0000000000000000000
000000300060000000000000000000
0000003800C0000000000000000000
0000001F07C0000000000000000000
0000001FFF80000000000000000000
00000007FF00000000000000000000
00000101FC00000000000000000000
000003800000000000000000000000
000003800F80000000000000000000
000003801FC0000000000000000000
0000038018C0000000000000000000
0000038018E0000000000000000000
0000038018C0000000000000000000
000003801FC0000000000000000000
000003800F80000000000000000000
000003800000000000000000000000
00000380F000000000000000000000
00000387FE00000000000000000000
0000038FFF00000000000000000000
0000039FFF80000000000000000000
0000039E03C0000000000000000000
000003BC01C0000000000000000000
000003B800C0000000000000000000
000003B000E0000000000000000000
000003B00060000000000000000000
000003B00040000000000000000000
000003B800C0000000000000000000
0000039801C0000000000000000000
0000039C03E0000000000000000000
0000038E07E0000000000000000000
000003E20000000000000000000000
000003F00000000000000000000000
000003FC0000000000000000000000
000000FF0000000000000000000000
0000003FC000000000000000000000
0000001FE000000000000000000000
00000007F800000000000000000000
00000001FE00000000000000000000
00000000FF00000000000000000000
007F80003FC0000000000000000000
01FFE0000FF0000000000000000000
07FFF80003FC000000000000000000
0FFFFFFFFFFFFFFFFFFFFFFFFFF800
1FFFFFFFFFFFFFFFFFFFFFFFFFFE00
1FFFFFFFFFFFFFFFFFFFFFFFFFFF00
3FFFFFFFFFFFFFFFFFFFFFFFFFFF00
7FFFFFFFFFFFFC0000000000000F80
7FFFFFFFFFFFFF0000000000000780
7FFFFFFFFFFFFFC0000000000007C0
7FFFFFFFFFFFFFF0000000000003C0
7FFFFFFFFFFFFFF8000000000003C0
7FFFFFFFFFFFFFFE000000000003C0
7FFFFFFFFFFFFFFF800000000003C0
7FFFFFFFFFFFFFFFE00000000003C0
7FFFFFFFFFFFFFFFF0000000000780
7FFFFFFFFFFFFFFFFC000000000F80
7FFFFFFFFFFFFFFFFFFFFFFFFFFF80
3FFFFFFFFFFFFFFFFFFFFFFFFFFF00
3FFFFFFFFFFFFFFFFFFFFFFFFFFE00
1FFFFFFFFFFFFFFFFFFFFFFFFFF800
0FFFFC000000000001FE0000000000
07FFF8000000000000FF0000000000
03FFF00000000000003FC000000800
00FFC00000000000000FF000000800
00000000000000000003FC00000800
00000000000000000001FE00000800
000000000000000000007F80000800
000000000000000000001FE003FFE0
0000000000000000000007F803FFE0
0000000000000000000003FC000800
0000000000000000000000FF000800
00000000000000000000003FC00800
00000000000000000000000FE00800
000000000000000000000007E00800
000000000000000000000001E00800
000000000000000000000001E1FE00
000000000000000000000001E3FF80
000000000000000000000001E7FFC0
000000000000000000000001E70FE0
000000000000000000000001E606E0
000000000000000000000001E60E70
000000000000000000000001E71E30
000000000000000000000001E7FC30
000000000000000000000001E3FC10
000000000000000000000001E0F000
000000000000000000000001E00000
000000000000000000000001E003E0
000000000000000000000001E007F0
000000000000000000000001E00630
000000000000000000000001E00630
000000000000000000000001E00730
000000000000000000000001E003F0
000000000000000000000001E001C0
000000000000000000000001E00000
000000000000000000000001E07F00
000000000000000000000001E1FFC0
000000000000000000000000C3FFE0
00000000000000000000000007C3E0
000000000000000000000000078070
000000000000000000000000060030
000000000000000000000000060030
000000000000000000000000060030
000000000000000000000000060030
000000000000000000000000060030
000000000000000000000000060070
0000000000000000000000000300F0
0000000000000000000000000183F0
000000000000000000000000008000
000000000000000000000000000000
                    ".TrimStart('\r', ' ', '\n', '\t').TrimEnd('\r', ' ', '\n', '\t');
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Business.Day13
{
    public class PaperData : IData
    {
        public PaperData()
        {
            Source = SampleData;
        }

        public string Source { get; set; }

        public IEnumerable<Vector2> GetPoints() =>
            Source
                .Split("\r\n", StringSplitOptions.RemoveEmptyEntries)
                .Where(x => !x.StartsWith("fold"))
                .Select(s => s.SelectNumbers(",").ToArray())
                .Select(a => new Vector2(a[0], a[1]));

        public Queue<Vector2> GetFolds()
        {
            var e= Source
                .Split("\r\n", StringSplitOptions.RemoveEmptyEntries)
                .Where(x => x.StartsWith("fold"))
                .Select(a =>
                {
                    var n = Convert.ToInt32(Regex.Match(a, "(\\d)+").Value);
                    return a.StartsWith("fold along y")
                        ? new Vector2(0, n)
                        : new Vector2(n, 0);
                });
            return new Queue<Vector2>(e);
        }


        private const string TestData = @"6,10
0,14
9,10
0,3
10,4
4,11
6,0
6,12
4,1
0,13
10,12
3,4
3,0
8,4
1,10
2,14
8,10
9,0

fold along y=7
fold along x=5";

        private const string SampleData = @"1257,728
889,756
601,166
124,284
120,806
850,827
488,572
584,250
109,877
726,868
522,515
542,51
520,830
323,865
132,379
700,579
45,584
1265,472
298,385
656,746
206,141
803,171
1102,355
661,653
937,794
421,532
284,305
527,697
825,229
649,618
577,707
1151,421
261,331
667,294
1268,200
1173,542
1011,166
174,780
325,675
1129,586
519,280
202,60
139,575
619,869
346,634
191,616
1108,364
822,460
700,217
644,444
323,477
455,417
803,422
534,274
485,450
1022,99
446,579
77,735
1009,128
609,870
350,539
739,812
1064,96
467,101
353,240
281,100
589,492
139,240
295,287
1007,654
540,481
1039,729
179,395
212,887
774,245
900,114
45,136
433,339
925,462
913,446
584,868
1001,439
261,219
527,473
912,756
135,278
338,396
1192,691
932,381
438,821
118,649
134,46
490,394
1225,576
77,159
912,203
233,712
194,379
1138,817
709,728
191,462
505,218
932,513
365,243
23,592
1263,63
177,65
999,442
808,61
338,91
954,45
1151,473
316,50
1174,532
320,285
105,885
214,291
888,474
850,666
301,206
179,353
843,767
1011,572
202,364
1266,117
609,758
545,465
769,635
135,166
191,278
805,829
495,421
1205,213
574,497
1202,700
671,499
808,844
507,50
375,383
396,240
206,722
835,274
984,635
45,24
534,536
609,521
1048,439
534,866
492,276
262,439
378,381
25,667
492,449
408,798
1173,352
864,427
925,95
517,352
1118,400
686,155
480,172
1041,95
269,95
557,219
1021,847
736,497
1141,668
448,22
967,442
232,868
149,666
467,302
303,206
508,441
624,291
850,507
1001,231
791,749
547,290
833,289
25,318
908,635
298,396
480,562
542,280
656,807
85,766
103,733
977,892
487,291
251,729
415,532
421,794
1041,799
885,689
770,7
783,381
490,423
425,339
830,722
980,12
1163,498
147,317
557,3
823,682
44,217
345,313
351,542
749,838
256,205
1200,373
246,826
166,465
1007,78
817,667
147,93
187,575
428,148
345,551
754,607
276,840
465,333
452,555
291,108
599,604
1049,331
1285,318
194,47
873,614
30,784
120,648
902,96
1280,122
311,695
507,422
1230,397
475,51
1293,567
393,443
1241,672
1123,712
505,666
530,787
145,7
589,675
652,434
422,852
85,128
858,555
913,70
743,444
666,93
301,354
823,417
1161,228
721,23
1116,676
557,115
923,721
1001,455
82,114
956,810
1078,868
1039,156
30,110
345,567
846,532
353,766
452,239
298,585
599,738
467,630
87,84
585,894
661,317
885,835
127,348
390,596
92,239
907,837
639,116
282,565
1121,109
1108,60
713,213
847,54
803,844
905,483
684,45
1305,617
301,766
467,549
1108,82
803,498
303,549
1285,227
452,754
1282,45
502,844
477,289
1280,784
5,276
530,554
517,542
803,50
462,46
857,355
1108,107
1144,572
1240,579
894,369
554,536
858,844
1014,336
780,610
517,876
507,723
42,200
649,317
157,777
855,477
986,438
1119,616
425,689
1178,67
206,305
624,30
1282,849
192,400
1098,7
776,872
604,502
463,14
987,417
1053,448
1059,613
710,455
152,376
1193,536
296,336
487,682
1171,575
415,586
1178,172
864,693
482,817
405,187
422,42
1208,690
199,869
70,579
174,172
795,144
1183,546
913,150
485,229
1136,722
985,3
1212,287
900,477
681,576
1123,182
559,53
793,311
1178,379
324,886
1012,585
147,619
1300,444
925,799
1205,885
1255,837
412,429
343,645
1223,84
1247,616
847,145
1280,110
995,705
21,285
626,289
542,715
559,725
1153,674
349,61
862,722
560,26
682,362
356,25
1046,746
162,108
1,219
69,222
303,654
527,197
1278,889
585,448
428,134
960,784
372,329
453,539
304,259
773,122
373,100
905,851
913,824
358,30
1151,753
258,206
124,675
421,756
711,604
1268,194
644,801
23,750
363,701
463,278
298,274
753,675
545,429
686,772
567,444
162,276
864,425
164,165
475,577
612,332
852,567
55,837
945,243
980,241
505,513
45,373
599,57
1076,375
684,509
965,581
271,738
1164,180
637,343
1009,766
359,159
965,327
720,628
242,64
761,213
1093,504
301,227
221,339
446,693
1241,296
1021,651
561,488
522,507
802,5
666,801
805,381
1198,627
251,57
45,794
673,537
1300,562
1225,318
975,453
709,166
44,91
164,729
319,159
191,14
938,329
1287,302
713,208
515,575
802,441
534,358
628,362
980,774
1217,586
70,203
1183,197
226,627
147,422
822,236
262,455
82,266
232,490
452,50
964,634
343,442
1092,754
537,358
1305,170
1101,270
888,42
329,3
579,813
843,661
1029,198
135,616
284,589
1282,421
658,434
686,30
621,427
1183,348
187,712
631,38
44,75
701,521
288,99
686,291
57,54
114,861
129,203
957,206
1198,715
206,172
520,64
684,737
87,892
112,614
497,220
98,63
818,449
835,577
135,749
1108,463
216,373
773,358
467,661
684,605
345,259
137,352
882,298
421,346
994,803
1136,114
721,44
120,620
753,891
1309,219
1010,810
536,747
32,889
808,786
610,873
281,806
1007,712
118,147
365,691
100,312
972,91
1265,198
821,227
492,445
105,319
335,453
658,877
1272,99
1251,497
467,793
626,509
330,882
1046,596
932,499
1119,880
774,649
1240,651
373,646
226,596
488,322
485,444
1012,396
1193,134
546,700
1163,317
1001,887
595,621
624,603
1190,806
315,705
365,47
1246,180
26,532
1181,203
1305,276
166,429
405,491
806,509
187,319
843,345
954,493
460,59
373,794
577,43
1299,189
791,525
10,450
233,346
65,23
488,17
1061,851
351,240
952,478
464,532
569,100
1165,635
1007,549
915,625
505,829
638,789
610,21
194,676
769,259
725,744
463,432
726,250
1116,379
298,620
271,290
999,731
489,227
709,768
965,887
1176,709
1009,675
15,697
813,220
542,504
536,691
1265,548
1123,302
291,210
847,168
45,346
519,861
1000,217
776,866
1280,772
93,40
610,131
672,789
885,205
421,854
1207,733
1103,427
1010,362
726,644
397,70
45,821
1000,371
497,553
309,455
701,381
1297,452
1309,675
28,473
954,512
440,614
1217,838
960,91
751,841
519,77
1052,206
1108,844
378,499
706,403
1,675
249,43
888,420
803,387
169,668
497,674
190,362
1212,215
132,442
681,802
780,844
520,512
599,505
610,469
397,150
609,373
858,386
127,513
151,614
1310,820
1218,743
795,319
323,29
375,63
818,108
202,787
736,49
741,100
497,226
1215,501
863,427
1136,509
1288,336
23,464
1310,535
626,605
753,779
1205,681
437,614
63,616
64,61
1136,562
0,820
520,400
145,635
314,161
343,757
647,453
470,876
70,644
569,576
1305,618
1282,473
858,787
1300,93
788,67
868,861
783,473
85,576
239,532
412,877
788,172
224,204
855,645
965,215
180,714
412,465
274,161
840,18
309,439
1198,155
1033,523
975,441
310,217
679,182
788,890
208,355
726,691
378,513
969,676
408,96
1193,760
1071,532
1010,532
134,64
217,728
547,184
146,180
1268,562
1173,856
403,837
991,159
671,163
30,122
609,513
1203,290
1102,539
610,579
557,779
442,861
291,701
192,848
710,439
157,117
107,604
1059,690
246,49
1116,182
600,7
546,476
865,718
447,427
448,589
1289,285
1240,203
673,343
146,714
515,144
1039,290
136,362
1190,620
758,690
609,808
0,535
16,789
976,161
793,542
1175,278
848,633
754,887
1299,600
840,876
201,91
763,184
951,159
547,738
199,477
1108,787
1131,353
813,329
899,600
1001,215
629,354
679,38
768,51
888,852
174,509
314,285
612,700
264,746
519,525
537,122
1175,166
1146,332
80,845
1061,491

fold along x=655
fold along y=447
fold along x=327
fold along y=223
fold along x=163
fold along y=111
fold along x=81
fold along y=55
fold along x=40
fold along y=27
fold along y=13
fold along y=6";
    }
}
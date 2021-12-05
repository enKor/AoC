﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Day5
{
    public class FloorData : IData
    {
        public FloorData()
        {
            Source = SampleData;
        }

        public string Source { get; set; }

        public IEnumerable<VentsLine> GetVents() =>
            Source
                .Split("\r\n", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Split("->", StringSplitOptions.RemoveEmptyEntries))
                .Select(x => x.Select(o => o.SelectNumbers(",")))
                .Select(o => new VentsLine(
                    new Vector2(o.First().First(), o.First().Last()),
                    new Vector2(o.Last().First(), o.Last().Last()))
                );

        private const string SampleData = @"777,778 -> 777,676
500,510 -> 378,510
441,657 -> 441,638
724,480 -> 724,778
702,85 -> 44,85
973,961 -> 28,16
913,125 -> 483,125
714,895 -> 870,739
273,774 -> 273,795
623,450 -> 623,616
157,49 -> 987,879
430,775 -> 382,775
58,938 -> 718,278
290,366 -> 604,680
75,252 -> 760,937
46,947 -> 788,205
731,197 -> 28,197
25,15 -> 964,954
317,440 -> 66,691
166,427 -> 544,805
686,800 -> 50,164
858,569 -> 447,569
596,50 -> 596,327
739,218 -> 739,278
382,852 -> 382,960
11,984 -> 970,25
911,390 -> 790,511
739,299 -> 739,254
989,172 -> 989,567
36,335 -> 249,335
60,900 -> 121,900
299,380 -> 299,178
701,932 -> 701,224
626,282 -> 641,282
83,532 -> 83,91
246,125 -> 95,125
73,446 -> 308,446
902,907 -> 26,31
841,298 -> 841,547
264,737 -> 974,27
170,199 -> 170,120
135,428 -> 319,244
431,240 -> 431,691
406,935 -> 889,935
192,526 -> 192,82
236,54 -> 236,574
667,369 -> 667,559
501,42 -> 620,42
130,973 -> 208,973
213,639 -> 542,639
943,266 -> 247,962
545,864 -> 423,864
252,698 -> 359,698
314,501 -> 314,948
203,974 -> 472,974
947,125 -> 175,897
956,544 -> 512,544
862,264 -> 549,577
606,138 -> 606,862
239,123 -> 902,786
201,643 -> 201,473
916,375 -> 916,807
10,10 -> 988,988
490,659 -> 490,559
72,66 -> 967,961
215,225 -> 215,281
930,856 -> 203,856
172,481 -> 172,23
867,684 -> 349,166
843,45 -> 843,971
250,779 -> 884,779
973,464 -> 973,794
543,868 -> 39,364
968,424 -> 968,289
470,489 -> 936,489
411,573 -> 411,206
120,691 -> 120,401
134,649 -> 412,649
452,203 -> 452,597
155,604 -> 155,278
914,854 -> 685,854
38,972 -> 975,35
153,403 -> 418,403
731,152 -> 295,588
242,560 -> 513,289
930,619 -> 506,195
547,320 -> 899,320
237,368 -> 479,126
417,842 -> 26,842
213,581 -> 506,288
741,597 -> 742,596
79,440 -> 79,108
424,946 -> 985,946
535,833 -> 716,833
249,328 -> 772,328
616,905 -> 981,905
46,877 -> 227,877
841,770 -> 747,770
202,44 -> 633,475
556,354 -> 556,829
617,864 -> 129,376
318,310 -> 318,927
259,300 -> 259,485
167,482 -> 167,265
349,184 -> 885,184
616,199 -> 921,199
710,162 -> 710,373
499,87 -> 499,214
905,51 -> 258,51
134,739 -> 858,739
879,428 -> 496,45
208,599 -> 208,908
68,225 -> 268,225
581,456 -> 86,456
898,318 -> 278,318
84,910 -> 940,54
344,206 -> 798,660
51,75 -> 909,933
783,780 -> 94,91
907,935 -> 808,836
556,736 -> 556,592
39,611 -> 859,611
29,73 -> 29,438
898,390 -> 898,518
777,647 -> 163,33
144,962 -> 523,962
827,676 -> 469,318
267,647 -> 360,647
742,438 -> 660,438
214,76 -> 214,873
550,177 -> 923,550
182,191 -> 329,191
765,737 -> 765,118
387,322 -> 895,322
174,785 -> 714,245
733,453 -> 852,453
497,136 -> 131,502
574,931 -> 574,568
282,198 -> 282,412
971,324 -> 940,355
827,358 -> 130,358
954,726 -> 311,83
207,195 -> 936,195
42,935 -> 921,56
955,46 -> 35,966
627,361 -> 627,888
37,202 -> 91,202
697,599 -> 155,57
227,264 -> 285,264
50,790 -> 797,43
717,693 -> 88,64
145,234 -> 628,234
358,791 -> 835,791
765,739 -> 765,888
900,204 -> 581,204
544,789 -> 367,789
508,424 -> 689,424
23,964 -> 976,11
404,728 -> 404,949
327,891 -> 327,431
596,204 -> 596,95
686,201 -> 686,982
132,836 -> 132,11
574,434 -> 574,862
41,60 -> 936,955
283,246 -> 283,11
29,226 -> 962,226
483,916 -> 483,562
962,913 -> 131,82
455,316 -> 729,42
858,503 -> 165,503
795,68 -> 388,475
697,477 -> 986,477
932,633 -> 932,114
376,730 -> 270,730
598,672 -> 833,672
69,46 -> 935,46
178,95 -> 862,779
633,73 -> 34,672
488,690 -> 517,661
784,450 -> 784,986
955,560 -> 955,760
651,959 -> 172,480
406,330 -> 406,439
955,737 -> 987,737
194,272 -> 843,921
18,553 -> 93,553
422,387 -> 249,387
318,79 -> 494,79
181,814 -> 709,814
63,62 -> 987,986
636,357 -> 162,357
973,15 -> 27,961
444,415 -> 58,415
884,531 -> 447,968
320,928 -> 73,928
154,357 -> 426,357
200,482 -> 367,315
505,872 -> 505,861
314,432 -> 502,244
912,676 -> 912,618
683,590 -> 881,788
761,708 -> 761,758
40,941 -> 543,438
847,370 -> 801,370
701,297 -> 619,297
140,618 -> 725,618
72,24 -> 968,920
767,396 -> 434,63
710,918 -> 213,421
917,770 -> 92,770
20,979 -> 987,12
909,62 -> 152,62
932,987 -> 56,111
460,382 -> 797,719
518,388 -> 964,388
456,299 -> 456,15
84,783 -> 786,783
982,669 -> 58,669
140,156 -> 140,130
613,264 -> 613,582
267,636 -> 267,805
141,631 -> 762,631
575,26 -> 243,358
318,900 -> 704,514
118,914 -> 118,757
952,846 -> 99,846
673,353 -> 673,633
422,130 -> 228,130
738,52 -> 717,73
307,307 -> 126,307
484,161 -> 942,619
576,886 -> 52,362
375,297 -> 505,297
950,82 -> 243,789
411,57 -> 411,844
879,137 -> 879,334
483,703 -> 483,213
192,24 -> 74,142
561,286 -> 263,584
493,121 -> 493,604
715,576 -> 715,945
238,258 -> 461,258
331,470 -> 851,470
435,22 -> 435,273
315,377 -> 135,557
128,195 -> 794,861
391,143 -> 391,580
33,680 -> 814,680
611,50 -> 611,79
650,28 -> 650,57
196,538 -> 622,964
333,222 -> 333,457
313,254 -> 803,254
508,581 -> 41,581
40,411 -> 55,411
458,600 -> 775,283
105,678 -> 105,345
397,546 -> 814,963
915,669 -> 915,793
773,952 -> 395,574
884,198 -> 404,198
408,929 -> 408,623
123,158 -> 340,158
418,927 -> 757,588
304,338 -> 304,990
505,184 -> 505,28
938,869 -> 938,181
11,959 -> 949,21
232,949 -> 232,660
479,826 -> 479,69
323,427 -> 834,427
460,385 -> 460,94
199,529 -> 493,823
767,58 -> 134,691
901,320 -> 861,320
31,354 -> 28,354
335,165 -> 980,810
586,394 -> 277,394
106,807 -> 567,346
814,987 -> 79,987
166,766 -> 166,990
883,213 -> 676,420
458,454 -> 936,454
878,953 -> 878,682
868,340 -> 868,503
778,252 -> 778,159
237,611 -> 928,611
221,357 -> 643,779
793,775 -> 509,491
719,78 -> 719,878
764,722 -> 107,65
696,323 -> 696,816
49,726 -> 385,726
730,974 -> 386,974
973,310 -> 973,748
12,173 -> 200,173
164,482 -> 473,482
802,807 -> 648,807
104,843 -> 747,843
154,919 -> 802,271
919,837 -> 150,837
882,930 -> 882,752
717,468 -> 461,468
925,112 -> 925,329
714,688 -> 714,66
35,781 -> 737,79
644,139 -> 819,139
340,500 -> 340,195
10,909 -> 524,909
914,790 -> 82,790
962,271 -> 257,976
352,170 -> 352,239
666,39 -> 614,39
854,937 -> 818,901
88,865 -> 852,101
121,796 -> 907,10
836,572 -> 836,649
976,953 -> 976,54
566,584 -> 566,216
927,702 -> 927,703
896,441 -> 896,741
20,30 -> 958,968
934,804 -> 238,804
562,323 -> 12,323
789,550 -> 356,550
906,225 -> 906,886
513,819 -> 513,157
129,80 -> 977,928
37,815 -> 50,802
325,30 -> 899,604
183,614 -> 647,614
497,170 -> 662,170
598,134 -> 228,134
57,636 -> 57,390
11,938 -> 649,300
911,952 -> 850,952
35,950 -> 698,950
161,239 -> 536,239
359,569 -> 359,238
711,945 -> 599,945
866,756 -> 866,987
674,978 -> 96,400
254,653 -> 254,590
655,810 -> 256,810
942,892 -> 394,344
895,744 -> 895,408
549,478 -> 395,478
162,193 -> 162,527
347,242 -> 823,242
251,867 -> 251,77
167,233 -> 285,233
189,969 -> 866,292
847,118 -> 52,913
206,650 -> 131,725
34,790 -> 34,824
872,441 -> 475,838
242,538 -> 718,62
456,514 -> 233,514
384,761 -> 640,761
782,388 -> 782,949
928,809 -> 928,618
461,415 -> 869,823
240,487 -> 215,487
970,687 -> 737,920
63,749 -> 63,493
274,99 -> 462,99
941,989 -> 58,106
142,594 -> 788,594
120,705 -> 535,705
680,248 -> 631,248
544,807 -> 544,737
972,606 -> 972,706
846,800 -> 84,38
836,108 -> 35,909
691,290 -> 691,377
979,883 -> 293,197
766,851 -> 955,851
737,551 -> 713,551
247,70 -> 247,592
855,153 -> 715,13
432,263 -> 797,263
495,839 -> 184,839
544,923 -> 544,45
887,676 -> 875,676
922,230 -> 922,900
168,612 -> 31,749
505,446 -> 625,326
504,370 -> 504,511
943,538 -> 943,784
653,40 -> 653,712
613,973 -> 760,973
152,824 -> 550,426
335,35 -> 57,313
614,334 -> 614,938
399,205 -> 961,767
387,903 -> 583,903
218,395 -> 190,395
935,524 -> 935,402
821,111 -> 821,372
609,621 -> 220,621
503,288 -> 467,324
641,139 -> 641,369
420,924 -> 420,532
344,504 -> 344,698
340,96 -> 169,96
835,505 -> 640,700
464,344 -> 464,133
946,396 -> 946,10
295,313 -> 437,171
330,286 -> 291,286
608,653 -> 608,613
360,410 -> 749,410
115,288 -> 115,334
915,550 -> 915,858
902,16 -> 143,775
201,901 -> 170,932
37,968 -> 987,18
40,332 -> 586,878
271,407 -> 271,858
836,674 -> 624,674
308,715 -> 361,715
733,818 -> 449,818
23,36 -> 862,875
278,655 -> 685,655
924,764 -> 924,913
479,250 -> 850,621
312,116 -> 468,272
10,954 -> 891,73
554,313 -> 918,677
846,773 -> 846,476
681,948 -> 681,961
418,835 -> 263,835
352,222 -> 557,222
782,188 -> 782,11
609,845 -> 954,845
866,882 -> 310,882
479,180 -> 119,540
278,866 -> 140,866
874,617 -> 505,617
491,942 -> 280,942
584,574 -> 839,829
475,466 -> 620,466
652,215 -> 652,85
906,746 -> 906,824
381,317 -> 749,685
294,837 -> 294,165
450,893 -> 430,893
99,374 -> 99,864
919,313 -> 99,313
187,91 -> 187,304
654,982 -> 654,324
662,223 -> 471,223
848,554 -> 848,13
14,851 -> 14,855
438,287 -> 531,287
611,277 -> 309,277
630,379 -> 630,99
621,531 -> 787,531
12,292 -> 12,11
18,985 -> 162,985
49,919 -> 530,438
329,828 -> 369,868
725,976 -> 725,267
826,591 -> 826,562
249,651 -> 280,651
467,461 -> 759,461
720,968 -> 745,968
414,29 -> 54,389
204,740 -> 91,853
694,300 -> 694,393
517,748 -> 517,231
465,946 -> 718,946
252,322 -> 902,972
109,641 -> 692,641
973,969 -> 104,100
302,368 -> 302,914
385,19 -> 385,192
460,851 -> 387,851
310,221 -> 660,571
684,147 -> 642,147
371,711 -> 169,913
810,727 -> 810,559
428,576 -> 88,236
381,33 -> 655,307
37,428 -> 37,68
11,29 -> 962,980
880,698 -> 227,45
624,361 -> 624,351
487,917 -> 183,613
725,498 -> 725,889
880,71 -> 27,924
856,752 -> 274,752
541,419 -> 516,419
803,688 -> 152,37
835,304 -> 964,304
480,249 -> 74,655
742,883 -> 213,883
943,41 -> 378,41
869,924 -> 869,563";

    }
}
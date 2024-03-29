﻿using System;
using System.Collections.Generic;

namespace Business.Day10
{
    public class ChunkData : IData
    {
        public ChunkData()
        {
            Source = SampleData;
        }

        public string Source { get; set; }

        public IEnumerable<string> GetRows() =>
            Source
                .Split("\r\n", StringSplitOptions.RemoveEmptyEntries);

        private const string SampleData = @"[[<<<{<<<(<<(([]())(<><>))<[{}()][(){}]>>(([()[]]<{}()>)[<[]{}>[(){}]])>)>([{<<<()()>[<>()
[<[<{[[({[({{[(){}][()[]]}<[{}<>](<>[])>}{<[{}{}][<>()]]{{[]}{[][]}}}){(([<>{}]<(){}>))<({<>{}}{{}{}}){[[]<>
[<<<[{{[[{({{[<>{}][()]}}[[[[][]][{}<>]]])<{(({}<>)<()>)<[{}<>][()()]>}>}(<{[[()()]{{}()}]>[<<{}
([[{<{{({<[{[([][]){[]<>}>(<[][]>[<>()])}([<<>><{}<>>]{({}{})[{}[]]})]>})[[[<<(<()[]>{<>()
{([<(({[[<{{[[{}<>]({}[])><{(){}}{()()}>}<<[()[]][{}[]]><[<>{}]([]{})>>}([(<(){}>{{}()})<<{}{}>{[]{
[[(<{[<(<<([<{<>()}<<><>>><({}{}}{{}[]}>]{[{<>()}(<>{})]{{()[]}{(){}}}})><<{({<>[]}[<>[]]){[()[]]}}((<<>{}>
{([{({([((<<{(()())<<>[]>}<{()[]}({}<>)>>({<{}()>[<>{}]}[<(){}>{()<>}])>{[<{<>{}}>({()[]}<<>()>)]({({}<>)<{
{([((<{({[[{<{<>{}}>}{[{{}{}}({}{})]{[[]])}][<[<{}{}><()()>][(<>{})]><<{{}{}}({}{})>>]](<[([{}()]({}()))[(
(({<{[{{([<{[<()()>]<{{}()}{[][]}>}<{[<>()]{()[]}}<(()()>{{}()}>>>[<{{[]<>}}>]]{{[{{[][]}[[]{}]
[(((<{({<{<(({<><>}({}()))<[()()]{()<>}>)({(()<>)[(){}]}<{{}[]}[{}{}]>)]}{([{[[]()]{{}{}}}[((){}){<>
({{{((<(<<<[<({}<>]{<>{}}>{{()<>}{<>()}}][[[()()]{[]<>}]{[{}][[][]]}]>>>)>{{({({{{()<>}(<>{})}
({[[(<[[(((([({}<>)[()[]]]{<()()>[[][]]})([[<>{}][()()]]{{<>{}}[{}[]]})})[<{<(<>[])({}[])>}{<((){})>{{{}
{[<<{([[<<({{((){})(()[])}(<[]<>>{()[]}))<[[<>][[][]]][(<><>)<<>()>]>){{[<<>()>(<>[])]([()[]]{()
<[{({<<[{[[({[[]]([]{})}[(()())<<>{}>])([[<>()]<[]{}>][{<>()}<[]()>]}]](<<{{{}<>}<<>[]>}<(()())>>>{{<[[]]<<><
<[[<(({<({[[<[{}[]]{()()}>[[<>{}]]]<(<[][]>[{}{}]>>]})[({<[[{}[]](()())](<{}<>>[{}[]])>[(<<>{}>({}<>
[([([(<[({([[(()()){()()}]])}<[{<[<>{}]>{<[]()>{()()}}}][<<[[]}[[]<>]>([[]()](<>()))>[{{(){}}({
({[[<((<{[<{({[][]}<{}{}>)<[[]()][()()]>}>(<[[(){}][()[]]]{[<>][<><>]}>([[()[]]{<>{}}]{[<>]{<>[]}
[({<{<((({{<{{[]{}}(()[])}>}<{[[<>()][{}]]{<<>{}>[[]()]}}{<<[]{}>>[<<>()><<>()>]}>}{{{[(<>())(()[
<(<<{(<(([[[<[<>{}][()()]>({{}{}}[[]{}])]][<<<<>()><<>{}>>[{[][]}]>([{[][]}<()()>]<<{}<>>>)]]<<{({<>()}{[]
((<<(({{<{({<<<>()>[()()]>((<><>)<(){}>)}({<()<>><<>()>}{(<>())[[][]]}))<({(<><>)([]())}<<[]<>>(
({(<<[{<<<{<{([]{})<[]<>>}<<<>()>(<>{})>>[[{[][]}{()[]}](<<><>>)]}([[{{}{}>(()[])]{({}<>)<[][]>}](<<()<>
{{<[<[{([({[([(){}](()[]))([{}<>][[]{}])]}({[({}{})](({}{})[{}{}]))<{(()())}{[[]()](<><>)}>))]{(<{{[()
[{[{({<{<([<<<{}{}>[[]()]>{<[]<>>(()[])}>{([()<>]<()()>){[{}{}>(<>[])}}]((<{<>{}}<{}{}>>)))[[<<<()()
{({({<[([<[{[(<>[])<<>[]>]}{<(<>()){{}<>}>({<>{}}<<>[]>)}][(<[{}()][<><>]>([<>()]))]>{({(({}())<[]()>)}[
({((<{{([[{<{<<><>>([]<>)}{([]()]{<>()}}><{({}<>)(()())}{[()<>][{}[]]}>}(<{{()}[[]{}]}{[[][]][[]()]}>(([<
{{<[<[{[({{[{(()[])[[]<>]}<{[]<>}{[]<>}>]}(({[{}<>]{<>[]}}([{}()]))(<[{}[]][[]{}]>{(()<>)}))}{[[[([]())(()<
[{{[{[[([{(([((){})[{}()]>{{[][]}(<><>)})[<<{}{}><()<>>>({[]()}[{}{}])])}[[<[({}{}){[][]}]{(()())<{}
{[<(({[(({[{[<[][]>[<>()]][(<>()){<>[]}]}]([{[{}()}<<><>>}[<()[]><[]()>]]{<[()()][<>]>({<>{}}{()()})})
((<<[<(({{<({{()<>}(()())}{{[]{}}}){<[[]{}][[]<>]><<<>()>{{}<>}>}><({[()<>]})<<((){})[[]<>]>>>}{(<[[
(([<({[[{{((<(()<>)<<><>>><{()<>}[[][]]>))}{({<((){})(<><>)>}<{[<>[]][()()]}[<()><[]{}>]>)<[(((){})<{}[]>
<{[<{<{(<({(([{}<>]<()<>>)[{{}<>}(()<>)})(({()<>}<[]{}>)({()}))}[[({[]}<<>[]>)[[{}()][[]<>]]][{{
(<[([[((<<<(([{}{}])([()()](()<>))){[[{}{}]<()[]>]{<[]()>{{}{}}}}>{([[()()](<><>)]){{<(){}>}
([({<[([[<<<<(<>())({}[])><[{}<>](<><>)>><[<()[]><<>()>]{{<>[]}([]<>)}>>>]<[[<{[(){}]([]{})}([[]{}]
([{([[([[{([<{{}[]}(()<>)><<{}<>>[<>[]]>]{[(<><>)[<>()]][{{}{}}]})}{<[{([]())[[]]}<[[]{}][<>()]>]>([<[<><
[{<[([{([([({<<><>>(<><>)}{[{}{}]<()>})])[[[<{<>{}}[[]()]>{<<>>[[]<>]}]<<<<>{}>([][])>({()()}[[]<>])>]]]
(([{(({(<([<<(<>())[{}<>]>>({(()[])[<>()]})]<[([(){}]<{}<>>)<((){})<[][]>>]({(<>()){()<>}}[{()()}<(
{<{{{({{{{([<([]{})<<>[]>><{[][]}{[]<>>>]([<[]<>><()[]>]{[{}<>](<>[])}))<({(()<>)([][])})>}{[<<[{}
((<({[([{<<<{([][])[[]]}{<<>[]>[{}[]]}}>((<[()]{()()}>){[[<><>]([]{})]})><<[<{<><>}[()()]>(<[]{}>([]()))
[<[{[[[[{{{(([{}[]]<{}[]>))[{<[]<>>}[([][])([]())]]}(([([]{}]]<({}{})<<><>>>)[<{{}[]}<{}()>>[<
<([<{[{<[<{<<{(){}}[{}<>]>({[]{}}}>}<<({[][]}{[]<>})[(()<>)({}<>)]>>><[{({<>}([]<>))[<{}<>>
{[[{(<(<<([[<<[]()><{}()}>]<<{<>[]}([]{})>{[<>[]]<{}[]>}>][[[<{}()>({}<>)]]<{<<>>}<<[]{}>>>
([{<<<(<[([<([[]{}]<[][]>)<{<>[]}[[][]]>>{{{<>{}}[[][]]}{[{}()])}]{(<[<><>]<()<>>>){([{}()][<>[]])
[{[[<{[<<{{[([[]{}])]}<[<[{}()]{(){}}>[<()[]><()()>]]>}({{<<{}<>><{}[]>>}[<<<>{}>{(){}}>]})>><[
[{[{<[<(([[{{{()()}<()<>>}[[[]<>]<[]()>]}{{<{}{}><<>[]>}[([]<>)[{}{}]]}]{{<<()()>[[][]]><{()()}(()())>}}]
([<{{(<(<<(<([()[]]<<>[]>){{()()}(<>[])}>)<[<[<><>]{()[]}><<{}{}>{[][]}>][([()[]]<{}[]>)<<<><>>
[{<{[[{<([{[<[<><>]{()()}>[({}<>)]]}({[(<>{})<{}<>>]{[<>()][[]{}]}}[<([]<>)(<>[])>[[()()]{
(<{{(<({[(<{[([]())[[][]]][(<>())]}>)[<<[{{}<>}<<>[]>][({}())<[][]>]><[([][])]<{()()}({}{})>>>[([<(){}>{{}[]
[([<(<{{{{{[[(())<[]<>>]([()()])]<{{<><>}(()<>)}[<<>>[<>{}]]>}(({{<><>}{<>}}[([])<{}()}]){{<{}()><[]()
(<[[[({(<(<[{({}<>)<<><>>}]>(<[<[]{}>{{}()}][[<>()](<>)]>))<{{<{(){}}[<><>]>[<()<>>]}[(<<>{}><<
[([(<[[({<<([{(){}}([][])]{[[][]][{}<>]}){<({}()){<>{}}>[((){})[[][]]]}>((<<[]{}>>({<>[]}]){<(<>(
(({<(<(<({{({<[]()>})[<{<>{}}{<><>}><(<>[])(<><>)>]}{{{{<>{}}(())}}<[{{}<>}<{}{}>]{(()()){{}{}}}>}})>[(<{({[<
([<[([<{[[<({<()[]>}{{{}{}}[()[]]})(<[{}[]]{<>{}}><{{}[]}<[]<>>>)>{[[{{}[]}<[]{}>]{{<>{}}<{}()>]]<[{<>[]}[
{{[([<<{((({{{[]}(()[])}[({}{})(()<>)]}(((()){()[]})[<{}<>)<{}{}>])){[<<{}()>[()<>]>[(()<>)[()[]]]]})({{[
{<<[<({<[[<{((()[])({}())){{{}[]}<{}()>}}{<<[][]>[(){}]>((<>{})[()()])}>]{{{{[[]()](()())}(<
<<{[{<{([{{{[{()<>}}[<<>[]>]}}{(<[<><>]<<>{}>><[()<>]({}())>)<{<<>{}>[<><>]}[([]())<<>>]>}}][{[[{[<>[]
[(({{{{({({{<{[]()}>(({}{}){<>()})}})<(<(<[][]>)[<<>><[][]>]>(<(<>[])(<>())>))>})<<<[{<({}[]){()[]}>[
({{<(<{({{[[<[{}()]<[]<>>>([()<>]<[]<>>)][[[<>{}]{()()}]{{[]()}<()>}]][([[()<>][[][]]]<({}[]){<>}>)[<<{}
[<(<(<[([<<{<[[][]][<>{}]>}(<{{}()}{(){}}>)>>]){([<{(<[]{}>{()}){[{}()]<<><>>}}{{<<>()>}]><[<<[][]>[[]<>]>
<({[{(<(<[({((()())[<>()])[<{}[]>({}())]}{{([]())<<><>>}{[{}()]{{}{}}}})[(<{<><>}<[]{}>>[[[]
<[<[<{({{[<[(([]<>)<[]<>>)<{[]<>}{()[]}>]<<<{}<>><{}>><[{}{}]<[]()>>>><(({<>[]]<[]{}>))[{<[]{}><[]<>>}((
<<{<(<{{(<{<<<(){}>[[]<>]>>({[{}()]<{}>})}<[<{[][]]{<>[]}><{{}[]}<[]{}>>]([{{}()}]{<()><{}[]>})>>)}<[<[<
[<<{{<[[([<{({[]()}{[]<>})<[(){}]<()[]>>}<[{<>()}<{}<>>]>><<[<(){}><()[]>]{[[]()]}><{{()[]}{(){}}}{[[]
[<{((<{(({{<{{()<>}[<>()]}((()[]))>}([({<>()}[<>{}])<({}{})<()[]>>][<([]())<{}{}>>[({}{}){[]{}}]])}){
({[{{{<(<[[([{<>()}<{}<>>])({[[]<>]{{}<>}}[({}())<{}<>>])]([{<()()>}({()[]})])](<<{[{}{}][<>[]]}{[<>](()[
{<{{([<<[({({<(){}>[<><>]}[<<>{}>{{}[]}])}[[[<(){}>[[]()]][{[]()}]]<([()[]][[]<>])[<{}{}><<>[]>]>>)<<[
<<(<{{(({<<(<{{}{}}{{}<>}><{[]<>}{{}()}>)>{{<{[]()}[()()]>[<[]()>{{}{}}]}<(<[]()>{()()})[[[][]]]>
<{<[{{<[((({<<[]()>{()[]}>}{{[(){}]{{}()}>{[{}[]]((){})}})<([[{}()]{[]()}])>)){<[[[<<>[]>{[]}
[<(({[(<<<<<{[<>[]][[]<>]}(<<>()>{[]()})>><[(<<>[]>(()<>))<([]{})({}{})>]([[(){}]]{[{}[]]([]
<[[({[((<[{[({[]<>})({[]{}}[()()])]}<[[[<><>]<(){}>]{(<><>){[]<>}}][<{<>[]}{<>{}}>([<>()])]>]<((<{[][
<<[{([{<<<[[[{()[]}([]<>)]<({}()){[]()}>](<((){}){{}<>>><{{}()}{[]<>}>)]>>><<<<<[{[]}]>{({()<>}(
([([{<{{{[([({{}<>}{()()>)]<{[()()]}({(){}}[[]<>])>)[({<<>{}>}[[()][<>[]]]){[<()[]>]}]]}<[(<(({}())[(
([<[<{{({<{({[()[]]{[][]>}[[<>[]]<<>{}>])<<[[]]{<><>}>({[]()}[{}{}])>}[{<[{}[]]<{}()>><<()[
((<<({<<([{<<((){}){{}()}>>}([<{{}()}({}{})>[<[]>[{}{}]]]<[({}[])[<>{}]][(<>{})<(){}>]>)])(<[<{{[]()}[<>()]}[
[{([(<<([[<(({[]{}}[<>])[{<>{}}{<>{}}])((<[]>))>][{[[({}()){[]{}}]]<([()][{}{}])>}({(<[]()>(<>()
(<([((<<[{[<[[<>{}][{}{}]]>]{(<(<>[])<{}[]>>{(<>[])[()<>]})[{{<>()}{{}[]>}{{(){}}[<>[]]}]}
<{{[{{<[{{{[<[<><>]{()()}>((<><>)([]()))]<{<()()>[()]}<<[][]>{{}[]}>>>{[{{[]<>}}[{()<>}([][])]]}
<{<<[({((({<(<{}>[()[]])((()){{}{}})>({([]<>)[[]{}]}[([]()){[][]}])}{(<{()[]}(<>{})>{{<>[]}[[]{}]}){[(
(<{[<[{<[(<<<{[]()}[[]<>]>{(()<>)([]<>)}>(({{}()}))>[([{<>[]}]{[<><>]<[]{}>})(<<[]<>>{()()}><[<>{}]
{<{<<{<<{{{<(<{}><[]<>>)({(){}}[[][]])><{{[]()}{<>{}}}>}}{[[[{[][]}([]())][([]<>){<>}]]][<((<
{(<{[[[{([{[<<{}>[(){}]>[<[]()>([]())]]({({}[])[[][]]}({{}{}}(()[])))}{(([()[]]{{}[]})<{<>[]}<()[]>
[[{{<{(([{{{[(<><>)]({{}[]}[()])}<<<<>[]><{}())><([]{})>>}<<{[[]()]{{}{}}}{{[][]}[()<>]}>>}<<([{[
(<({[<{<({<[{<[]{}>[<>()]}]<[{()[]}<()[]>][([]{}){()()}]>>})>}[<([{{<({})<[]<>>>{{<><>)}}[[([])[
{[{({[[[[{(([{(){}}<[]<>>][{<>()}<[]()>])([(()[])]{{{}}([]<>)}))}{{{<[{}()][<>()]>{{()()}[(
{{{[[({{{{<[[{{}{}}((){})]<<<>{}><<>[]>>]>{<[[{}[]]{[]()}][<[]()>{{}}]>{[(<>{}){[]{}}]{(()[])((){})}}}}{
(<[{({<(([<((<{}{}>[[]{}])[<()()>[<>{}]])>(<[<[]()>{{}[]}]{<{}<>><()[]>}>{{[<>[]]<{}>}<{{}<>}
[{({<{[{[[{([<[]>[()()]]<{()[]}>)}[<<<[]>[()()]>>]]]<{<<{((){})<<><>>}[([]{}){(){}}]>>{([[<>
[{<[[(<(([([[[{}<>]({}[])]{<()<>>{{}{}}}))]{[([<{}<>>{()[]}][(()<>)([][])]){([[]()][{}{}])<[()<>]{
<<(<{[<{{[<([{()<>}<()()>]<<[]{}><[]<>>>)>]({[<([]{})[<><>]><{(){}}<[]()>>]})}[({[[<<>>(<>{})
{({<{[<<({{(([(){}](<><>)))({{<><>}[[][]]}{({}()){<>{}}})}{<[((){})]<([]())>>([[{}<>]{()[]}])}})([<[{[<><>
[[<[[<({<(<({({}<>)[[][]]}){<<()><[][]>>[({}())[()[]]]}>[(((()())([]())))])>({({{{()()}({}())}";

    }
}
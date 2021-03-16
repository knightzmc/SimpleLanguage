module SimpleLanguage.Math

let log10 n = log n / log 10.0

let countDigits n = n |> float |> log10 |> ceil

open System
open SimpleLanguage

[<EntryPoint>]
let main argv =
    (Lexer.lex "12345 + 2") |> printfn "%A"
    0

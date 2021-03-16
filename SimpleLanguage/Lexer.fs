namespace SimpleLanguage

open System
open Parsing
open Math

module Lexer =
    type Token =
        | Number of int
        | Addition
        | Subtraction
        | Multiplication
        | Division

    let rec lex (str: string): Token list =
        (str, List.empty)
        ||> Seq.foldBack (fun c state ->
                match c, state with
                | '+', _ -> Addition :: state
                | '-', _ -> Subtraction :: state
                | '*', _ -> Multiplication :: state
                | '/', _ -> Division :: state
                | _, Number x :: tokens when Char.IsNumber c ->
                    let digits = countDigits x
                    let nextColumn = int (10.0 ** digits)
                    let res = charToInt c * nextColumn + x |> Number
                    res :: tokens
                | _, state when Char.IsNumber c -> Number(charToInt c) :: state // The start of a number literal
                | _, state when Char.IsWhiteSpace c -> state //Ignore whitespace
                | _, _ -> [])

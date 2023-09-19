module BrainfuckInterpreter_Fs.Interpreter

open System
open System.Collections.Generic

let interpretBrainfuck (code: string): string =
    let mutable output = ""
    let tape: int[] = Array.zeroCreate 30_000
    let mutable ptr = 0
    let mutable codePtr = 0
    
    let bracketIndices = Stack<int>()
    let matchingBrackets = Dictionary<int, int>()
    
    let mutable startIdx = -1
    
    for i in 0..code.Length-1 do
        if code[i] = '[' then bracketIndices.Push(i)
        elif code[i] = ']' then
            startIdx <- bracketIndices.Pop()
            matchingBrackets[startIdx] <- i
            matchingBrackets[i] <- startIdx
    
    while codePtr < code.Length do
        match code[codePtr] with
            | '>' -> ptr <- ptr + 1
            | '<' -> ptr <- ptr - 1
            | '+' -> tape[ptr] <- (tape[ptr] + 1) % 256
            | '-' -> tape[ptr] <- (tape[ptr] - 1 + 256) % 256
            | '.' -> output <- output + Convert.ToChar(tape[ptr]).ToString()
            | '[' -> if tape[ptr] = 0 then codePtr <- matchingBrackets[codePtr]
            | ']' -> if tape[ptr] <> 0 then codePtr <- matchingBrackets[codePtr]
            | _ -> raise(ArgumentException("Invalid code string"))
        codePtr <- codePtr + 1
    
    output